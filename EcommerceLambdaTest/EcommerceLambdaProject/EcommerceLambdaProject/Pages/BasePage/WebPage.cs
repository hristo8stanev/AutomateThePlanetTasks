using OpenQA.Selenium.Support.UI;

namespace EcommerceLambdaProject.Pages.BasePage;
public abstract class WebPage
{
    protected readonly IDriver Driver;


    public WebPage(IDriver driver)
    {
        Driver = driver;
    }
}
