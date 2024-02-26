using OpenQA.Selenium;

namespace GPSCordinatesProject.Pages.DistancePage;
public partial class DistancePage
{


    public IWebElement FirstLocation => WaitAndFindElementJS(By.XPath("//*[@id='address1']"));
    public IWebElement SecondLocation => WaitAndFindElementJS(By.XPath("//*[@id='address2']"));
    public IWebElement CalculateDistanceButton => WaitAndFindElementJS(By.XPath("//*[@class='btn btn-success']"));
    public IWebElement DistanceElement => WaitAndFindElementJS(By.XPath("//*[@id='distance']"));
}
