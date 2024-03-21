
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
        _driver = new DriverAdapter();
        _driver.Start(BrowserType.CHROME);
        _webSite = new WebSite(_driver);
    }

    [TearDown]
    public void TestCleanup()
    {
        _driver.Quit();
    }
}
