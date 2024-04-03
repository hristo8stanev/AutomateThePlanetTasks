namespace EcommerceLambdaProject.Pages;

public partial class MyAccountPage : WebPage
{
    public MyAccountPage(IDriver driver) : base(driver)
    {
    }

    public override string Url => Urls.Urls.ACCOUNT_PAGE;
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
                throw new ArgumentOutOfRangeException(nameof(giftCertificateType), giftCertificateType, "Unsupported gift certificate type");
        }
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
        SelectCountry(billingInformation.Country).Click();
        Driver.WaitForAjax();
        SelectRegion(billingInformation.Region).Click();
        ContinueButton.Click();
    }

    public void ChangeMyAccountInformation(PersonalInformation user)
    {
        EditMyAccountButton.Click();
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

    public void PurchaseGiftCertificate(PurchaseGiftCertificate gift)
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
}