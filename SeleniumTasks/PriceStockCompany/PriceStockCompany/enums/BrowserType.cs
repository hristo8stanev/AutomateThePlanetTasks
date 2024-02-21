using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace PriceStockCompany.enums;
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
}
