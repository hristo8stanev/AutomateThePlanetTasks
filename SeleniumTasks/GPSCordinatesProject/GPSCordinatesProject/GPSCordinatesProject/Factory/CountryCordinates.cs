using GPSCordinatesProject.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using DevToolsSessionDomains = OpenQA.Selenium.DevTools.V122.DevToolsSessionDomains;
using SetGeolocationOverrideCommandSettings = OpenQA.Selenium.DevTools.V122.Emulation.SetGeolocationOverrideCommandSettings;

namespace GPSCordinatesProject.Factory;
public class CountryCordinates : IGeolocation
{
    protected IWebDriver _driver;

    public string Country { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public CountryCordinates(string country, double latitude, double longtitude)
    {
        Country = country;
        Latitude = latitude;
        Longitude = longtitude;
    }


    public void setGeoLocation(double latitude, double longitude)
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
}
