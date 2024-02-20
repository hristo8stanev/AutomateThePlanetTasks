using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace DemosBellatrixSolution.Pages.BaseWebPage;

public abstract class WebPage
{
    private int WAIT_FOR_ELEMENT => 30;

    public WebPage(IWebDriver driver)
    {
        Driver = driver;
        WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT));

    }
    protected IWebDriver Driver { get; set; }
    protected WebDriverWait WebDriverWait { get; set; }
    protected abstract string Url { get; }

    public void GoTo()
    {
        Driver.Navigate().GoToUrl(Url);
        WaitForPageToLoad();
    }
    protected virtual void WaitForPageToLoad()
    {


    }

    protected IWebElement MoveToElement(By locator)
    {
        Actions actions = new Actions(Driver);
        IWebElement element = Driver.FindElement(locator);
        actions.MoveToElement(element).Perform();
        return element;
    }
    protected IWebElement WaitElementToBeClickable(By locator)
    {
        var webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT));
        return WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(locator));
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
