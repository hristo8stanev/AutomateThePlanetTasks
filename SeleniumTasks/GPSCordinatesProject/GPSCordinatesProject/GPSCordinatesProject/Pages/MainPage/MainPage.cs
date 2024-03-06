using GPSCordinatesProject.Pages.BasePage;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using DevToolsSessionDomains = OpenQA.Selenium.DevTools.V122.DevToolsSessionDomains;
using SetGeolocationOverrideCommandSettings = OpenQA.Selenium.DevTools.V122.Emulation.SetGeolocationOverrideCommandSettings;

namespace GPSCordinatesProject.Pages.MainPage;
public partial class MainPage : WebPage
{
    public MainPage(IWebDriver driver)
        : base(driver)
    {
    }
    protected override string Url => "https://www.gps-coordinates.net/";


    public void AcceptCookies()
    {
         _driver.Manage().Cookies.AddCookie(new Cookie("__eoi", "ID=f8a8d2b19e5a7307:T=1708612288:RT=1708612288:S=AA-AfjbXKpjBh0_zCDqICA-KEzdi"));
         _driver.Manage().Cookies.AddCookie(new Cookie("__gads", "ID=cff0ebc0485cb786:T=1708612288:RT=1708612288:S=ALNI_MZKBzHIEijVqjkQl_cX6VNci-a8Qg"));
         _driver.Manage().Cookies.AddCookie(new Cookie("__gpi", "UID=00000d5f2df5b034:T=1708612288:RT=1708612288:S=ALNI_MYO_U8oDXsTw51iZZpzcJ3xb86oeA"));
         _driver.Manage().Cookies.AddCookie(new Cookie("_ga_MCB31SCPPD", "GS1.1.1708612271.1.0.1708612291.0.0.0"));
         _driver.Manage().Cookies.AddCookie(new Cookie("_gat_gtag_UA_27565784_1", "1"));
         _driver.Manage().Cookies.AddCookie(new Cookie("_ga", "GA1.1.1196358541.1708612272"));
         _driver.Manage().Cookies.AddCookie(new Cookie("_gid", "GA1.2.775861444.1708612272"));
         _driver.Manage().Cookies.AddCookie(new Cookie("CookieConsent", "{stamp:%27InPAWhWwiw/STJQh5fKsEdQ3mhmvUNVjOLBx3wdXSVrkJzdNNrMkyw==%27%2Cnecessary:true%2Cpreferences:true%2Cstatistics:true%2Cmarketing:true%2Cmethod:%27explicit%27%2Cver:1%2Cutc:1708612270736%2Cregion:%27bg%27}"));
         _driver.Manage().Cookies.AddCookie(new Cookie("FCCDCF", "%5Bnull%2Cnull%2Cnull%2C%5B%22CP6YZEAP6YZEAEsACBENAoEoAP_gAEPgACQwINJD7D7FbSFCwHpzaLsAMAhHRsCAQoQAAASBAmABQAKQIAQCgkAQFASgBAACAAAAICZBIQAECAAACUAAQAAAAAAEAAAAAAAIIAAAgAEAAAAIAAACAAAAEAAIAAAAEAAAmAgAAIIACAAAhAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAQOhQD2F2K2kKFkPCmQWYAQBCijYEAhQAAAAkCBIAAgAUgQAgFIIAgAIFAAAAAAAAAQEgCQAAQABAAAIACgAAAAAAIAAAAAAAQQAAAAAIAAAAAAAAEAAAAAAAQAAAAIAABEhCAAQQAEAAAAAAAQAAAAAAAAAAABAAA%22%2C%222~2072.70.89.93.108.122.149.196.2253.2299.259.2357.311.313.323.2373.338.358.2415.415.449.2506.2526.486.494.495.2568.2571.2575.540.574.2624.609.2677.864.981.1029.1048.1051.1095.1097.1126.1201.1205.1211.1276.1301.1344.1365.1415.1423.1449.1451.1570.1577.1598.1651.1716.1735.1753.1765.1870.1878.1889.1958~dv.%22%2C%229EF02629-B796-4315-B3E4-AEA799F32A38%22%5D%5D"));
         _driver.Manage().Cookies.AddCookie(new Cookie("FCNEC", "%5B%5B%22AKsRol9ltL6Lgfm5Or65xxojHB_N2o6sxVnPbAwiBz5U-hRBmUEzjqSuWAmnHGynVsnYH6vJf4t8U6QJy2bb0Y_MS2yHVxAeSnF3oWL0v0XA2CvWpbty59E7_XkOqq6jGdZUBskaPNaE4Y80-ufzO2RqgxUeQrfnnQ%3D%3D%22%5D%5D"));
         _driver.Navigate().Refresh();

    }

    public void SetGeolocation(double latitude, double longitude)
    {
        using var devToolsSession = ((IDevTools)_driver).GetDevToolsSession();
        var domains = devToolsSession.GetVersionSpecificDomains<DevToolsSessionDomains>();
        var emulation = domains.Emulation;

        var overrideSettings = new SetGeolocationOverrideCommandSettings
        {
            Latitude = latitude,
            Longitude = longitude,
            Accuracy = 1
        };
        emulation.SetGeolocationOverride(overrideSettings);
    }

    public void GetTheCurrentAddress()
    {
        MoveToElement(AddressField);
        var currentAddress = AdressTitle.Text;
    }

    public void ScrollToTheGpsAddress()
    {
        MoveToElement(GpsField);
        _driver.Navigate().Refresh();
    }

    public void ScrollToTheAddress()
    {
        MoveToElement(AddressField);
        
    }
}
