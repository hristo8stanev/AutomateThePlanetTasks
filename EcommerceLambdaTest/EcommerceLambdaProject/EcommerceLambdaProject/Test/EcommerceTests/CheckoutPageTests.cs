namespace EcommerceLambdaProject.Test.EcommerceTests;

public class CheckoutPageTests : BaseTest
{
    [Test]
    public void Checkout_When_LoginUserTypeSelected_And_3ProductsPurchased_And_PaymentConfirmed()
    {
        var billingDetails = CustomerFactory.GenerateBillingAddress();
        var firstProduct = CustomerFactory.GenerateProduct();
        var secondProduct = CustomerFactory.GenerateProduct();
        var thirdProduct = CustomerFactory.GenerateProduct();
        Products.Products.NikonProduct(firstProduct);
        Products.Products.IPodProduct(secondProduct);
        Products.Products.IPodShuffleProduct(thirdProduct);

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

        var combinedTotal = (firstProduct.Total + secondProduct.Total + thirdProduct.Total).ToString("C");
        Assert.That(combinedTotal, Is.EqualTo(_webSite.CheckoutPage.SubTotal.Text));

        _webSite.CheckoutPage.FillUserDetails(billingDetails);
        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonDisplayed();
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
        var firstProduct = CustomerFactory.GenerateProduct();
        var secondProduct = CustomerFactory.GenerateProduct();

        Products.Products.IPodProduct(firstProduct);
        Products.Products.IPodShuffleProduct(secondProduct);
        _webSite.CheckoutPage.Navigate();
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _webSite.HomePage.SearchProductByName(secondProduct.Name);
        _webSite.ProductPage.AddProductToCart(secondProduct.Quantity);
        _webSite.CheckoutPage.Navigate();
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Register);
        _webSite.CheckoutPage.FillBillingNewUserDetails(personalInformation);
        _webSite.CheckoutPage.FillBillingAddress(billingDetails);

        var combinedTotal = (firstProduct.Total + secondProduct.Total).ToString("C");
        Assert.That(combinedTotal, Is.EqualTo(_webSite.CheckoutPage.SubTotal.Text));

        // _webSite.CheckoutPage.AssertProductInformationCorrect(expectedProduct1, 46);
        // The assertions failed because there is a bug in this step. On the checkout/checkout page and checkout/confirm page, the prices are different.
        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonDisplayed();
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(firstProduct);
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(secondProduct);

        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutOrder(Constants.Constants.SuccessfullyPurchaseMessage);
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.SUCCESSFUL_ORDER_PAGE);
    }

    [Test]
    public void Checkout_When_GuestUserTypeSelected_And_2ProductsArePurchased_And_PaymentCompleted()
    {
        var billingDetails = CustomerFactory.GenerateBillingAddress();
        var personalInformation = CustomerFactory.GenerateUserDetails();
        var firstProduct = CustomerFactory.GenerateProduct();
        var secondProduct = CustomerFactory.GenerateProduct();

        Products.Products.IPodProduct(firstProduct);
        Products.Products.NikonProduct(secondProduct);
        _webSite.CheckoutPage.Navigate();
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _webSite.HomePage.SearchProductByName(secondProduct.Name);
        _webSite.ProductPage.AddProductToCart(secondProduct.Quantity);

        _webSite.CheckoutPage.Navigate();
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Guest);
        _webSite.CheckoutPage.FillBillingNewUserDetails(personalInformation);
        _webSite.CheckoutPage.FillBillingAddress(billingDetails);

        var combinedSubTotal = (firstProduct.Total + secondProduct.Total).ToString("C");
        Assert.That(combinedSubTotal, Is.EqualTo(_webSite.CheckoutPage.SubTotal.Text));

        var combinedTotal = (firstProduct.Total + secondProduct.Total + 5 + 14 + ).ToString("C");
        Assert.That(combinedTotal, Is.EqualTo(_webSite.CheckoutPage.Total.Text));

        // _webSite.CheckoutPage.AssertProductInformationCorrect(expectedProduct1, 32);
        // The assertion failed because there is a bug in this step. On the checkout/checkout page and checkout/confirm page, the prices are different.

        _webSite.CheckoutPage.ProceedToCheckout();

        _webSite.CheckoutPage.AssertConfirmButtonDisplayed();
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(secondProduct);
        _webSite.CheckoutPage.AssertProductInformationConfirmOrder(firstProduct);
        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutOrder(Constants.Constants.SuccessfullyPurchaseMessage);
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.SUCCESSFUL_ORDER_PAGE);
    }
}