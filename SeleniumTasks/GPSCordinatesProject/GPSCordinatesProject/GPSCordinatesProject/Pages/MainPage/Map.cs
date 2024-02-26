using OpenQA.Selenium;

namespace GPSCordinatesProject.Pages.MainPage;
public partial class MainPage
{

    public IWebElement AdressTitle => WaitAndFindElementJS(By.XPath("//*[@id='iwtitle']"));
    public IWebElement AddressCordinates => WaitAndFindElementJS(By.XPath("(//*[@class='btn btn-primary'])[1]"));
    public IWebElement Cordinates => WaitAndFindElementJS(By.XPath("//*[@id='iwcontent']"));
    public IWebElement Map => WaitAndFindElementJS(By.XPath("//*[@id='map_canvas']"));
    public IWebElement Latitude => WaitAndFindElementJS(By.XPath("//*[@id='latitude']"));
    public IWebElement Longtitude => WaitAndFindElementJS(By.XPath("//*[@id='longitude']"));
}
