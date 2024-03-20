using EcommerceLambdaProject.Pages.BasePage;
using OpenQA.Selenium;

namespace EcommerceLambdaProject.Pages.SearchPage;
public partial class SearchPage : WebPage
{
    public SearchPage(IWebDriver driver) : base(driver)
    {
    }

    protected override string Url => "https://ecommerce-playground.lambdatest.io/index.php?route=product%2Fsearch&search=";
}
