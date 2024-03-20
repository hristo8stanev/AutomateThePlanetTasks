using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BlueHostingLogin.Pages.BasePage;

public abstract class WebPage
{
    protected int WAIT_FOR_ELEMENT => 20;
    Actions _actions;

    public WebPage(IWebDriver driver)
    {
        _driver = driver;
        WebDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT));
        _actions = new Actions(_driver);
    }
    protected IWebDriver _driver { get; set; }
    protected WebDriverWait WebDriverWait { get; set; }
    protected abstract string Url { get; }

    public void GoTo()
    {
        _driver.Navigate().GoToUrl(Url);
       
    }

    public IWebElement MoveToElement(By locator)
    {
        IWebElement element = _driver.FindElement(locator);
        _actions.MoveToElement(element).Perform();
        return element;
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
