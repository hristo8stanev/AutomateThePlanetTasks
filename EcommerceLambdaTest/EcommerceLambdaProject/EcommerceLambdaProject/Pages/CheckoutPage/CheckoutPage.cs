using EcommerceLambdaProject.Pages.RegisterPage;

namespace EcommerceLambdaProject.Pages.CheckoutPage;
public partial class CheckoutPages : WebPage
{
    public CheckoutPages(IDriver driver) : base(driver)
    {
    }
    public void BillingDetails(BillingInformation billingInformation)
    {
        ApplyCoupon.Hover();
        FirstNameField.TypeText(billingInformation.FirstName);
        LastNameField.TypeText(billingInformation.LastName);
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

    }

    public void BillingDetailsWithoutName(BillingInformation billingInformation)
    {
        ApplyCoupon.Hover();
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

    }


    public void CreateNewUserPayment(PersonalInformation user)
    {
        FirstNameField.TypeText(user.FirstName);
        LastNameField.TypeText(user.LastName);
        EmailPaymentField.TypeText(user.Email);
        TelephonePaymentField.TypeText(user.Telephone);
        PasswordPaymentField.TypeText(user.Password);
        ConfirmPasswordPaymentField.TypeText(user.ConfirmPassword);
        AgreePrivacy.Click();
    }

    public void GuesUserPayment(PersonalInformation user)
    {
        FirstNameField.TypeText(user.FirstName);
        LastNameField.TypeText(user.LastName);
        EmailPaymentField.TypeText(user.Email);
        TelephonePaymentField.TypeText(user.Telephone);
    }

    public  void SelectAccountType(DifferentAccountType accountType)
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


    public void Continue()
    {
        ContinueButton.Click();
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
