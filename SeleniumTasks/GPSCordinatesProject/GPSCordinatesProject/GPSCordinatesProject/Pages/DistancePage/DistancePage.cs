using GPSCordinatesProject.Pages.BasePage;
using OpenQA.Selenium;

namespace GPSCordinatesProject.Pages.DistancePage;
public partial class DistancePage : WebPage
{
    private string SetCountries => "Germany, Berlin";

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

    public void SetSecondAddress() => SecondLocation.SendKeys(SetCountries);

    public void CalculateTheDistance()
    {
        ScrollToTheElement(FirstLocation);
        CalculateDistanceButton.Click();
    }
}
