namespace EcommerceLambdaProject.Test.EcommerceTests;

public class MyAccountPageTests : BaseTest
{
    [Test]
    public void EditMyProfile_When_AuthenticatedUserProvided()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
        var myAccountInfomraiton = CustomerFactory.RegisterUser();

        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MyAccountPage.ChangeMyAccountInformation(myAccountInfomraiton);

        _webSite.MyAccountPage.AssertAccountInformationIsSuccessfullyUpdated();
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.ACCOUNT_PAGE);
    }

    [Test]
    public void ChangeMyPassword_When_AuthenticatedUserProvided()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);

        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MyAccountPage.ChangeMyPassword();

        _webSite.MyAccountPage.AssertPasswordSuccessfullyChanged();
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.ACCOUNT_PAGE);
    }

    [Test]
    public void PurchaseGiftCertificate_When_AuthenticatedUserProvided()
    {
        var gift = CustomerFactory.GiftCertificate();

        _driver.GoToUrl(Urls.Urls.VOUCHER_PAGE);
        _webSite.MyAccountPage.PurchaseGiftCertificate(gift);

        _webSite.MyAccountPage.AssertSuccessfullyPurchaseGiftCertificate();
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.SUCCESSFUL_VAUCHER_PAGE);
    }

    [Test]
    public void AddNewAddress_When_AddressAddFromAddressBookAuthenticatedUserProvided()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
        var newAddress = CustomerFactory.BillingAddress();

        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MyAccountPage.ProceedToAddressBookSection();

        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.NEW_ADDRESS_PAGE);

        _webSite.MyAccountPage.AddNewAddress(newAddress);

        _webSite.MyAccountPage.AssertSuccessfullyAddedNewAddress();
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.ADDRESS_BOOK_PAGE);
    }

    [Test]
    public void CheckMyOrderHistory_When_AuthenticatedUserPurchaseProduct()
    {
        var billingDetails = CustomerFactory.BillingAddress();
        var personalInformation = CustomerFactory.RegisterUser();
        var firstProduct = CustomerFactory.Product();
        _webSite.ProductPage.SonyProduct(firstProduct);

        _driver.GoToUrl(Urls.Urls.CHECKOUT_PAGE);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _driver.GoToUrl(Urls.Urls.CHECKOUT_PAGE);
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Register);
        _webSite.CheckoutPage.FillBillingNewUserDetails(personalInformation);
        _webSite.CheckoutPage.FillBillingAddress(billingDetails);
        _webSite.CheckoutPage.ProceedToCheckout();
        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutTheOrder(Constants.Constants.SuccessfullyPurchaseMessage);

        _driver.GoToUrl(Urls.Urls.ORDER_HISTORY_PAGE);

        _webSite.MyAccountPage.AssertCustomerNameCorrect(personalInformation.FirstName + " " + personalInformation.LastName);
        _webSite.MyAccountPage.AssertThePurchaseDateToday();
    }
}