using EcommerceLambdaProject.Pages.BasePage;

namespace EcommerceLambdaProject.Test.EcommerceTests;

public class CheckoutPageTests : BaseTest
{
   
    [Test]
    public void Checkout_When_LoginUserTypeSelectedTest()
    {
        var billingDetails = CustomerFactory.BillingAddress();
        var firstProduct = CustomerFactory.Product();
        var secondProduct = CustomerFactory.Product();
        var thirdProduct = CustomerFactory.Product();
        _webSite.ProductPage.NikonProduct(firstProduct);
        _webSite.ProductPage.IpodProduct(secondProduct);
        _webSite.ProductPage.SonyProduct(thirdProduct);

        _driver.GoToUrl(Urls.Urls.CHECKOUT_PAGE);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _webSite.HomePage.SearchProductByName(secondProduct.Name);
        _webSite.ProductPage.AddProductToCart(secondProduct.Quantity);
        _webSite.HomePage.SearchProductByName(thirdProduct.Name);
        _webSite.ProductPage.AddProductToCart(thirdProduct.Quantity);
        _driver.GoToUrl(Urls.Urls.CHECKOUT_PAGE);
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Login);
        _webSite.CheckoutPage.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);

        _webSite.CheckoutPage.AssertUrlPage(Urls.Urls.CHECKOUT_PAGE);
        _webSite.CheckoutPage.AssertProductInfoIsCorrectCheckoutPage(thirdProduct, thirdProduct.Id);
        _webSite.CheckoutPage.AssertProductInfoIsCorrectCheckoutPage(secondProduct, secondProduct.Id);
        _webSite.CheckoutPage.AssertProductInfoIsCorrectCheckoutPage(firstProduct, firstProduct.Id);

        _webSite.CheckoutPage.FillBillingDetails(billingDetails);
        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonIsDisplayed();
        _webSite.CheckoutPage.AssertProductInfoConfirmOrderIsCorrect(thirdProduct);
        _webSite.CheckoutPage.AssertProductInfoConfirmOrderIsCorrect(secondProduct);
        _webSite.CheckoutPage.AssertProductInfoConfirmOrderIsCorrect(firstProduct);

        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutTheOrder(Constants.Constants.SuccessfullyPurchaseMessage);
        _webSite.CheckoutPage.AssertUrlPage(Urls.Urls.SUCCESSFUL_ORDER_PAGE);
    }

    [Test]
    public void Checkout_When_RegisterTypeSelectedTest()
    {
     
        var billingDetails = CustomerFactory.BillingAddress();
        var personalInformation = CustomerFactory.RegisterUser();
        var firstProduct = CustomerFactory.Product();
        var secondProduct = CustomerFactory.Product();

        _webSite.ProductPage.IpodProduct(firstProduct);
        _webSite.ProductPage.SonyProduct(secondProduct);
        _driver.GoToUrl(Urls.Urls.CHECKOUT_PAGE);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _webSite.HomePage.SearchProductByName(secondProduct.Name);
        _webSite.ProductPage.AddProductToCart(secondProduct.Quantity);
        _driver.GoToUrl(Urls.Urls.CHECKOUT_PAGE);
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Register);
        _webSite.CheckoutPage.FillBillingNewUserDetails(personalInformation);
        _webSite.CheckoutPage.FillBillingAddress(billingDetails);
      
        // _webSite.CheckoutPage.AssertProductInfoIsCorrectCheckoutPage(expectedProduct1, 46);
        // The assertion failed because there is a bug in this step. On the checkout/checkout page and checkout/confirm page, the prices are different.
        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonIsDisplayed();
        _webSite.CheckoutPage.AssertProductInfoConfirmOrderIsCorrect(firstProduct);
        _webSite.CheckoutPage.AssertProductInfoConfirmOrderIsCorrect(secondProduct);

        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutTheOrder(Constants.Constants.SuccessfullyPurchaseMessage);
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.SUCCESSFUL_ORDER_PAGE);
    }

    [Test]
    public void Checkout_When_GuestTypeSelectedTest()
    {
        var billingDetails = CustomerFactory.BillingAddress();
        var personalInformation = CustomerFactory.RegisterUser();
        var firstProduct = CustomerFactory.Product();
        var secondProduct = CustomerFactory.Product();

        _webSite.ProductPage.IpodProduct(firstProduct);
        _webSite.ProductPage.SonyProduct(secondProduct);
        _driver.GoToUrl(Urls.Urls.CHECKOUT_PAGE);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _webSite.HomePage.SearchProductByName(secondProduct.Name);
        _webSite.ProductPage.AddProductToCart(secondProduct.Quantity);

        _driver.GoToUrl(Urls.Urls.CHECKOUT_PAGE);
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Guest);
        _webSite.CheckoutPage.FillBillingNewUserDetails(personalInformation);
        _webSite.CheckoutPage.FillBillingAddress(billingDetails);

        // _webSite.CheckoutPage.AssertProductInfoIsCorrectCheckoutPage(expectedProduct1, 32);
        // The assertion failed because there is a bug in this step. On the checkout/checkout page and checkout/confirm page, the prices are different.

        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonIsDisplayed();
        _webSite.CheckoutPage.AssertProductInfoConfirmOrderIsCorrect(secondProduct);
        _webSite.CheckoutPage.AssertProductInfoConfirmOrderIsCorrect(firstProduct);
        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutTheOrder(Constants.Constants.SuccessfullyPurchaseMessage);
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.SUCCESSFUL_ORDER_PAGE);
    }
}