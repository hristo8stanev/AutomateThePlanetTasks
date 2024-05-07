namespace EcommerceLambdaProject.Pages;

public partial class CheckoutPage : WebPage
{
    public CheckoutPage(IDriver driver)
        : base(driver)
    {
    }

    public override string Url => CHECKOUT_PAGE;

    public void FillUserDetails(BillingInformation billingInformation)
    {
        ApplyCoupon.Hover();

        FirstNameInput.TypeText(billingInformation.FirstName);
        LastNameInput.TypeText(billingInformation.FirstName);
        CompanyInput.TypeText(billingInformation.Company);
        AddressField1.TypeText(billingInformation.Address1);
        AddressField2.TypeText(billingInformation.Address2);
        CityInput.TypeText(billingInformation.City);
        PostCodeInput.TypeText(billingInformation.PostCode);
        Country(billingInformation.Country).Click();
        Driver.WaitForAjax();
        Region(billingInformation.Region).Click();
    }

    public void FillBillingAddress(BillingInformation billingInformation)
    {
        CompanyInput.TypeText(billingInformation.Company);
        AddressField1.TypeText(billingInformation.Address1);
        AddressField2.TypeText(billingInformation.Address2);
        CityInput.TypeText(billingInformation.City);
        PostCodeInput.TypeText(billingInformation.PostCode);
        Country(billingInformation.Country).Click();
        Driver.WaitForAjax();
        Region(billingInformation.Region).Click();
    }

    public void FillBillingNewUserDetails(PersonalInformation user)
    {
        FirstNameInput.TypeText(user.FirstName);
        LastNameInput.TypeText(user.LastName);
        EmailPaymentInput.TypeText(user.Email);
        TelephonePaymentInput.TypeText(user.Telephone);

        if (PasswordPaymentInput.Displayed == true)
        {
            PasswordPaymentInput.TypeText(user.Password);
        }

        if (PasswordPaymentInput.Displayed == true)
        {
            ConfirmPasswordPaymentInput.TypeText(user.ConfirmPassword);
        }

        if (AgreePrivacy.Displayed == true)
        {
            AgreePrivacy.Click();
        }
    }

    private void SelectAccountType(DifferentAccountType accountType)
    {
        switch (accountType)
        {
            case DifferentAccountType.Login:
                LoginInput.Click();
                break;

            case DifferentAccountType.Register:
                RegisterAccountType.Click();
                break;

            case DifferentAccountType.Guest:
                GuestAccountType.Click();
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(accountType), accountType, "Unsupported account type");
        }
    }

    public void SelectLoginAccountType()
    {
        SelectAccountType(DifferentAccountType.Login);
    }

    public void SelectRegisterAccountType()
    {
        SelectAccountType(DifferentAccountType.Register);
    }

    public void SelectGuestAccountType()
    {
        SelectAccountType(DifferentAccountType.Guest);
    }

    public void LoginUser(string email, string password)
    {
        EmailInput.TypeText(email);
        PasswordInput.TypeText(password);
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