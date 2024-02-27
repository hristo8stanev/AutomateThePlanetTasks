using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace GPSCordinatesProject.Pages.BasePage;
public abstract class WebPage
{
    private int WAIT_FOR_ELEMENT => 30;

    public WebPage(IWebDriver driver)
    {
        _driver = driver;
        WebDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT));

    }
    protected IWebDriver _driver { get; set; }
    protected WebDriverWait WebDriverWait { get; set; }
    protected abstract string Url { get; }

    public void GoTo()
    {

        _driver.Navigate().GoToUrl(Url);
    }
    protected IWebElement WaitAndFindElementJS(By locator)
    {
        var element = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(locator));
        scrolltoVisible(element);
        return element;
    }

    public void scrolltoVisible(IWebElement element)
    {
        try
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        catch (ElementNotInteractableException ex)
        {

        }
    }

    public void WaitTextToBePresentInElement(By locator, string value)
    {
  
       WebDriverWait.Until(ExpectedConditions.TextToBePresentInElement(_driver.FindElement(locator), value));
    }

    protected IWebElement MoveToElement(By locator)
    {
        Actions actions = new Actions(_driver);
        IWebElement element = _driver.FindElement(locator);
        actions.MoveToElement(element).Perform();
        return element;
    }

    public IWebElement ScrollToTheElement(By locator)
    {
        IWebElement element = _driver.FindElement(locator);
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        js.ExecuteScript("arguments[0].scrollIntoView();", element);
        return element;
    }

    protected IWebElement WaitAndFindElement(By locator)
    {

        return WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(locator));
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
