using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPSCordinatesProject.Test.Core.BaseTest;

namespace GPSCordinatesProject.Tests.DistanceTests;
public class CalculateTheDistanceBetweenToCities : BaseTest
{

    [Test]
    public void CalculateDistanceBetweenToCity()
    {

        _distancePage.GoTo();
        _mainPage.AcceptCookies();
        _distancePage.AssertDistanceUrlIsShown(_driver.Url);

    }


}
