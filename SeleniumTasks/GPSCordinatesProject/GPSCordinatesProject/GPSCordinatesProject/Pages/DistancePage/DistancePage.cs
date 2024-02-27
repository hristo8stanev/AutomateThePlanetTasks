using GPSCordinatesProject.Pages.BasePage;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using DevToolsSessionDomains = OpenQA.Selenium.DevTools.V122.DevToolsSessionDomains;
using SetGeolocationOverrideCommandSettings = OpenQA.Selenium.DevTools.V122.Emulation.SetGeolocationOverrideCommandSettings;

namespace GPSCordinatesProject.Pages.DistancePage;
public partial class DistancePage : WebPage
{
    public DistancePage(IWebDriver driver) : base(driver)
    {
    }

    protected override string Url => "https://www.gps-coordinates.net/distance";


    public void SwitchToDistancePage()
    {
        string gpsCoordinatesMainPage = $"https://www.gps-coordinates.net/distance";
        ((IJavaScriptExecutor)_driver).ExecuteScript($"window.open('{gpsCoordinatesMainPage}', '_blank');");
        _driver.SwitchTo().Window(_driver.WindowHandles.Last());
        _driver.Navigate().Refresh();
    }

    public void SetFirstAddress(string address1) => FirstLocation.SendKeys(address1);

    public void SetSecondAddress() => SecondLocation.SendKeys("Germany, Berlin");

    public void CalculateTheDistance()
    {
        ScrollToTheElement(By.XPath("//*[@id='address1']"));
        CalculateDistanceButton.Click();
    }
}
