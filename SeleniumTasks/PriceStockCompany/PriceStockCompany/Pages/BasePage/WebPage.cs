using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace PriceStockCompany.Pages.BasePage;
public abstract class WebPage
{
    private int WAIT_FOR_ELEMENT => 30;
    Actions actions;


    public WebPage(IWebDriver driver)
    {
        Driver = driver;
        WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT));
        actions = new Actions(Driver);

    }
    protected IWebDriver Driver { get; set; }
    protected WebDriverWait WebDriverWait { get; set; }
    protected abstract string Url { get; }

    public void GoTo()
    {
        Driver.Navigate().GoToUrl(Url);
    }

    protected IWebElement MoveToElement(string locator)
    {
        IWebElement element = Driver.FindElement(By.XPath(locator));
        actions.MoveToElement(element).Perform();
        return element;
    }


    public void VisibilityOfAllElementsLocated(string locator)
    {
        WebDriverWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(locator)));
    }

    public void IsElementDisplayed(string locator)
    {
        var element = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
    }


    protected IWebElement WaitAndFindElement(By locator)
    {

        return WebDriverWait.Until(ExpectedConditions.ElementExists(locator));
    }

    protected void WaitForAjax()
    {
        var js = (IJavaScriptExecutor)Driver;
        WebDriverWait.Until(wd => js.ExecuteScript("return jQuery.active").ToString() == "0");
    }

    protected void WaintUntilPageLoadsCompletely()
    {
        var js = (IJavaScriptExecutor)Driver;
        WebDriverWait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "comeplete");
    }
}
