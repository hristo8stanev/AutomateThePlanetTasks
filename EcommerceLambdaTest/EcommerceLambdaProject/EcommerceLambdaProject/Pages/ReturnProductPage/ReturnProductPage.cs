namespace EcommerceLambdaProject.Pages;
public class ReturnProductPage : WebPage
{
    public ReturnProductPage(IDriver driver)
        : base(driver)
    {
    }

    public override string Url => RETURN_PRODUCT_PAGE;
}
