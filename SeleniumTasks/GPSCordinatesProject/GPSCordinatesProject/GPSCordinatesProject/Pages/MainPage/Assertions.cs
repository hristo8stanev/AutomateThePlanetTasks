using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumWebdriverHelpers;

namespace GPSCordinatesProject.Pages.MainPage;
public partial class MainPage
{
    private string ErrorMessageMap => "Map Address is not displayed";
    private string ErrorMessageCity => "Your expected City and Country is not displayed";
    private string ErrorMessageCordinates => "Your expected Longtitude and Latitude is not displayed";


    public void AssertCityAndCountryIsCorrect()
    {
        MoveToElement(By.XPath("//*[@id='address']"));
        string cityAndCountry = AdressTitle.Text;
        string[] coordinates = cityAndCountry.Split(',');
        string city = coordinates[2].Trim();
        string country = coordinates[3].Trim();
        Console.WriteLine($"{city},{country}");
        Assert.That(AdressTitle.Text.Contains($"{city}, {country}"), ErrorMessageCity);

    }
  
    public void AssertLongtitudeAndLatitudeIsCorrect()
    {

         
         Console.WriteLine(Cordinates.Text);
       
       // Console.WriteLine(Cordinates.GetText());
   
    }

    public void AssertMapIsDisplayed()
    {
        bool isMapDisplayed = Map.Displayed;
        Assert.That(isMapDisplayed, ErrorMessageMap);

    }
}
