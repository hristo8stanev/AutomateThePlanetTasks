

namespace EcommerceLambdaProject.Test.EcommerceTests;
public class HomePageTests : BaseTest
{

    [Test]
    public void HomePage()
    {
        _driver.GoToUrl(Url.BASE_URL);
    }
}
