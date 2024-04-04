namespace EcommerceLambdaProject.Pages;

public partial class MyAccountPage : WebPage
{
    public MyAccountPage(IDriver driver)
        : base(driver)
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

    public void ProceedToAddressBookSection()
    {
        AddressBookButton.Click();
        NewAddressButton.Click();
        Driver.WaitForAjax();
    }
    public void ProceedToMyVoucherSection()
    {
        MyAccountMenuSection.Hover();
        MyVoucherButton.Click();
        Driver.WaitForAjax();
    }

    public void ProceedToOrderHistorySection()
    {
        MyAccountMenuSection.Click();
        MyOrderHistoryButton.Click();
        Driver.WaitForAjax();
    }

    public void AddNewAddress(BillingInformation billingInformation)
    {
        FirstNameInput.TypeText(billingInformation.FirstName);
        LastNameInput.TypeText(billingInformation.LastName);
        CompanyInput.TypeText(billingInformation.Company);
        AddressInput1.TypeText(billingInformation.Address1);
        AddressInput2.TypeText(billingInformation.Address2);
        CityInput.TypeText(billingInformation.City);
        PostCodeInput.TypeText(billingInformation.PostCode);
        Country(billingInformation.Country).Click();
        Driver.WaitForAjax();
        Region(billingInformation.Region).Click();
        ContinueButton.Click();
    }

    public void ChangeMyAccountInformation(PersonalInformation user)
    {
        EditMyAccountButton.Click();
        FirstNameInput.TypeText(user.FirstName);
        LastNameInput.TypeText(user.LastName);
        EmailAddressNameInput.TypeText(Constants.Constants.EmailAddress);
        TelephoneInput.TypeText(user.Telephone);
        ContinueButton.Click();
    }

    public void ChangeMyPassword()
    {
        ChangeMyPasswordButton.Click();
        PasswordInput.TypeText(Constants.Constants.Password);
        ConfirmPasswordInput.TypeText(Constants.Constants.Password);
        ContinueButton.Click();
    }

    public void PurchaseGiftCertificate(PurchaseGiftCertificate gift)
    {
        RecipientNameInput.TypeText(gift.RecipientName);
        RecipientEmailInput.TypeText(gift.RecipientEmail);
        YourNameInput.TypeText(gift.YourName);
        YourEmailInput.TypeText(gift.YourEmail);
        SelectGiftType(GiftCertificateType.Birthday);
        AmountCertificateInput.TypeText(gift.Amount);
        AgreeGiftCertificate.Click();
        ContinueButton.Click();
    }
}