namespace EcommerceLambdaProject.Pages;

public partial class SuccessfulOrderPage : WebPage
{
    public SuccessfulOrderPage(IDriver driver)
        : base(driver)
    {
    }
    public override string Url => SUCCESSFUL_ORDER_PAGE;
}