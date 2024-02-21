using System;
using System.Collections.Generic;
using System.Linq;
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
        acceptCookie.Click();
    }

    public void AcceptGoogleCookies()
    {
        acceptCookie.Click();
    }
    public void SearchTownByName(string name)
    {
        CityField.SendKeys(name);
        searchField.Click();
    }

    public void ChooseCity()
    {
        var name = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//table[@id='tblZIP']//tr[2]//td[2]//a"))).Text;
        var state = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//table[@id='tblZIP']//tr[2]//td[3]//a"))).Text;
        var zipCode = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//table[@id='tblZIP']//tr[2]//td[1]//a"))).Text;
        Console.WriteLine($"Name: '{name}'\n" + $"ZipCode: '{zipCode}'\n" + $"State: '{state}'");
        FirstCity.Click();
    }

    public void SaveInformationAboutCities()
    {
       
        var longtitudeAndlatitude = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//table[@class='striped']//td[2])[9]"))).Text;
        Console.WriteLine($"Longtitute and Longtitude: '{longtitudeAndlatitude}'");


    }
}
    


