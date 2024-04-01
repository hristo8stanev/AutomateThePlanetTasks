using EcommerceLambdaProject.Pages.BasePage;
using EcommerceLambdaProject.Pages.CheckoutPage;
using EcommerceLambdaProject.Pages.RegisterPage;

namespace EcommerceLambdaProject.Pages.MyAccountPage;
public partial class MyAccountPages : WebPage
{
    public MyAccountPages(IDriver driver) : base(driver)
    {
    }

    public void SelectGiftType(GiftCertificateType giftCertificateType)
    {
        switch (giftCertificateType)
        {
            case GiftCertificateType.General:
                GeneralCertificate.Click();
                break;
            case GiftCertificateType.Birthday:
                BirthdayCertificate.Click();
                break;
            case GiftCertificateType.Christmas:
                ChristmasCertificate.Click();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(giftCertificateType), giftCertificateType, "Unsupported gitft certificate type");
        }
    }

    public void GoToEditMyAccount()
    {
        EditMyAccountButton.Click();
    }

    public void GoToAddressBookSection()
    {
        AddressBookSection.Click();
        NewAddressButton.Click();
    }
    public void AddNewAddress(BillingInformation billingInformation)
    {
        FirstNameInput.TypeText(billingInformation.FirstName);
        LastaNameInput.TypeText(billingInformation.LastName);
        CompanyField.TypeText(billingInformation.Company);
        AddressField1.TypeText(billingInformation.Address1);
        AddressField2.TypeText(billingInformation.Address2);
        CityField.TypeText(billingInformation.City);
        PostCodeField.TypeText(billingInformation.PostCode);

        CountryField.Click();
        SelectCountry(billingInformation.Country).Click();
        Driver.WaitForAjax();

        Region.Click();
        SelectRegion(billingInformation.Region).Click();
        ContinueButton.Click();
    }




    public void ChangeMyAccountInfrmation(PersonalInformation user)
    {
      
        FirstNameInput.TypeText(user.FirstName);
        LastaNameInput.TypeText(user.LastName);
        EmailAddressNameInput.TypeText("alabala@gmail.com");
        TelephoneInput.TypeText(user.Telephone);
        ContinueButton.Click();
    }

    public void ChangeMyPassword()
    {
        ChangeMyPasswordButton.Click();
        PasswordField.TypeText("tester");
        ConfirmPasswordField.TypeText("tester");
        ContinueButton.Click();

    }

    public void PuchaseGiftCertificate(PurchaseGiftCertificate gift)
    {
        RecipientName.TypeText(gift.RecipientName);
        RecipientEmail.TypeText(gift.RecipientEmail);
        YourName.TypeText(gift.YourName);
        YourEmail.TypeText(gift.YourEmail);
        SelectGiftType(GiftCertificateType.Birthday);

        AmountCertificate.TypeText(gift.Amount);
        AgreeGiftCertificate.Click();
        ContinueButton.Click();
    }


    public void TakeTheNames()
    {



    }

}