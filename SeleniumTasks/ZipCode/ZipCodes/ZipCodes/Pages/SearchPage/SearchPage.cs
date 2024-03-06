using OpenQA.Selenium;
using ZipCodes.Pages.BasePage;

namespace ZipCodes.Pages.SearchPage;
public partial class SearchPage : WebPage
{
    bool cookiesAcceptedForFirstCity = false;

    public SearchPage(IWebDriver driver)
        : base(driver)
    {
    }

    protected override string Url => "https://www.zip-codes.com/search.asp";

    public void ProceedToAdvanceSearch()
    {
        AdvanceSearchButton.Click();

    }

    public void AcceptCookies()
    {
        
        AcceptCookie.Click();
    }

    public void AcceptGoogleCookies()
    {
        consentForm.FindElement(By.XPath("(//*[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc LQeN7 XWZjwc'])[2]"));
        AcceptGoogleCookie.Click();
    }
   

    public void SearchTownByName(string name)
    {
        CityField.SendKeys(name);
        searchField.Click();
    }


    //public void IterateBetweenTheCities()
    //{
    //    IWebElement table = _driver.FindElement(By.Id("tblZIP"));
    //    IList<IWebElement> rows = table.FindElements(By.TagName("tr"));
    //    List<string> first10ResultUrls = new List<string>();
    //    List<CityDetails> cityDetailsList = new List<CityDetails>();
    //
    //    for (int i = 1; i < Math.Min(11, rows.Count); i++)
    //    {
    //        IList<IWebElement> links = rows[i].FindElements(By.XPath(".//a[contains(@href, '/city/')]"));
    //
    //        if (links.Count > 0)
    //        {
    //            string url = links[0].GetAttribute("href");
    //            first10ResultUrls.Add(url);
    //            links[0].Click();
    //
    //            string cityName = _driver.FindElement(By.XPath("//*[@aria-label='Enter City']")).GetAttribute("value");
    //            string state = _driver.FindElement(By.XPath("//*[@aria-label='State Abbr']")).GetAttribute("value");
    //            string zipCode = _driver.FindElement(By.XPath("(.//a[contains(@href, '/zip-code/')][1])")).Text;
    //            string longitudeAndLatitude = _driver.FindElement(By.XPath("//*[@class='striped']//td[.//span[contains(text(), 'Coordinates')]]//following-sibling::td")).Text;
    //
    //            string[] coordinates = longitudeAndLatitude.Split(',');
    //            string latitude = coordinates[0].Trim();
    //            string longitude = coordinates[1].Trim();
    //
    //            string googleMapsLink = $"https://www.google.com/maps?q={latitude},{longitude}";
    //
    //            cityDetailsList.Add(new CityDetails(cityName, state, zipCode, longitudeAndLatitude, googleMapsLink));
    //
    //            ((IJavaScriptExecutor)_driver).ExecuteScript($"window.open('{googleMapsLink}', '_blank');");
    //            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
    //
    //            if (!cookiesAcceptedForFirstCity)
    //            {
    //                AcceptGoogleCookies();
    //                cookiesAcceptedForFirstCity = true;
    //            }
    //
    //            Thread.Sleep(1000);
    //            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
    //            ss.SaveAsFile($"C:\\Users\\UsernameT\\Downloads\\{cityName}-{state}-{zipCode}.jpg");
    //            _driver.Close();
    //            _driver.SwitchTo().Window(_driver.WindowHandles.First());
    //            _driver.Navigate().Back();
    //            table = TableElement;
    //            rows = table.FindElements(By.TagName("tr"));
    //
    //        }
    //    }
    //}

    public void IterateBetweenTheCities()
    {
        IWebElement table = _driver.FindElement(By.Id("tblZIP"));
        IList<IWebElement> rows = table.FindElements(By.TagName("tr"));
        List<string> first10ResultUrls = new List<string>();
        List<CityDetails> cityDetailsList = new List<CityDetails>();

        for (int i = 1; i < Math.Min(11, rows.Count); i++)
        {
            IList<IWebElement> links = rows[i].FindElements(By.XPath(".//a[contains(@href, '/city/')]"));

            if (links.Count > 0)
            {
                string url = links[0].GetAttribute("href");
                first10ResultUrls.Add(url);
                links[0].Click();
                CityDetails cityDetails = GetCityDetails();
                SaveScreenshot(cityDetails);
                cityDetailsList.Add(cityDetails);
                GoBackToTable();
                table = TableElement;
                rows = table.FindElements(By.TagName("tr"));
            }
        }
    }

    public CityDetails GetCityDetails()
    {
        string cityName = _driver.FindElement(By.XPath("//*[@aria-label='Enter City']")).GetAttribute("value");
        string state = _driver.FindElement(By.XPath("//*[@aria-label='State Abbr']")).GetAttribute("value");
        string zipCode = _driver.FindElement(By.XPath("(.//a[contains(@href, '/zip-code/')][1])")).Text;
        string longitudeAndLatitude = _driver.FindElement(By.XPath("//*[@class='striped']//td[.//span[contains(text(), 'Coordinates')]]//following-sibling::td")).Text;

        string[] coordinates = longitudeAndLatitude.Split(',');
        string latitude = coordinates[0].Trim();
        string longitude = coordinates[1].Trim();

        string googleMapsLink = $"https://www.google.com/maps?q={latitude},{longitude}";

        return new CityDetails(cityName, state, zipCode, longitudeAndLatitude, googleMapsLink);
    }

    public void SaveScreenshot(CityDetails cityDetails)
    {
        ((IJavaScriptExecutor)_driver).ExecuteScript($"window.open('{cityDetails.GoogleMapsLink}', '_blank');");
        _driver.SwitchTo().Window(_driver.WindowHandles.Last());
        if (!cookiesAcceptedForFirstCity)
        {
            AcceptGoogleCookies();
            cookiesAcceptedForFirstCity = true;
        }
        Thread.Sleep(1000);
        Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
        ss.SaveAsFile($"C:\\Users\\UsernameT\\Downloads\\{cityDetails.CityName}-{cityDetails.State}-{cityDetails.ZipCode}.jpg");
        _driver.Close();
        _driver.SwitchTo().Window(_driver.WindowHandles.First());
    }

    public void GoBackToTable()
    {
        _driver.Navigate().Back();
    }

}
