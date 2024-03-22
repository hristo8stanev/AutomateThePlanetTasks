using System.Collections.ObjectModel;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace EcommerceLambdaProject;

public class DriverAdapter : IDriver
{
    private  int WAIT_FOR_ELEMENT => 30;
    private IWebDriver _webDriver;
    private WebDriverWait _webDriverWait;
    private Actions _actions;
    public string Url => _webDriver.Url;

    public void Start(BrowserType browser)
    {
        switch (browser)
        {
            case BrowserType.CHROME:
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                _webDriver = new ChromeDriver();
                break;
            case BrowserType.FIREFOX:
                new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                _webDriver = new FirefoxDriver();
                break;
            case BrowserType.EDGE:
                new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                _webDriver = new EdgeDriver();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
        }

        _webDriver.Manage().Window.Maximize();
        _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT));
    }

    public void Quit()
    {
        _webDriver.Quit();
    }

    public void GoToUrl(string url)
    {
        _webDriver.Navigate().GoToUrl(url);
    }

    public IComponent FindComponent(By locator)
    {
        IWebElement nativeWebElement = _webDriverWait.Until(ExpectedConditions.ElementExists(locator));
        IComponent element = new ComponentAdapter(_webDriver, nativeWebElement, locator);
        ScrollIntoView(element);
  
        return element;
    }

    public List<IComponent> FindComponents(By locator)
    {
        ReadOnlyCollection<IWebElement> nativeWebElements = _webDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        var elements = new List<IComponent>();

        foreach (var nativeWebElement in nativeWebElements)
        {
            IComponent element = new ComponentAdapter(_webDriver, nativeWebElement, locator);
            elements.Add(element);
        }

        return elements;
    }

   
    public void Refresh()
    {
        _webDriver.Navigate().Refresh();
    }

    public bool ComponentExists(IComponent component)
    {
        try
        {
            _webDriver.FindElement(component.By);

            return true;
        }
        catch
        {
           
            return false;
        }
    }

    public void DeleteAllCookies()
    {
        _webDriver.Manage().Cookies.DeleteAllCookies();
    }

    public void ExecuteScript(string script, params object[] args)
    {
        ((IJavaScriptExecutor)_webDriver).ExecuteScript(script, args);
    }

    public void WaitForAjax()
    {
        _webDriverWait.Until(driver =>
        {
            var script = "return window.jQuery != undefined && jQuery.active == 0";
            return (bool)((IJavaScriptExecutor)driver).ExecuteScript(script);
        });
    }

    public IComponent ScrollToTheElement(IComponent element)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;
        js.ExecuteScript("arguments[0].scrollIntoView();", element);
        return element;
    }


    private void ScrollIntoView(IComponent element)
    {
        ExecuteScript("arguments[0].scrollIntoView(true);", element.WrappedElement);
    }


    public IComponent WaitAndFindElementJS(By locator)
    {
        IWebElement nativeWebElement = _webDriverWait.Until(ExpectedConditions.ElementExists(locator));
        IComponent element = new ComponentAdapter(_webDriver, nativeWebElement, locator);
        ScrollIntoView(element);

        return element;
    }
    public IComponent WaitToBeClickable(By locator)
    {
        var nativeWebElement = _webDriverWait.Until(ExpectedConditions.ElementToBeClickable(locator));
        IComponent element = new ComponentAdapter(_webDriver, nativeWebElement, locator);

        ScrollIntoView(element);

        return element;
    }



    private void HighlightElement(IComponent element)
    {
        try
        {
           
            var originalElementBackground = element.WrappedElement.GetCssValue("background");
            var originalElementColor = element.WrappedElement.GetCssValue("color");
            var originalElementOutline = element.WrappedElement.GetCssValue("outline");

           
            var script = @"
                let defaultBG = arguments[0].style.backgroundColor;
                let defaultOutline = arguments[0].style.outline;
                arguments[0].style.backgroundColor = '#FDFF47';
                arguments[0].style.outline = '#f00 solid 2px';

                setTimeout(function()
                {
                    arguments[0].style.backgroundColor = defaultBG;
                    arguments[0].style.outline = defaultOutline;
                }, 500);";

            ExecuteScript(script, element.WrappedElement);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
