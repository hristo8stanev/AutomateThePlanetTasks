using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumWebdriverHelpers;

namespace GPSCordinatesProject.Pages.MainPage;
public partial class MainPage
{
    private string ErrorMessageMap => "Map Address is not displayed";
    private string ErrorMessageCity => "Your expected city is not correct";
    private string ErrorMessageCordinates => "Your Longtitude and Latitude is not correct";

  //  public void AssertCityAndCountryIsCorrect()
  //  {
  //      
  //      MoveToElement(By.XPath("//*[@id='address']"));
  //     
  //      Assert.That(AdressTitle.GetText().Contains("Buenos Aires, Argentina"), ErrorMessageCity);
  //      Console.WriteLine(AdressTitle.GetText());
  //
  //  }
  //
  //  public void AssertLongtitudeAndLatitudeIsCorrect()
  //  {
  //
  //      Assert.That(Cordinates.GetText().Contains("Latitude: -34.6037 | Longitude: -58.3816"), ErrorMessageCordinates);
  //      Console.WriteLine(Cordinates.GetText());
  //
  //  }

    public void AssertMapIsDisplayed()
    {
        bool isMapDisplayed = Map.Displayed;
        Assert.That(isMapDisplayed, ErrorMessageMap);

    }
}
