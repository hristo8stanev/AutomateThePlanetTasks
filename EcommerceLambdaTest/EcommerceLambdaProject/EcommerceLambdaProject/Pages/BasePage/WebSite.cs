using EcommerceLambdaProject.Pages.CheckoutPage;
using EcommerceLambdaProject.Pages.ProductPage;
using EcommerceLambdaProject.Pages.HomePage;
using EcommerceLambdaProject.Pages.LoginPage;
using EcommerceLambdaProject.Pages.RegisterPage;
using EcommerceLambdaProject.Pages.SearchPage;
using EcommerceLambdaProject.Pages.ShoppingCartPage;
using EcommerceLambdaProject.Pages.MyAccountPage;
using EcommerceLambdaProject.Factories;

namespace EcommerceLambdaProject.Pages.BasePage;
public class WebSite
{
    private readonly IDriver _driver;
    
    public WebSite(IDriver driver)
    {
        _driver = driver;

        HomePage = new HomePages(_driver);
        CheckoutPage = new CheckoutPages(_driver);
        LoginPage = new LoginPages(_driver);
        ProductPage = new ProductPages(_driver);
        RegisterPage = new RegisterPages(_driver);
        SearchPage = new SearchPages(_driver);
        ShoppingCartPage = new ShoppingCartPages(_driver);
        MyAccountPage = new MyAccountPages(_driver);

    }

    public HomePages HomePage { get; set; }
    public CheckoutPages CheckoutPage { get; private set; }
    public LoginPages LoginPage { get; private set; }
    public ProductPages ProductPage { get; set; }
    public RegisterPages RegisterPage { get; set; }
    public SearchPages SearchPage { get; set; }
    public ShoppingCartPages ShoppingCartPage { get; set; }
    public MyAccountPages MyAccountPage { get; set; }
    
}
