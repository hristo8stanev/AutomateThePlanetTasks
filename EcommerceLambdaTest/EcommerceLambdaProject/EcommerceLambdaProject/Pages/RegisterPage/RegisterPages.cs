namespace EcommerceLambdaProject.Pages;

public partial class RegisterPage : WebPage
{
    public RegisterPage(IDriver driver) : base(driver)
    {
    }
    
    public void RegisterUser(PersonalInformation user)
    {
        FirstNameInput.TypeText(user.FirstName);
        LastNameInput.TypeText(user.LastName);
        EmailAddressNameInput.TypeText(user.Email);
        TelephoneInput.TypeText(user.Telephone);
        PasswordInput.TypeText(user.Password);
        ConfirmPasswordInput.TypeText(user.ConfirmPassword);
        AgreePrivacy.Click();
        ContinueButton.Click();
    }
}