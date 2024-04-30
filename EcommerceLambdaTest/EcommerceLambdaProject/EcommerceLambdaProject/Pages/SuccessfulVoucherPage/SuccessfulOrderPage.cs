namespace EcommerceLambdaProject.Pages;

public partial class SuccessfulVoucherPage : WebPage
{
    public SuccessfulVoucherPage(IDriver driver)
        : base(driver)
    {
    }
    public override string Url => SUCCESSFUL_VOUCHER_PAGE;

}