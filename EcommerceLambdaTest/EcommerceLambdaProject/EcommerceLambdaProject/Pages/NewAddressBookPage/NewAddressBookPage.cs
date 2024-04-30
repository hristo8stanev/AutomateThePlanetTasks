namespace EcommerceLambdaProject.Pages;
public class NewAddressBookPage : WebPage
{
    public NewAddressBookPage(IDriver driver)
        : base(driver)
    {
    }

    public override string Url => ADDRESS_BOOK_PAGE;
}
