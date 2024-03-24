

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
        _webSite.CheckoutPage.LoginAccountType();
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


        var accountType = DifferentAccountType.Register; 
        SelectAccountType(accountType);

        
        switch (accountType)
        {
            case DifferentAccountType.Login:
                
                break;
            case DifferentAccountType.Register:
                _webSite.CheckoutPage.CreateNewUserPayment(personalInformation);
                break;
            case DifferentAccountType.Guest:
                
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }



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
        _webSite.CheckoutPage.GuestAccType.Click();
        _webSite.CheckoutPage.GuesUserPayment(personalInformation);
        _webSite.CheckoutPage.BillingDetails(billingDetails);
        _webSite.CheckoutPage.ProceedToCheckout();
        _webSite.CheckoutPage.AssertConfirmButtonIsDisplayed();
        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutTheOrder(successfullyPurchaseMessage);
        _webSite.CheckoutPage.AssertSuccessfullyCheckoutUrl(_driver.Url);
    }



    public void SelectAccountType(DifferentAccountType accountType)
    {
        switch (accountType)
        {
            case DifferentAccountType.Login:    
                
                break;
            case DifferentAccountType.Register:
                _webSite.CheckoutPage.RegisterAccountType();
                break;
            case DifferentAccountType.Guest:        
                
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(accountType), accountType, "Unsupported account type");
        }
    }
}