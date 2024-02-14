﻿using System;
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
    CHROME_INCOGNITO,
    CHROME_PRIVATE,
    CHROME_HEADLESS,
    FIREFOX,
    FIREFOX_PRIVATE,
    FIREFOX_HEADLESS,
    EDGE,
    EDGE_PRIVATE,
    EDGE_HEADLESS,
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
            case BrowserType.CHROME_INCOGNITO:
                ChromeOptions chromeIncognitoOptions = new ChromeOptions();
                chromeIncognitoOptions.AddArguments("--incognito");
                return new ChromeDriver(chromeIncognitoOptions);
            case BrowserType.CHROME_PRIVATE:
                ChromeOptions chromePrivateOptions = new ChromeOptions();
                chromePrivateOptions.AddArguments("--private");
                return new ChromeDriver(chromePrivateOptions);
            case BrowserType.CHROME_HEADLESS:
                ChromeOptions chromeHeadlessOptions = new ChromeOptions();
                chromeHeadlessOptions.AddArguments("--headless");
                return new ChromeDriver(chromeHeadlessOptions);
            case BrowserType.FIREFOX:
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                return new FirefoxDriver(firefoxOptions);
            case BrowserType.FIREFOX_PRIVATE:
                FirefoxOptions firefoxPrivateOptions = new FirefoxOptions();
                firefoxPrivateOptions.AddArguments("--private");
                return new FirefoxDriver(firefoxPrivateOptions);
            case BrowserType.FIREFOX_HEADLESS:
                FirefoxOptions firefoxHeadlessOptions = new FirefoxOptions();
                firefoxHeadlessOptions.AddArguments("--headless");
                return new FirefoxDriver(firefoxHeadlessOptions);
            case BrowserType.EDGE:
                EdgeOptions edgeOptions = new EdgeOptions();
                return new EdgeDriver(edgeOptions);
            case BrowserType.EDGE_PRIVATE:
                EdgeOptions edgePrivateOptions = new EdgeOptions();
                edgePrivateOptions.AddArguments("--private");
                return new EdgeDriver(edgePrivateOptions);
            case BrowserType.EDGE_HEADLESS:
                EdgeOptions edgeHeadlessOptions = new EdgeOptions();
                edgeHeadlessOptions.AddArguments("--headless");
                return new EdgeDriver(edgeHeadlessOptions);
                // case BrowserType.SAFARI:
                //     SafariOptions safariOptions = new SafariOptions();
                //     return new SafariDriver(safariOptions);
        }
        return null;
    }
}   
