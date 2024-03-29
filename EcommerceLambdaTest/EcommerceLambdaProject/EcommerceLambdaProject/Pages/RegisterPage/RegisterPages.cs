namespace EcommerceLambdaProject.Pages.RegisterPage;
public partial class RegisterPages : WebPage
{
    public RegisterPages(IDriver driver) : base(driver)
    {
    }

    public void RegisterUer(PersonalInformation user)
    {
        FirstNameInput.TypeText(user.FirstName);
        LastaNameInput.TypeText(user.LastName);
        EmailAddressNameInput.TypeText(user.Email);
        TelephoneInput.TypeText(user.Telephone);
        PasswordInput.TypeText(user.Password);
        ConfirmPasswordInput.TypeText(user.ConfirmPassword);
        AgreePrivacy.Click();
        ContinueButton.Click();
    }
}
