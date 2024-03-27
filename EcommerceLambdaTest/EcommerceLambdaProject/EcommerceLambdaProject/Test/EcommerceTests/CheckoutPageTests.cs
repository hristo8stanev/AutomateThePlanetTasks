using EcommerceLambdaProject.Pages.ProductPage;

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

        var expectedProduct1 = new ProductDetails
        {
            Name = "Sony VAIO",
            Id = 46,
            UnitPrice = "$1,202.00",
            Model = "Product 19",
            Brand = "Sony",
            Quantity = "3",
        };


        var billingDetails = Factories.CustomerFactory.BillingAddress();

        _driver.GoToUrl(Url.CHECKOUT_PAGE);
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct1.Quantity);

        _driver.GoToUrl(Url.CHECKOUT_PAGE);
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Login);
        _webSite.CheckoutPage.LoginUser(emailAddress, password);

        _webSite.CheckoutPage.AssertUrlPage(Url.CHECKOUT_PAGE);

       // _webSite.CheckoutPage.AssertProductNameIsCorrect(expectedProduct1, 46);
       // _webSite.CheckoutPage.AssertProductNameIsCorrect(expectedProduct1, 46);
        _webSite.CheckoutPage.BillingDetails(billingDetails);

        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonIsDisplayed();
        _webSite.CheckoutPage.AssertProductInfoConfirmOrderIsCorrect(expectedProduct1);

        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutTheOrder(successfullyPurchaseMessage);
        _webSite.CheckoutPage.AssertUrlPage(Url.SUCCESSFUL_ORDER_PAGE);
    }



    [Test]
    public void Checkout_When_RegisterTypeSelectedTest()
    {

        var expectedProduct2 = new ProductDetails
        {
            Name = "HTC Touch HD",
            Id = 28,
            UnitPrice = "$146.00",
            Model = "Product 1",
            Brand = "HTC",
            Quantity = "2",
        };
       
        var billingDetails = Factories.CustomerFactory.BillingAddress();
        var personalInformation = Factories.CustomerFactory.UserDetails();

        _driver.GoToUrl(Url.CHECKOUT_PAGE);
        _webSite.HomePage.SearchProductByName(expectedProduct2.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct2.Quantity);

        _driver.GoToUrl(Url.CHECKOUT_PAGE);
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Register);

        _webSite.CheckoutPage.CreateNewUserPayment(personalInformation);
        _webSite.CheckoutPage.BillingDetails(billingDetails);
        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonIsDisplayed();
        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutTheOrder(successfullyPurchaseMessage);
        _webSite.MyAccountPage.AssertUrlPage(Url.SUCCESSFUL_ORDER_PAGE);

    }


    [Test]
    public void Checkout_When_GuestTypeSelectedTest()
    {

        var expectedProduct3 = new ProductDetails
        {
            Name = "iPod Touch",
            Id = 32,
            UnitPrice = "$194.00",
            Model = "Product 5",
            Brand = "Apple",
            Quantity = "1",
        };


        var billingDetails = Factories.CustomerFactory.BillingAddress();
        var personalInformation = Factories.CustomerFactory.UserDetails();

        _driver.GoToUrl(Url.CHECKOUT_PAGE);
        _webSite.HomePage.SearchProductByName(expectedProduct3.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct3.Quantity);

        _driver.GoToUrl(Url.CHECKOUT_PAGE);
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Guest);
        _webSite.CheckoutPage.GuesUserPayment(personalInformation);
        _webSite.CheckoutPage.BillingDetails(billingDetails);
        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonIsDisplayed();
        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutTheOrder(successfullyPurchaseMessage);
        _webSite.MyAccountPage.AssertUrlPage(Url.SUCCESSFUL_ORDER_PAGE);
    }
}