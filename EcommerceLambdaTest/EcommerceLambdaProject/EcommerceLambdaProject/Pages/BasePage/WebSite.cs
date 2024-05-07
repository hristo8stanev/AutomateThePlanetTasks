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
        SuccessfulPage = new SuccessfulOrderPage(_driver);
        ForgotPasswordPage = new ForgotPasswordPage(driver);
        LogoutPage = new LogoutPage(_driver);
        ReturnProductPage = new ReturnProductPage(_driver);
        SuccessfulOrderPage = new SuccessfulOrderPage(driver);
        NewAddressBookPage = new NewAddressBookPage(_driver);
        NewAddressPage = new NewAddressPage(_driver);
        SuccessfulReturnProductPage = new SuccessfulReturnProductPage(_driver);
        SuccessfulVoucherPage = new SuccessfulVoucherPage(_driver);
        ComparisonPage = new ComparisonPage(_driver);
        WishListPage = new WishListPage(_driver);
        SuccessfulRegisterPage = new SuccessfulRegisterPage(_driver);
        SearchProductPriceRangePrice = new SearchProductPriceRangePrice(_driver);
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
    public ForgotPasswordPage ForgotPasswordPage { get; set; }
    public SuccessfulOrderPage SuccessfulPage { get; set; }
    public LogoutPage LogoutPage { get; set; }
    public ReturnProductPage ReturnProductPage { get; set; }
    public SuccessfulOrderPage SuccessfulOrderPage { get; set; }
    public NewAddressBookPage NewAddressBookPage { get; set; }
    public NewAddressPage NewAddressPage { get; set; }
    public SuccessfulReturnProductPage SuccessfulReturnProductPage { get; set; }
    public SuccessfulVoucherPage SuccessfulVoucherPage { get; set; }
    public MainHeader MainHeader { get; set; }
    public ComparisonPage ComparisonPage { get; set; }
    public WishListPage WishListPage { get;set; }
    public SuccessfulRegisterPage SuccessfulRegisterPage { get; set; }
    public SearchProductPriceRangePrice SearchProductPriceRangePrice { get; set; }
   
}