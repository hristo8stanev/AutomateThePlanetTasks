namespace EcommerceLambdaProject.Pages;

public partial class CheckoutPage : WebPage
{
    public CheckoutPage(IDriver driver)
        : base(driver)
    {
    }

    public override string Url => Urls.Urls.CHECKOUT_PAGE;

    public void FillBillingDetails(BillingInformation billingInformation)
    {
        ApplyCoupon.Hover();
        FirstNameField.TypeText(billingInformation.FirstName);
        LastNameField.TypeText(billingInformation.FirstName);
        CompanyField.TypeText(billingInformation.Company);
        AddressField1.TypeText(billingInformation.Address1);
        AddressField2.TypeText(billingInformation.Address2);
        CityField.TypeText(billingInformation.City);
        PostCodeField.TypeText(billingInformation.PostCode);
        Country(billingInformation.Country).Click();
        Driver.WaitForAjax();
        Region(billingInformation.Region).Click();
    }

    public void FillBillingAddress(BillingInformation billingInformation)
    {
        CompanyField.TypeText(billingInformation.Company);
        AddressField1.TypeText(billingInformation.Address1);
        AddressField2.TypeText(billingInformation.Address2);
        CityField.TypeText(billingInformation.City);
        PostCodeField.TypeText(billingInformation.PostCode);
        Country(billingInformation.Country).Click();
        Driver.WaitForAjax();
        Region(billingInformation.Region).Click();
    }

    public void FillBillingNewUserDetails(PersonalInformation user)
    {
        FirstNameField.TypeText(user.FirstName);
        LastNameField.TypeText(user.LastName);
        EmailPaymentField.TypeText(user.Email);
        TelephonePaymentField.TypeText(user.Telephone);

        if (PasswordPaymentField.Displayed == true)
        {
            PasswordPaymentField.TypeText(user.Password);
        }

        if (PasswordPaymentField.Displayed == true)
        {
            ConfirmPasswordPaymentField.TypeText(user.ConfirmPassword);
        }

        if (AgreePrivacy.Displayed == true)
        {
            AgreePrivacy.Click();
        }

    }

    public void SelectAccountType(DifferentAccountType accountType)
    {
        switch (accountType)
        {
            case DifferentAccountType.Login:
                LoginAccType.Click();
                break;

            case DifferentAccountType.Register:
                RegisterAccType.Click();
                break;

            case DifferentAccountType.Guest:
                GuestAccType.Click();
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(accountType), accountType, "Unsupported account type");
        }
    }

    public void LoginUser(string email, string password)
    {
        EmailField.TypeText(email);
        PasswordField.TypeText(password);
        LoginButton.Click();
    }

    public void ProceedToCheckout()
    {
        AgreeTerms.Click();
        Driver.WaitForAjax();
        ContinueButton.Click();
        ConfirmOrderButton.Hover();
    }

    public void ConfirmOrder()
    {
        ConfirmOrderButton.Click();
    }
}