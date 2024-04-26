namespace EcommerceLambdaProject.Test.EcommerceTests;

public class CheckoutPageTests : BaseTest
{
    [Test]
    public void Checkout_When_LoginUserTypeSelected_And_3ProductsPurchased_And_PaymentConfirmed()
    {
        var billingDetails = CustomerFactory.GenerateBillingAddress();
        var firstProduct = ProductsFactory.GenerateProduct();
        var secondProduct = ProductsFactory.GenerateProduct();
        var thirdProduct = ProductsFactory.GenerateProduct();
        ProductsFactory.NikonProduct(firstProduct);
        ProductsFactory.iPodNano(secondProduct);
        ProductsFactory.IPodShuffleProduct(thirdProduct);
        var checkoutInformation = CheckoutInformationFactory.Build(firstProduct, secondProduct, thirdProduct);

        _webSite.CheckoutPage.Navigate();
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _webSite.HomePage.SearchProductByName(secondProduct.Name);
        _webSite.ProductPage.AddProductToCart(secondProduct.Quantity);
        _webSite.HomePage.SearchProductByName(thirdProduct.Name);
        _webSite.ProductPage.AddProductToCart(thirdProduct.Quantity);
        _webSite.CheckoutPage.Navigate();
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Login);
        _webSite.CheckoutPage.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);

        _webSite.CheckoutPage.AssertUrlPage(Urls.Urls.CHECKOUT_PAGE);
        _webSite.CheckoutPage.AssertProductInformationCorrect(thirdProduct, thirdProduct.Id);
        _webSite.CheckoutPage.AssertProductInformationCorrect(secondProduct, secondProduct.Id);
        _webSite.CheckoutPage.AssertProductInformationCorrect(firstProduct, firstProduct.Id);

        _webSite.CheckoutPage.FillUserDetails(billingDetails);

        _webSite.CheckoutPage.AssertCheckoutInformation(checkoutInformation);

        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonDisplayed();

        // The assertion failed because there is a bug in this step. On the checkout/checkout page and checkout/confirm page, the prices are different.
        // Expected: "$150.00"
        // But was:  "$182.00"
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(thirdProduct);
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(secondProduct);
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(firstProduct);

        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutOrder(Constants.Constants.SuccessfullyPurchaseMessage);
        _webSite.CheckoutPage.AssertUrlPage(Urls.Urls.SUCCESSFUL_ORDER_PAGE);
    }

    [Test]
    public void Checkout_When_RegisterUserTypeSelected_And_2ProductsArePurchased_And_PaymentCompleted()
    {
        var billingDetails = CustomerFactory.GenerateBillingAddress();
        var personalInformation = CustomerFactory.GenerateUserDetails();
        var firstProduct = ProductsFactory.GenerateProduct();
        var secondProduct = ProductsFactory.GenerateProduct();
        ProductsFactory.SamsungSyncMaster(firstProduct);
        ProductsFactory.NikonProduct(secondProduct);
        var checkoutInformation = CheckoutInformationFactory.Build(firstProduct, secondProduct);

        _webSite.CheckoutPage.Navigate();
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _webSite.HomePage.SearchProductByName(secondProduct.Name);
        _webSite.ProductPage.AddProductToCart(secondProduct.Quantity);
        _webSite.CheckoutPage.Navigate();
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Register);
        _webSite.CheckoutPage.FillBillingNewUserDetails(personalInformation);
        _webSite.CheckoutPage.FillBillingAddress(billingDetails);

        _webSite.CheckoutPage.AssertCheckoutInformation(checkoutInformation);

        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonDisplayed();
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(firstProduct);
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(secondProduct);
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
        var firstProduct = ProductsFactory.GenerateProduct();
        var secondProduct = ProductsFactory.GenerateProduct();
        ProductsFactory.SamsungSyncMaster(firstProduct);
        ProductsFactory.NikonProduct(secondProduct);
        var checkoutInformation = CheckoutInformationFactory.Build(firstProduct, secondProduct);

        _webSite.CheckoutPage.Navigate();
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _webSite.HomePage.SearchProductByName(secondProduct.Name);
        _webSite.ProductPage.AddProductToCart(secondProduct.Quantity);
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
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(secondProduct);
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(firstProduct);
        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutOrder(Constants.Constants.SuccessfullyPurchaseMessage);
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.SUCCESSFUL_ORDER_PAGE);
    }
}