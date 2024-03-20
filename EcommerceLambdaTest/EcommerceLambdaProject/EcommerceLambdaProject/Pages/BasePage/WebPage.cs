using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace EcommerceLambdaProject.Pages.BasePage;
public abstract class WebPage
{

    protected WebDriverWait _wait { get; set; }
    protected IWebDriver _driver { get; set; }
    protected Actions _actions {  get; set; }
    private int WAIT_FOR_ELEMENT => 30; 

    protected WebPage(IWebDriver driver)
    {
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT));
        _driver = driver;
        _actions = new Actions(_driver);
    }

    protected abstract string Url {  get; }
}