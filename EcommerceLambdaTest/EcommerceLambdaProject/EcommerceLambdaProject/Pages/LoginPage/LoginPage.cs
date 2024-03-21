namespace EcommerceLambdaProject.Pages.LoginPage;
public partial class LoginPages : WebPage
{
    public LoginPages(IDriver driver) : base(driver)
    {
    }

   public void LoginUser(LoginInformation login)
    {
        EmailAddressLogin.TypeText(login.EmailAddress);
        PasswordLogin.TypeText(login.PasswordField);
        LoginButton.Click();
    }



}
