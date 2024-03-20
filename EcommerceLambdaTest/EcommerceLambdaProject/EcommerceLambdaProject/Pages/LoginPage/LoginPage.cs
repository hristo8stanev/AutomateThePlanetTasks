using OpenQA.Selenium;

namespace EcommerceLambdaProject.Pages.LoginPage;
public partial class LoginPage : WebPage
{
    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    protected override string Url => "https://ecommerce-playground.lambdatest.io/index.php?route=account/login"
}
