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
    public void AdvanceSearchFOr()
    {
        _zipCodeMainPage.GoTo();
        _zipCodeMainPage.AdvanceSearch();
        _searchPage.ProceedToAdvanceSearch();
        _searchPage.AcceptCookies();
        _searchPage.AssertSearchPageIsShown(_driver.Url);
        _searchPage.SearchTownByName("H");
        _searchPage.AssertOAdvanceSearchedUrl(_driver.Url);
        _searchPage.ChooseCity();
        _searchPage.SaveInformationAboutCities();


        Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
        ss.SaveAsFile(@"C:\Users\UsernameT\Downloads\City.jpg");

        //     var FieldCity = _driver.FindElement(By.XPath("(//table[@class='striped']//td[2])[9]")).Text;
        //     Console.WriteLine($"Longtitude and Latitude: {FieldCity}");
        // var elemTable = _driver.FindElement(By.XPath("//*[@id='tblZIP'][1]"));
        //
        // // Fetch all Row of the table
        // List<IWebElement> tr = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));
        //
        // string strRowData = "";
        //
        // // Traverse each row
        // foreach (var elemTr in tr)
        // {
        //     // Fetch the columns from a particuler row
        //     List<IWebElement> td = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));
        //
        //     if (td.Count > 0)
        //     {
        //         // Traverse each column
        //         foreach (var elemTd in td)
        //         {
        //             // "\t\t" is used for Tab Space between two Text
        //             strRowData = strRowData + elemTd.Text + "\t\t";
        //         }
        //     }
        //     else
        //     {
        //         // To print the data into the console
        //         Console.WriteLine("This is Header Row");
        //         Console.WriteLine(tr[0].Text.Replace(" ", "\t\t"));
        //     }
        //     Console.WriteLine(strRowData);
        //     strRowData = string.Empty;
        // }
        // Console.WriteLine("");
        // _driver.Quit();
    }
}