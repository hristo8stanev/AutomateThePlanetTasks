namespace EcommerceLambdaProject.Test.EcommerceTests;

public class MyAccountPageTests : BaseTest
{
    [Test]
    public void EditMyProfile_When_FirstNameLastNameEmailAddressAndTelephoneEdited_And_ContinueButtonClicked()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
        var myAccountInfomraiton = CustomerFactory.GenerateUserDetails();

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MyAccountPage.ChangeMyAccountInformation(myAccountInfomraiton);

        _webSite.MyAccountPage.AssertAccountInformationIsSuccessfullyUpdated();
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.ACCOUNT_PAGE);
    }

    [Test]
    public void ChangeMyPassword_When_NewPasswordSet_And_ContinueButtonClicked()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MyAccountPage.ChangeMyPassword();

        _webSite.MyAccountPage.AssertPasswordSuccessfullyChanged();
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.ACCOUNT_PAGE);
    }

    [Test]
    public void PurchaseGiftCertificate_When_AuthenticatedUserProvided()
    {
        var gift = CustomerFactory.GenerateGiftCertificate();
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MyAccountPage.ProceedToMyVoucherSection();
        _webSite.MyAccountPage.PurchaseGiftCertificate(gift);

        _webSite.MyAccountPage.AssertSuccessfullyPurchaseGiftCertificate();
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.SUCCESSFUL_VOUCHER_PAGE);
    }

    [Test]
    public void AddNewAddress_AddressAddedFromAddressBook_And_AuthenticatedUserProvidesDetails()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
        var newAddress = CustomerFactory.GenerateBillingAddress();

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MyAccountPage.ProceedToAddressBookSection();

        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.NEW_ADDRESS_PAGE);

        _webSite.MyAccountPage.AddNewAddress(newAddress);

        _webSite.MyAccountPage.AssertSuccessfullyAddedNewAddress();
        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.ADDRESS_BOOK_PAGE);
    }

    [Test]
    public void CheckMyOrderHistory_When_AuthenticatedUserPurchasesProduct()
    {
        var billingDetails = CustomerFactory.GenerateBillingAddress();
        var personalInformation = CustomerFactory.GenerateUserDetails();
        var firstProduct = CustomerFactory.GenerateProduct();
        Products.Products.SonyProduct(firstProduct);

        _webSite.CheckoutPage.Navigate();
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _webSite.CheckoutPage.Navigate();
        _webSite.CheckoutPage.SelectAccountType(DifferentAccountType.Register);
        _webSite.CheckoutPage.FillBillingNewUserDetails(personalInformation);
        _webSite.CheckoutPage.FillBillingAddress(billingDetails);
        _webSite.CheckoutPage.ProceedToCheckout();
        _webSite.CheckoutPage.ConfirmOrder();

        _webSite.CheckoutPage.AssertSuccessfullyCheckoutOrder(Constants.Constants.SuccessfullyPurchaseMessage);

        _webSite.MyAccountPage.ProceedToOrderHistorySection();

        _webSite.MyAccountPage.AssertCustomerNameCorrect(personalInformation.FirstName + " " + personalInformation.LastName);
        _webSite.MyAccountPage.AssertThePurchaseDateToday();
    }
}