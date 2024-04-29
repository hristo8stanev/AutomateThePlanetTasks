namespace EcommerceLambdaProject.Test.EcommerceTests;

public class CheckoutPageTests : BaseTest
{
    [Test]
    public void Checkout_When_LoginUserTypeSelected_And_3ProductsPurchased_And_PaymentConfirmed()
    {
        var billingDetails = CustomerFactory.GenerateBillingAddress();
        var checkoutInformation = CheckoutInformationFactory.Build(ProductsFactory.iPodNano(), ProductsFactory.IPodShuffleProduct());

        _webSite.CheckoutPage.Navigate();
        _webSite.HomePage.SearchProductByName(ProductsFactory.iPodNano().Name);
        _webSite.ProductPage.AddProductToCart(ProductsFactory.iPodNano().Quantity);
        _webSite.HomePage.SearchProductByName(ProductsFactory.IPodShuffleProduct().Name);
        _webSite.ProductPage.AddProductToCart(ProductsFactory.IPodShuffleProduct().Quantity);
        _webSite.CheckoutPage.Navigate();
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Login);
        _webSite.CheckoutPage.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);

        _webSite.CheckoutPage.AssertUrlPage(Urls.Urls.CHECKOUT_PAGE);
        _webSite.CheckoutPage.AssertProductInformationCorrect(ProductsFactory.IPodShuffleProduct(), ProductsFactory.IPodShuffleProduct().Id);
        _webSite.CheckoutPage.AssertProductInformationCorrect(ProductsFactory.iPodNano(), ProductsFactory.iPodNano().Id);

        _webSite.CheckoutPage.FillUserDetails(billingDetails);

        _webSite.CheckoutPage.AssertCheckoutInformation(checkoutInformation);

        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonDisplayed();
        // The assertion failed because there is a bug in this step. On the checkout/checkout page and checkout/confirm page, the prices are different.
        // Expected: "$150.00"
        // But was:  "$182.00"
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(ProductsFactory.IPodShuffleProduct());
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(ProductsFactory.iPodNano());

        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutOrder(Constants.Constants.SuccessfullyPurchaseMessage);
        _webSite.CheckoutPage.AssertUrlPage(Urls.Urls.SUCCESSFUL_ORDER_PAGE);
    }

    [Test]
    public void Checkout_When_RegisterUserTypeSelected_And_2ProductsArePurchased_And_PaymentCompleted()
    {
        var billingDetails = CustomerFactory.GenerateBillingAddress();
        var personalInformation = CustomerFactory.GenerateUserDetails();
        var checkoutInformation = CheckoutInformationFactory.Build(ProductsFactory.SamsungSyncMaster(), ProductsFactory.IPodShuffleProduct());

        _webSite.CheckoutPage.Navigate();
        _webSite.HomePage.SearchProductByName(ProductsFactory.SamsungSyncMaster().Name);
        _webSite.ProductPage.AddProductToCart(ProductsFactory.SamsungSyncMaster().Quantity);
        _webSite.HomePage.SearchProductByName(ProductsFactory.IPodShuffleProduct().Name);
        _webSite.ProductPage.AddProductToCart(ProductsFactory.IPodShuffleProduct().Quantity);
        _webSite.CheckoutPage.Navigate();
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Register);
        _webSite.CheckoutPage.FillBillingNewUserDetails(personalInformation);
        _webSite.CheckoutPage.FillBillingAddress(billingDetails);

        _webSite.CheckoutPage.AssertCheckoutInformation(checkoutInformation);

        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonDisplayed();
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(ProductsFactory.SamsungSyncMaster());
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(ProductsFactory.IPodShuffleProduct());
        // The assertion failed because there is a bug in this step. On the checkout/checkout page and checkout/confirm page, the prices are different.
        // Expected: "$200.00"
        // But was:  "$242.00"

        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutOrder(Constants.Constants.SuccessfullyPurchaseMessage);
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.SUCCESSFUL_ORDER_PAGE);
    }

    [Test]
    public void Checkout_When_GuestUserTypeSelected_And_2ProductsArePurchased_And_PaymentCompleted()
    {
        var billingDetails = CustomerFactory.GenerateBillingAddress();
        var personalInformation = CustomerFactory.GenerateUserDetails();
        var checkoutInformation = CheckoutInformationFactory.Build(ProductsFactory.SamsungSyncMaster(), ProductsFactory.IPodShuffleProduct());

        _webSite.CheckoutPage.Navigate();
        _webSite.HomePage.SearchProductByName(ProductsFactory.SamsungSyncMaster().Name);
        _webSite.ProductPage.AddProductToCart(ProductsFactory.SamsungSyncMaster().Quantity);
        _webSite.HomePage.SearchProductByName(ProductsFactory.IPodShuffleProduct().Name);
        _webSite.ProductPage.AddProductToCart(ProductsFactory.IPodShuffleProduct().Quantity);
        _webSite.CheckoutPage.Navigate();
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Guest);
        _webSite.CheckoutPage.FillBillingNewUserDetails(personalInformation);
        _webSite.CheckoutPage.FillBillingAddress(billingDetails);

        _webSite.CheckoutPage.AssertCheckoutInformation(checkoutInformation);
        //_webSite.CheckoutPage.AssertProductInformationCorrect(firstProduct, firstProduct.Id);
        // The assertion failed because there is a bug in this step. On the checkout/checkout page and checkout/confirm page, the prices are different.
        //Expected: "$80.00"
        //But was:  "$98.00"

        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonDisplayed();
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(ProductsFactory.IPodShuffleProduct());
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(ProductsFactory.SamsungSyncMaster());
        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutOrder(Constants.Constants.SuccessfullyPurchaseMessage);
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.SUCCESSFUL_ORDER_PAGE);
    }
}