using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Safari;

namespace BlueHostingLogin;
public enum BrowserType
{
    CHROME,
    FIREFOX,
    EDGE,
    SAFARI
}

public class BrowserManager
{

    public static WebDriver StartBrowser(BrowserType browserType)
    {

        switch (browserType)
        {
            case BrowserType.CHROME:
                ChromeOptions chromeOptions = new ChromeOptions();
                return new ChromeDriver(chromeOptions);
            case BrowserType.FIREFOX:
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                return new FirefoxDriver(firefoxOptions);
            case BrowserType.EDGE:
                EdgeOptions edgeOptions = new EdgeOptions();
                return new EdgeDriver(edgeOptions);
                // case BrowserType.SAFARI:
                //     SafariOptions safariOptions = new SafariOptions();
                //     return new SafariDriver(safariOptions);
        }
        return null;
    }
}
