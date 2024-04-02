namespace EcommerceLambdaProject.Test.EcommerceTests;

public class MyAccountPageTests : BaseTest
{
    private string validEmail = "alabala@gmail.com";
    private string password = "tester";
    private string successfullyPurchaseMessage = "Your order has been placed!";

    [Test]
    public void EditMyProfile_When_AuthenticatedUserProvided()
    {
        var loginUser = CustomerFactory.LoginUser(validEmail, password);
        var myAccountInfomraiton = CustomerFactory.RegisterUser();

        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MyAccountPage.GoToEditMyAccount();
        _webSite.MyAccountPage.ChangeMyAccountInfrmation(myAccountInfomraiton);

        _webSite.MyAccountPage.AssertAccountInformationIsSuccessfullyUpdated();
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.ACCOUNT_PAGE);
    }

    [Test]
    public void ChangeMyPssword_When_AutheticatedUserProvided()
    {
        var loginUser = CustomerFactory.LoginUser(validEmail, password);

        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MyAccountPage.ChangeMyPassword();

        _webSite.MyAccountPage.AssertPasswordIsSuccessfullyChanged();
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.ACCOUNT_PAGE);
    }

    [Test]
    public void PurchaseGiftCerticate_When_AutheticatedUserProvided()
    {
        var gift = CustomerFactory.GiftCertificate();

        _driver.GoToUrl(Urls.Urls.VOUCHER_PAGE);
        _webSite.MyAccountPage.PuchaseGiftCertificate(gift);

        _webSite.MyAccountPage.AssertSuccessfullyPurchaseGiftCertificate();
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.SUCCESSFUL_VAUCHER_PAGE);
    }

    [Test]
    public void AddNewAddress_When_AddressAddFromAddressBookAutheticatedUserProvided()
    {
        var loginUser = CustomerFactory.LoginUser(validEmail, password);
        var newAddress = CustomerFactory.BillingAddress();
        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MyAccountPage.GoToAddressBookSection();

        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.NEW_ADDRESS_PAGE);

        _webSite.MyAccountPage.AddNewAddress(newAddress);

        _webSite.MyAccountPage.AssertSuccessfullyAddedNewAddress();
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.ADDRESS_BOOK_PAGE);
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

        var billingDetails = CustomerFactory.BillingAddress();
        var personalInformation = CustomerFactory.RegisterUser();

        _driver.GoToUrl(Urls.Urls.CHECKOUT_PAGE);
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct1.Quantity);
        _driver.GoToUrl(Urls.Urls.CHECKOUT_PAGE);
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Register);
        _webSite.CheckoutPage.CreateNewUserPayment(personalInformation);
        _webSite.CheckoutPage.BillingDetailsWithoutName(billingDetails);
        _webSite.CheckoutPage.ProceedToCheckout();
        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutTheOrder(successfullyPurchaseMessage);

        _driver.GoToUrl(Urls.Urls.ORDER_HISTORY_PAGE);

        _webSite.MyAccountPage.AssertCustomerNameIsCorrect(personalInformation.FirstName + " " + personalInformation.LastName);
        _webSite.MyAccountPage.AssertThePurchaseDateIsToday();
    }
}