using OpenQA.Selenium;

namespace GPSCordinatesProject.Pages.DistancePage;
public partial class DistancePage
{
   
    public IWebElement FirstLocation => WaitAndFindElementJS(By.XPath("//*[@id='address1']"));
    public string Address1 => "//*[@id='address1']";
    public string Distance => "//*[@id='distance']";
    public IWebElement SecondLocation => WaitAndFindElementJS(By.XPath("//*[@id='address2']"));
    public IWebElement CalculateDistanceButton => WaitAndFindElement(By.XPath("//*[@class='col-md-4']//*[@class='btn btn-success']"));
    public IWebElement DistanceElement => WaitAndFindElementJS(By.XPath("//*[@id='distance']"));
    public string DistanceField => "//*[@id='distance']";
}
