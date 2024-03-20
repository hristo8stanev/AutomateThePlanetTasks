
using OpenQA.Selenium;

namespace EcommerceLambdaProject.Pages.HomePage;
public partial class HomePage : WebPage
{
    public HomePage(IWebDriver driver) : base(driver)
    {
    }

    protected override string Url => "https://ecommerce-playground.lambdatest.io/";
}

    
