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

    public void RegisterUserWithoutName(PersonalInformation user)
    {
        LastNameInput.TypeText(user.LastName);
        EmailAddressNameInput.TypeText(user.Email);
        TelephoneInput.TypeText(user.Telephone);
        PasswordInput.TypeText(user.Password);
        ConfirmPasswordInput.TypeText(user.ConfirmPassword);
        AgreePrivacy.Click();
        ContinueButton.Click();
    }

    public void RegisterUserWithoutEmailAddress(PersonalInformation user)
    {
        FirstNameInput.TypeText(user.FirstName);
        LastNameInput.TypeText(user.LastName);
        TelephoneInput.TypeText(user.Telephone);
        PasswordInput.TypeText(user.Password);
        ConfirmPasswordInput.TypeText(user.ConfirmPassword);
        AgreePrivacy.Click();
        ContinueButton.Click();
    }

    public void RegisterUserWithoutPassword(PersonalInformation user)
    {
        FirstNameInput.TypeText(user.FirstName);
        LastNameInput.TypeText(user.LastName);
        EmailAddressNameInput.TypeText(user.Email);
        TelephoneInput.TypeText(user.Telephone);
        ConfirmPasswordInput.TypeText(user.ConfirmPassword);
        AgreePrivacy.Click();
        ContinueButton.Click();
    }
}