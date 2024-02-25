using GPSCordinatesProject.Test.Core.BaseTest;
using OpenQA.Selenium.DevTools.V120.Emulation;
using OpenQA.Selenium;
namespace SeleniumDocs.Bidirectional.ChromeDevtools
{

    public class GPSCordinatesTests : BaseTest
    {
        [Test]
        public void RunningFromDifferentLocation_When_DifferentCountyIsEntered()
        {

            _mainPage.GoTo();
            _mainPage.AcceptCookies();
            _mainPage.ScrooToTheAddress();
            _mainPage.AssertCityAndCountryIsCorrect();
            _mainPage.AssertLongtitudeAndLatitudeIsCorrect();
            _mainPage.AssertMapIsDisplayed();
          
        }
    }
}