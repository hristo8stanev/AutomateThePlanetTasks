namespace EcommerceLambdaProject.Pages;
public class NewAddressPage : WebPage
{
    public NewAddressPage(IDriver driver)
        : base(driver)
    {
    }

    public override string Url => NEW_ADDRESS_PAGE;
}
