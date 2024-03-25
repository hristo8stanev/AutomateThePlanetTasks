namespace EcommerceLambdaProject.Test.EcommerceTests;
public class CheckoutPageTests : BaseTest
{

    string emailAddress = "alabala@gmail.com";
    string password = "tester";
    string existingProduct = "Sony VAIO";
    string successfullyPurchaseMessage = "Your order has been placed!";

    [Test]
    public void Checkout_When_LoginUserTypeSelectedTest()
    {
        var billingDetails = Factories.CustomerFactory.BillingAddress();

        _driver.GoToUrl(Url.CHECKOUT_PAGE);
        _webSite.HomePage.SearchProductByName(existingProduct);
        _webSite.ProductPage.AddProductToCart(existingProduct);

        _driver.GoToUrl(Url.CHECKOUT_PAGE);
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Login);
        _webSite.CheckoutPage.LoginUser(emailAddress, password);

        _webSite.CheckoutPage.BillingDetails(billingDetails);
        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonIsDisplayed();
        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutTheOrder(successfullyPurchaseMessage);
        _webSite.CheckoutPage.AssertSuccessfullyCheckoutUrl(_driver.Url);
    }



    [Test]
    public void Checkout_When_RegisterTypeSelectedTest()
    { 
        var billingDetails = Factories.CustomerFactory.BillingAddress();
        var personalInformation = Factories.CustomerFactory.UserDetails();

        _driver.GoToUrl(Url.CHECKOUT_PAGE);
        _webSite.HomePage.SearchProductByName(existingProduct);
        _webSite.ProductPage.AddProductToCart(existingProduct);

        _driver.GoToUrl(Url.CHECKOUT_PAGE);
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Register);

        _webSite.CheckoutPage.CreateNewUserPayment(personalInformation);
        _webSite.CheckoutPage.BillingDetails(billingDetails);
        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonIsDisplayed();
        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutTheOrder(successfullyPurchaseMessage);
        _webSite.CheckoutPage.AssertSuccessfullyCheckoutUrl(_driver.Url);
    }


    [Test]
    public void Checkout_When_GuestTypeSelectedTest()
    {
        var billingDetails = Factories.CustomerFactory.BillingAddress();
        var personalInformation = Factories.CustomerFactory.UserDetails();

        _driver.GoToUrl(Url.CHECKOUT_PAGE);
        _webSite.HomePage.SearchProductByName(existingProduct);
        _webSite.ProductPage.AddProductToCart(existingProduct);

        _driver.GoToUrl(Url.CHECKOUT_PAGE);
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Guest);
        _webSite.CheckoutPage.GuesUserPayment(personalInformation);
        _webSite.CheckoutPage.BillingDetails(billingDetails);
        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonIsDisplayed();
        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutTheOrder(successfullyPurchaseMessage);
        _webSite.CheckoutPage.AssertSuccessfullyCheckoutUrl(_driver.Url);
    }
}