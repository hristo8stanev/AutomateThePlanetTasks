using WebDriverManager.Helpers;
using WebDriverManager;

namespace EcommerceLambdaProject.Test.Core;

[TestFixture]
[AllureNUnit]
public class BaseTest
{

    protected IDriver _driver;
    protected WebSite _webSite;

    [SetUp]
    public void TestInit()
    {

        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _driver = new DriverAdapter();
        _driver.Start(BrowserType.CHROME);
        _driver.DeleteAllCookies();
        _webSite = new WebSite(_driver);
        
    }

    [TearDown]
    public void TestCleanup()
    {
        _driver.Quit();
    }
}