using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ZipCodes.Pages.SearchPage;
using ZipCodes.Pages.ZipCodeMainPage;
using static System.Net.Mime.MediaTypeNames;

namespace ZipCodes.Test.Core.BaseTest;
public class AdvanceSearchTests : BaseTest
{

    string CityName;
    string State;
    string ZipCode;
    string Longitude;
    string Latitude;

    [Test]
    public void AdvanceSearchFOr()
    {
        _zipCodeMainPage.GoTo();
        _zipCodeMainPage.AdvanceSearch();
        _searchPage.ProceedToAdvanceSearch();
        _searchPage.AcceptCookies();
        _searchPage.AssertSearchPageIsShown(_driver.Url);
        _searchPage.SearchTownByName("H");
        //  _searchPage.AssertOAdvanceSearchedUrl(_driver.Url);
        //  _searchPage.ChooseCity();
        //  _searchPage.SaveInformationAboutCities();
        //  Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
        //  ss.SaveAsFile(@"C:\Users\UsernameT\Downloads\City.jpg")
        //       var FieldCity = _driver.FindElement(By.XPath("(//table[@class='striped']//td[2])[9]")).Text;
        //       Console.WriteLine($"Longtitude and Latitude: {FieldCity}");
        //   var elemTable = _driver.FindElement(By.XPath("//*[@id='tblZIP'][1]"));
        //


        
        try
        {
           
            IWebElement table = _driver.FindElement(By.Id("tblZIP"));

          
            IList<IWebElement> rows = table.FindElements(By.TagName("tr"));

           
            List<string> first10ResultUrls = new List<string>();
            List<CityDetails> cityDetailsList = new List<CityDetails>();

           
            for (int i = 1; i < Math.Min(11, rows.Count); i++) { 
                IList<IWebElement> links = rows[i].FindElements(By.XPath(".//a[contains(@href, '/city/')]"));

                
                if (links.Count > 0)
                {
                   
                    string url = links[0].GetAttribute("href");
                    first10ResultUrls.Add(url);

                   
                    links[0].Click();

                  
                    string cityName = _driver.FindElement(By.XPath("//*[@aria-label='Enter City']")).Text;
                    string state = _driver.FindElement(By.XPath("//*[@aria-label='State Abbr']")).Text;
                    string zipCode = _driver.FindElement(By.XPath("(.//a[contains(@href, '/zip-code/')][1])")).Text;
                    string longitudeAndLatitude = _driver.FindElement(By.XPath("//span[contains(@class, 'dT') and contains(., 'Coordinates')]")).Text;

                   
                    cityDetailsList.Add(new CityDetails(cityName, state, zipCode, longitudeAndLatitude));
                    _driver.Navigate().Back();
                    table = _driver.FindElement(By.Id("tblZIP"));
                    rows = table.FindElements(By.TagName("tr"));
                }
            }

            Console.WriteLine("City Details:");
            foreach (CityDetails cityDetails in cityDetailsList)
            {
                Console.WriteLine(cityDetails.ToString());
            }
        }
        finally
        {
            
            _driver.Quit();
        }
    }
}