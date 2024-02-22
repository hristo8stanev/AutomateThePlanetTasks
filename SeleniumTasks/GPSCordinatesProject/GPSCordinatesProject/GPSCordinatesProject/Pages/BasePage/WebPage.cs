using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        WaitForPageToLoad();
    }
    protected virtual void WaitForPageToLoad()
    {


    }

    protected IWebElement MoveToElement(By locator)
    {
        Actions actions = new Actions(_driver);
        IWebElement element = _driver.FindElement(locator);
        actions.MoveToElement(element).Perform();
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
