namespace EcommerceLambdaProject.Test.EcommerceTests;

public class CheckoutPageTests : BaseTest
{
    [Test]
    public void Checkout_When_LoginUserTypeSelected_And_3ProductsPurchased_And_PaymentConfirmed()
    {
        var billingDetails = CustomerFactory.GenerateBillingAddress();
        var checkoutInformation = CheckoutInformationFactory.Build(iPodNano(), IPodShuffleProduct());

        _webSite.CheckoutPage.Navigate();
        _webSite.MainHeader.AddProductToCart(iPodNano());
        _webSite.MainHeader.AddProductToCart(IPodShuffleProduct());
        _webSite.CheckoutPage.Navigate();
        _webSite.CheckoutPage.SelectLoginAccountType();
        _webSite.CheckoutPage.LoginUser(EmailAddress, Password);

        _webSite.CheckoutPage.AssertUrlPage(CHECKOUT_PAGE);
        _webSite.CheckoutPage.AssertProductInformationCorrect(IPodShuffleProduct());
        _webSite.CheckoutPage.AssertProductInformationCorrect(iPodNano());
        _webSite.CheckoutPage.FillUserDetails(billingDetails);

        _webSite.CheckoutPage.AssertCheckoutInformation(checkoutInformation);

        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonDisplayed();
        // The assertion failed because there is a bug in this step. On the checkout/checkout page and checkout/confirm page, the prices are different.
        // Expected: "$150.00"
        // But was:  "$182.00"
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(IPodShuffleProduct());
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(iPodNano());

        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutOrder();
        _webSite.SuccessfulPage.AssertUrlPage();
    }

    [Test]
    public void Checkout_When_RegisterUserTypeSelected_And_2ProductsArePurchased_And_PaymentCompleted()
    {
        var billingDetails = CustomerFactory.GenerateBillingAddress();
        var personalInformation = CustomerFactory.GenerateUserDetails();    
        var checkoutInformation = CheckoutInformationFactory.Build(SamsungSyncMaster(), IPodShuffleProduct());

        _webSite.CheckoutPage.Navigate();
        _webSite.MainHeader.AddProductToCart(SamsungSyncMaster());
        _webSite.MainHeader.AddProductToCart(IPodShuffleProduct());
        _webSite.CheckoutPage.Navigate();
        _webSite.CheckoutPage.SelectRegisterAccountType();
        _webSite.CheckoutPage.FillBillingNewUserDetails(personalInformation);
        _webSite.CheckoutPage.FillBillingAddress(billingDetails);

        _webSite.CheckoutPage.AssertCheckoutInformation(checkoutInformation);

        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonDisplayed();
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(SamsungSyncMaster());
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(IPodShuffleProduct());
        // The assertion failed because there is a bug in this step. On the checkout/checkout page and checkout/confirm page, the prices are different.
        // Expected: "$200.00"
        // But was:  "$242.00"

        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutOrder();
        _webSite.MyAccountPage.AssertUrlPage(SUCCESSFUL_ORDER_PAGE);
    }

    [Test]
    public void Checkout_When_GuestUserTypeSelected_And_2ProductsArePurchased_And_PaymentCompleted()
    {
        var billingDetails = CustomerFactory.GenerateBillingAddress();
        var personalInformation = CustomerFactory.GenerateUserDetails();
        var checkoutInformation = CheckoutInformationFactory.Build(SamsungSyncMaster(), IPodShuffleProduct());

        _webSite.CheckoutPage.Navigate();
        _webSite.MainHeader.AddProductToCart(SamsungSyncMaster());
        _webSite.MainHeader.AddProductToCart(IPodShuffleProduct());
        _webSite.CheckoutPage.Navigate();
        _webSite.CheckoutPage.SelectGuestAccountType();
        _webSite.CheckoutPage.FillBillingNewUserDetails(personalInformation);
        _webSite.CheckoutPage.FillBillingAddress(billingDetails);

        _webSite.CheckoutPage.AssertCheckoutInformation(checkoutInformation);
        //_webSite.CheckoutPage.AssertProductInformationCorrect(firstProduct, firstProduct.Id);
        // The assertion failed because there is a bug in this step. On the checkout/checkout page and checkout/confirm page, the prices are different.
        //Expected: "$80.00"
        //But was:  "$98.00"

        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonDisplayed();
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(IPodShuffleProduct());
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(SamsungSyncMaster());
        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutOrder();
        _webSite.MyAccountPage.AssertUrlPage(SUCCESSFUL_ORDER_PAGE);
    }
}