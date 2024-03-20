using OpenQA.Selenium;

namespace EcommerceLambdaProject.Pages.ShoppingCartPage;
public partial class ShoppingCartPage : WebPage
{
    public ShoppingCartPage(IWebDriver driver) : base(driver)
    {
    }

    protected override string Url => "https://ecommerce-playground.lambdatest.io/index.php?route=checkout/cart";
}
