namespace EcommerceLambdaProject.Pages;

public partial class SuccessfulReturnProductPage : WebPage
{
    public SuccessfulReturnProductPage(IDriver driver)
        : base(driver)
    {
    }

    public override string Url => SUCCESSFUL_RETURN_PRODUCT_PAGE;

}