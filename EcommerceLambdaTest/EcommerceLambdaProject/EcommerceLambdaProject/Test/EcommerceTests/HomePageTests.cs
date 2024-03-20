using EcommerceLambdaProject.Urls;

namespace EcommerceLambdaProject.Test.EcommerceTests;
public class HomePageTests : BaseTest
{
    [Test]
    public void HomePage()
    {
        _driver.GoToUrl(BASE_URL);
        

    }
}
