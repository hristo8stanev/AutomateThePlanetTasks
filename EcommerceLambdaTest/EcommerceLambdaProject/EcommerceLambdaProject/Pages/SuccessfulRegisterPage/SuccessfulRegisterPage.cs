namespace EcommerceLambdaProject.Pages;
public partial class SuccessfulRegisterPage : WebPage
{
    public SuccessfulRegisterPage(IDriver driver)
        : base(driver)
    {
    }

    public override string Url => SUCCESSFUL_REGISTRATION_PAGE;
}
