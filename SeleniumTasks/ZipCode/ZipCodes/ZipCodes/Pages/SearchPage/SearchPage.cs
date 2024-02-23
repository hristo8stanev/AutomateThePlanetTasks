using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ZipCodes.Pages.BasePage;
using static System.Net.Mime.MediaTypeNames;

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


    public void IterateBetweenTheCities()
    {
        IWebElement table = Driver.FindElement(By.Id("tblZIP"));
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

                string cityName = Driver.FindElement(By.XPath("//*[@aria-label='Enter City']")).GetAttribute("value");
                string state = Driver.FindElement(By.XPath("//*[@aria-label='State Abbr']")).GetAttribute("value");
                string zipCode = Driver.FindElement(By.XPath("(.//a[contains(@href, '/zip-code/')][1])")).Text;
                string longitudeAndLatitude = Driver.FindElement(By.XPath("(//*[@class='striped']//td)[18]")).Text;

                string[] coordinates = longitudeAndLatitude.Split(',');
                string latitude = coordinates[0].Trim();
                string longitude = coordinates[1].Trim();

                string googleMapsLink = $"https://www.google.com/maps?q={latitude},{longitude}";

                cityDetailsList.Add(new CityDetails(cityName, state, zipCode, longitudeAndLatitude, googleMapsLink));

                ((IJavaScriptExecutor)Driver).ExecuteScript($"window.open('{googleMapsLink}', '_blank');");
                Driver.SwitchTo().Window(Driver.WindowHandles.Last());

                if (!cookiesAcceptedForFirstCity)
                {
                    AcceptGoogleCookies();
                    cookiesAcceptedForFirstCity = true;
                }

                Thread.Sleep(1000);
                Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
                ss.SaveAsFile($"C:\\Users\\UsernameT\\Downloads\\{cityName}-{state}-{zipCode}.jpg");
                Driver.Close();
                Driver.SwitchTo().Window(Driver.WindowHandles.First());
                Driver.Navigate().Back();
                table = TableElement;
                rows = table.FindElements(By.TagName("tr"));

            }
        }
    }
}
