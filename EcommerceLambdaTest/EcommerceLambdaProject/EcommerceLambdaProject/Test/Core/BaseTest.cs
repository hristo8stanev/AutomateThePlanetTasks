using EcommerceLambdaProject.Urls;
namespace EcommerceLambdaProject.Test.Core;
[TestFixture]
[AllureNUnit]
public class BaseTest
{

    //protected IWebDriver _driver;
    //private IDriver _driver;
    //
    //
    //protected RegisterPages _registerPage;
    //protected LoginPages LoginPage;
    //protected HomePage _homePage;
    //protected ProductPages _productPage;
    //protected CheckoutPage _checkoutPage;
    //protected ShoppingCartPages _shoppingCartPage;
    //protected SearchPage _searchPage;


    protected IDriver _driver;
    protected WebSite _webSite;

    [SetUp]
    public void TestInit()
    {
        _driver = new DriverAdapter();
        _driver.Start(BrowserType.CHROME);
        _webSite = new WebSite(_driver);
       
    }

    [TearDown]
    public void TestCleanup()
    {
        _driver.Quit();
    }



    // [SetUp]
    // public void Setup()
    // {
    //    // new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
    //    // _driver = StartBrowserService.StartBrowserService.StartBrowser(BrowserType.CHROME);
    //    // _driver.Manage().Window.Maximize();
    //
    //   //  _driver = new Driv
    //
    //   //_registerPage = new RegisterPages(_driver);
    //   //LoginPage = new LoginPages(_driver);
    //   //_homePage = new HomePage(_driver);
    //   //_productPage = new ProductPages(_driver);
    //   //_checkoutPage = new CheckoutPage(_driver);
    //
    // }
    //
    // [TearDown]
    // public void CleanUp()
    // {
    //
    //     _driver.Quit();
    //
    // }
}
