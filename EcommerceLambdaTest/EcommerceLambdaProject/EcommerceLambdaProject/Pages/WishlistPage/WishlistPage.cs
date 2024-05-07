namespace EcommerceLambdaProject.Pages;
public partial class WishListPage : WebPage
{
    public WishListPage(IDriver driver)
        : base(driver)
    {
    }

    public override string Url => WISHLIST_PAGE;
}
