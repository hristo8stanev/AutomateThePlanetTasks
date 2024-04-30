namespace EcommerceLambdaProject.Pages.BasePage;

public class WebSite
{
    private readonly IDriver _driver;

    public WebSite(IDriver driver)
    {
        _driver = driver;
        HomePage = new HomePage(_driver);
        CheckoutPage = new CheckoutPage(_driver);
        LoginPage = new LoginPage(_driver);
        ProductPage = new ProductPage(_driver);
        RegisterPage = new RegisterPage(_driver);
        SearchPage = new SearchPage(_driver);
        ShoppingCartPage = new ShoppingCartPage(_driver);
        MyAccountPage = new MyAccountPage(_driver);
        SuccessfulPage = new SuccessfulPage(_driver);
        MainHeader = new MainHeader(_driver);

    }

    public HomePage HomePage { get; set; }
    public CheckoutPage CheckoutPage { get; private set; }
    public LoginPage LoginPage { get; private set; }
    public ProductPage ProductPage { get; set; }
    public RegisterPage RegisterPage { get; set; }
    public SearchPage SearchPage { get; set; }
    public ShoppingCartPage ShoppingCartPage { get; set; }
    public MyAccountPage MyAccountPage { get; set; }
    public SuccessfulPage SuccessfulPage { get; set; }
    public MainHeader MainHeader { get; set; }

}