namespace EcommerceLambdaProject.Pages;
public partial class LogoutPage : WebPage
{
    public LogoutPage(IDriver driver)
        : base(driver)
    {
    }

    public override string Url => LOGOUT_USER_PAGE;
}
