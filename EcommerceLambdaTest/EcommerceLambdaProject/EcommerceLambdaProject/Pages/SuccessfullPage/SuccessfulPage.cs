namespace EcommerceLambdaProject.Pages;

public partial class SuccessfulPage : WebPage
{
    public SuccessfulPage(IDriver driver)
        : base(driver)
    {
    }

    public override string Url => Urls.Urls.SUCCESSFUL_ORDER_PAGE;
}