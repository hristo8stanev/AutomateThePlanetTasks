﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumWebdriverHelpers;
using ZipCodes.Pages.SearchPage;
using ZipCodes.Pages.ZipCodeMainPage;
using static System.Net.Mime.MediaTypeNames;

namespace ZipCodes.Test.Core.BaseTest;
public class AdvanceSearchTests : BaseTest
{

    [Test]
    public void AdvanceSearchCityNameZipCode()
    {
        _zipCodeMainPage.GoTo();
        _zipCodeMainPage.AdvanceSearch();
        _searchPage.ProceedToAdvanceSearch();
        _searchPage.AcceptCookies();
        _searchPage.AssertSearchPageIsShown(_driver.Url);
        _searchPage.SearchTownByName("H");
        _searchPage.AssertOAdvanceSearchedUrl(_driver.Url);

        //  Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
        //  ss.SaveAsFile(@"C:\Users\UsernameT\Downloads\City.jpg"
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
                    
                    string cityName = _driver.FindElement(By.XPath("//*[@aria-label='Enter City']")).GetAttribute("value");
                    string state = _driver.FindElement(By.XPath("//*[@aria-label='State Abbr']")).GetAttribute("value");
                    string zipCode = _driver.FindElement(By.XPath("(.//a[contains(@href, '/zip-code/')][1])")).Text;
                    string longitudeAndLatitude = _driver.FindElement(By.XPath("(//*[@class='striped']//td)[18]")).GetText();

                    string[] coordinates = longitudeAndLatitude.Split(',');
                    string latitude = coordinates[0].Trim();
                    string longitude = coordinates[1].Trim();

                    
                    string googleMapsLink = $"https://www.google.com/maps?q={latitude},{longitude}";

                    cityDetailsList.Add(new CityDetails(cityName, state, zipCode, longitudeAndLatitude, googleMapsLink));

                    
                    ((IJavaScriptExecutor)_driver).ExecuteScript($"window.open('{googleMapsLink}', '_blank');");
                   

                    //ACCEPT GOOGLE COOOKIE

                    _driver.SwitchTo().Window(_driver.WindowHandles.Last());

                   
                    Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
                    ss.SaveAsFile($"C:\\Users\\UsernameT\\Downloads\\{cityName}-{state}-{zipCode}.jpg");

                    
                    _driver.Close();

                    
                    _driver.SwitchTo().Window(_driver.WindowHandles.First());

                   
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