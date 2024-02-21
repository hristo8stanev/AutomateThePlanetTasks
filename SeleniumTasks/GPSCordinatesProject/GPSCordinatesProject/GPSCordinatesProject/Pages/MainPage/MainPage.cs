using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPSCordinatesProject.Pages.BasePage;
using OpenQA.Selenium;

namespace GPSCordinatesProject.Pages.MainPage;
public partial class MainPage : WebPage
{
    public MainPage(IWebDriver driver)
        : base(driver)
    {
    }
    protected override string Url => "https://www.gps-coordinates.net/";

}
