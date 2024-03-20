

namespace EcommerceLambdaProject.Test.EcommerceTests;
public class CheckoutPageTests : BaseTest
{

    [Test]
    public void CheckoutTests()
    {
        _driver.GoToUrl(Url.CHECKOUT_PAGE);
        
    }
}
