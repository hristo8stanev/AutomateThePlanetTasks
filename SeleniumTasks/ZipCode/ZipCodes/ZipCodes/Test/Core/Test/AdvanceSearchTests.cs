using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
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
    public void Test1()
    {
        _zipCodeMainPage.GoTo();
        _zipCodeMainPage.AdvanceSearch();
        _searchPage.ProceedToAdvanceSearch();
        _searchPage.AcceptCookies();
        _searchPage.SearchTownByName("H");
        _searchPage.AssertOAdvanceSearchedUrl(_driver.Url);
        _searchPage.ChooseFirstCity();
        var FieldCity = _driver.FindElement(By.XPath("(//table[@class='striped']//td[2])[9]")).Text;
        Console.WriteLine($"Longtitude and Latitude: {FieldCity}");

     
    }
}