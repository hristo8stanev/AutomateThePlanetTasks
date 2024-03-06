using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace PriceStockCompany.Pages.BasePage;
public abstract class WebPage
{
    private int WAIT_FOR_ELEMENT => 30;
    protected Actions actions;


    public WebPage(IWebDriver driver)
    {
        _driver = driver;
        WebDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT));
        actions = new Actions(_driver);

    }
    protected IWebDriver _driver { get; set; }
    protected WebDriverWait WebDriverWait { get; set; }
    protected abstract string Url { get; }

    public void GoTo()
    {
        _driver.Navigate().GoToUrl(Url);
    }

    protected IWebElement MoveToElement(string locator)
    {
        IWebElement element = _driver.FindElement(By.XPath(locator));
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
        var js = (IJavaScriptExecutor)_driver;
        WebDriverWait.Until(wd => js.ExecuteScript("return jQuery.active").ToString() == "0");
    }

    protected void WaintUntilPageLoadsCompletely()
    {
        var js = (IJavaScriptExecutor)_driver;
        WebDriverWait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "comeplete");
    }
}
