using OpenQA.Selenium;

namespace EcommerceLambdaProject.Pages.RegisterPage;
public partial class ProductPage : WebPage
{
    public ProductPage(IWebDriver driver) : base(driver)
    {
    }

    protected override string Url => "https://ecommerce-playground.lambdatest.io/index.php?route=account/register";
}
