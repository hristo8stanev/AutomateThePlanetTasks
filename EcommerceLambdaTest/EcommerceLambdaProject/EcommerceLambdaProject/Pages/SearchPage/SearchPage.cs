namespace EcommerceLambdaProject.Pages;

public partial class SearchPage : WebPage
{
    public SearchPage(IDriver driver) : base(driver)
    {
    }

    public override string Url => Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE;

    public void SearchProductByName(ProductDetails product)
    {
        SearchInputSearchPage.TypeText(product.Name);
        SearchButtonSearchPage.Click();
    }

    public void EnterRangePrices(string min, string max)
    {
        MinPriceField.TypeText(min);
        MaxPriceField.TypeText(max);
        MaxPriceField.WrappedElement.SendKeys(Keys.Enter);
        Driver.WaitForAjax();
    }
}