using EcommerceLambdaProject.Pages.MyAccountPage;

namespace EcommerceLambdaProject.Test.EcommerceTests;


public class MyAccountPageTests : BaseTest
{
    string validEmail = "alabala@gmail.com";
    string password = "tester";


    [Test]
    public void EditMyProfile_When_AutheticatedUserProvided()
    {
        var loginUser = Factories.CustomerFactory.LoginUser(validEmail, password);
        var myAccountInfomraiton = Factories.CustomerFactory.UserDetails();

        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MyAccountPage.GoToEditMyAccount();
        _webSite.MyAccountPage.ChangeMyAccountInfrmation(myAccountInfomraiton);

        _webSite.MyAccountPage.AssertAccountInformationIsSuccessfullyUpdated();
        _webSite.MyAccountPage.AssertMyAccountUrlIsShown(_driver.Url);

    }

    [Test]
    public void ChangeMyPssword_When_AutheticatedUserProvided()
    {
        var loginUser = Factories.CustomerFactory.LoginUser(validEmail, password);

        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MyAccountPage.ChangeMyPassword();

        _webSite.MyAccountPage.AssertPasswordIsSuccessfullyChanged();
        _webSite.MyAccountPage.AssertMyAccountUrlIsShown(_driver.Url);

    }

    [Test]
    public void PurchaseGiftCerticate_When_AutheticatedUserProvided()
    {
        var gift = Factories.CustomerFactory.GiftCertificate();

        _driver.GoToUrl(Url.VOUCHER_PAGE);
        _webSite.MyAccountPage.PuchaseGiftCertificate(gift);

        _webSite.MyAccountPage.AssertSuccessfullyPurchaseGiftCertificate();
        _webSite.MyAccountPage.AssertAccountVoucherSuccessUrl(_driver.Url);

    }

    [Test]
    public void AddNewAddress_When_AddressAddFromAddressBookAutheticatedUserProvided()
    {
        var loginUser = Factories.CustomerFactory.LoginUser(validEmail, password);
        var newAddress = Factories.CustomerFactory.BillingAddress();
        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MyAccountPage.GoToAddressBookSection();
        _webSite.MyAccountPage.AddNewAddress(newAddress);

        //add assertions

    }

}