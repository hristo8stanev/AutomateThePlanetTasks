

namespace EcommerceLambdaProject.Test.EcommerceTests;
public class CheckoutPageTests : BaseTest
{

    string emailAddress = "alabala@gmail.com";
    string password = "tester";
    string existingProduct = "Ip";
    string successfullyPurchaseMessage = "Your order has been placed!";

    [Test]
    public void authenticatedUserCheckoutTest()
    {
        var loginUser = Factories.CustomerFactory.LoginUser(emailAddress, password);
        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(existingProduct);
        _webSite.ProductPage.AddProductToCart(existingProduct);

        _driver.GoToUrl(Url.CHECKOUT_PAGE);
        _webSite.CheckoutPage.ProceedToCheckout();
         
        _webSite.CheckoutPage.AssertConfirmButtonIsDisplayed();
        _webSite.CheckoutPage.ConfirmOrder();
      
        _webSite.CheckoutPage.AssertSuccessfullyCheckoutTheOrder(successfullyPurchaseMessage);
        _webSite.CheckoutPage.AssertSuccessfullyCheckoutUrl(_driver.Url);
    }
}
