namespace EcommerceLambdaProject.Pages;
public partial class ForgotPasswordPage : WebPage
{
    public ForgotPasswordPage(IDriver driver)
        : base(driver)
    {
    }

    public override string Url => FORGOTTEN_PASSWORD_PAGE;
}
