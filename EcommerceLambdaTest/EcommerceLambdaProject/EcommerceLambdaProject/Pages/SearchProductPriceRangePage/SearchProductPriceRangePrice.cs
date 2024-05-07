namespace EcommerceLambdaProject.Pages;
public partial class SearchProductPriceRangePrice : WebPage
{
    public SearchProductPriceRangePrice(IDriver driver)
        : base(driver)
    {
    }

    public override string Url => SEARCH_SHOP_PRODUCTS_PAGE_PRICE_RANGE(MinPrice, MaxPrice);
}