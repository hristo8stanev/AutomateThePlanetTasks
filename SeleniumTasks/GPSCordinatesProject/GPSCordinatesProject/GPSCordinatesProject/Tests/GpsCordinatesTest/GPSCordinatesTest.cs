using GPSCordinatesProject.Test.Core.BaseTest;
using OpenQA.Selenium.DevTools.V120.Emulation;

namespace GPSCordinatesProject.Tests.GpsCordinatesTest;

public class GPSCordinatesTests : BaseTest
{
    

    [Test]
    public void Test1()
    {

      //  using var devToolssession = _driver.GetDevToolsSession();
      //  var domains = devToolssession.GetVersionSpecificDomain<DevToolsSessionDomains>();
      //  var timezoneOverrideSettings = new SetTimezoneOverrideCommandSettings();
      //  timezoneOverrideSettings.TimezoneId = "America/Sao_Paulo";
      //  domains.Emulation.SetLocaleOverride(SetLocaleOverrideSettings);

        _mainPage.GoTo();
        _mainPage.AcceptCookies();
        _mainPage.RegisterForm();
    }
}