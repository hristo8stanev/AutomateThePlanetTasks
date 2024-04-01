using System.Net.Mail;
using EcommerceLambdaProject.Pages.ProductPage;

namespace EcommerceLambdaProject.Test.EcommerceTests;

public class MyAccountPageTests : BaseTest
{
    string validEmail = "alabala@gmail.com";
    string password = "tester";
    string successfullyPurchaseMessage = "Your order has been placed!";

    [Test]
    public void EditMyProfile_When_AutheticatedUserProvided()
    {
        var loginUser = Factories.CustomerFactory.LoginUser(validEmail, password);
        var myAccountInfomraiton = Factories.CustomerFactory.RegisterUser();

        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MyAccountPage.GoToEditMyAccount();
        _webSite.MyAccountPage.ChangeMyAccountInfrmation(myAccountInfomraiton);

        _webSite.MyAccountPage.AssertAccountInformationIsSuccessfullyUpdated();
        _webSite.MyAccountPage.AssertUrlPage(Url.ACCOUNT_PAGE);

    }

    [Test]
    public void ChangeMyPssword_When_AutheticatedUserProvided()
    {
        var loginUser = Factories.CustomerFactory.LoginUser(validEmail, password);

        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MyAccountPage.ChangeMyPassword();

        _webSite.MyAccountPage.AssertPasswordIsSuccessfullyChanged();
        _webSite.MyAccountPage.AssertUrlPage(Url.ACCOUNT_PAGE);
    }

    [Test]
    public void PurchaseGiftCerticate_When_AutheticatedUserProvided()
    {
        var gift = Factories.CustomerFactory.GiftCertificate();

        _driver.GoToUrl(Url.VOUCHER_PAGE);
        _webSite.MyAccountPage.PuchaseGiftCertificate(gift);

        _webSite.MyAccountPage.AssertSuccessfullyPurchaseGiftCertificate();
        _webSite.MyAccountPage.AssertUrlPage(Url.SUCCESSFUL_VAUCHER_PAGE);
    }

    [Test]
    public void AddNewAddress_When_AddressAddFromAddressBookAutheticatedUserProvided()
    {
        var loginUser = Factories.CustomerFactory.LoginUser(validEmail, password);
        var newAddress = Factories.CustomerFactory.BillingAddress();
        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MyAccountPage.GoToAddressBookSection();

        _webSite.MyAccountPage.AssertSuccessfullyGoToAddNewAddressUrl(_driver.Url);

        _webSite.MyAccountPage.AddNewAddress(newAddress);

        _webSite.MyAccountPage.AssertSuccessfullyAddedNewAddres();
        _webSite.MyAccountPage.AssertUrlPage(Url.ADDRESS_BOOK_PAGE);
    }

    [Test]
    public void CheckMyOrderHistory_When_AuthenticatedUserPurchaseProduct()
    {
        var expectedProduct1 = new ProductDetails
        {
            Name = "HTC Touch HD",
            Id = 28,
            UnitPrice = "$120.00",
            Model = "Product 1",
            Brand = "HTC",
            Quantity = "3",
        };

        var billingDetails = Factories.CustomerFactory.BillingAddress();
        var personalInformation = Factories.CustomerFactory.RegisterUser();

        _driver.GoToUrl(Url.CHECKOUT_PAGE);
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct1.Quantity);
        _driver.GoToUrl(Url.CHECKOUT_PAGE);
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Register);
        _webSite.CheckoutPage.CreateNewUserPayment(personalInformation);
        _webSite.CheckoutPage.BillingDetailsWithoutName(billingDetails);
        _webSite.CheckoutPage.ProceedToCheckout();
        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutTheOrder(successfullyPurchaseMessage);
        
        _driver.GoToUrl(Url.ORDER_HISTORY_PAGE);

        _webSite.MyAccountPage.AssertCustomerNameIsCorrect(personalInformation.FirstName + " " + personalInformation.LastName);
        _webSite.MyAccountPage.AssertThePurchaseDateIsToday();
    }
}