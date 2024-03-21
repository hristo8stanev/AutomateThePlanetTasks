 using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace DemosBellatrixSolution.Pages.BaseWebPage;

public abstract class WebPage
{
    private int WAIT_FOR_ELEMENT => 30;
    Actions _actions;

    public WebPage(IWebDriver driver)
    {
        _driver = driver;
        _webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT));
        _actions = new Actions(_driver);
    }
    protected IWebDriver _driver { get; set; }
    protected WebDriverWait _webDriverWait { get; set; }
    protected abstract string Url { get; }

    public void GoTo()
    {
        _driver.Navigate().GoToUrl(Url);
    }
   
    protected IWebElement MoveToElement(By locator)
    {
       
        IWebElement element = _driver.FindElement(locator);
        _actions.MoveToElement(element).Perform();
        return element;
    }

    protected IWebElement WaitElementToBeClickable(By locator)
    {
        var webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT));
        return _webDriverWait.Until(ExpectedConditions.ElementToBeClickable(locator));
    }

    protected IWebElement WaitAndFindElement(By locator)
    {

        return _webDriverWait.Until(ExpectedConditions.ElementExists(locator));
    }

    protected IWebElement waitAndFindElementJS(By locator)
    {
        var element = _webDriverWait.Until(ExpectedConditions.ElementIsVisible(locator));
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

    protected void WaitForAjax()
    {
        var js = (IJavaScriptExecutor)_driver;
        _webDriverWait.Until(wd => js.ExecuteScript("return jQuery.active").ToString() == "0");
    }

    protected void WaintUntilPageLoadsCompletely()
    {
        var js = (IJavaScriptExecutor)_driver;
        _webDriverWait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "comeplete");
    }
}
