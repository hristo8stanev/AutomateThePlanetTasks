namespace EcommerceLambdaProject.Test.EcommerceTests;

public class SearchPageTests : BaseTest
{

    [Test]
    public void SearchExistingProductByName_When_NonAuthenticatedUserSearchesProducts()
    {
        _webSite.SearchPage.Navigate();
        _webSite.SearchPage.AssertUrlPage(SEARCH_SHOP_PRODUCTS_PAGE);

        _webSite.MainHeader.AddProductToCart(NikonProduct());
        //The assertion failed because there is a bug in this step. On the search/page page and default product price, the prices are different.
        //Expected: "$80.00"
        //But was:  "$98.00"
        _webSite.SearchPage.AssertTheProductNameAndPrice(NikonProduct());

        _webSite.SearchPage.SearchProductByName(SamsungSyncMaster());
        _webSite.SearchPage.AssertTheProductNameAndPrice(SamsungSyncMaster());
    }

    [Test]
    public void SearchNonExistingProductByName_When_NonAuthenticatedUserSearchedProduct()
    {
        _webSite.HomePage.Navigate();
        _webSite.SearchPage.AssertUrlPage(HOME_PAGE);

        _webSite.MainHeader.SearchProductByName(BoschProduct());
        _webSite.SearchPage.AssertErrorMessageWhenNonExistingProductIsSearched();
    }

    [Test]
    public void FilterProductByPrice_When_NonAuthenticatedUserFiltersProductsByPrice_And_ProductsAreFilteredCorrectly()
    {
        _webSite.SearchPage.Navigate();
        _webSite.SearchPage.AssertUrlPage(SEARCH_SHOP_PRODUCTS_PAGE);
        _webSite.SearchPage.TypeRangePrices(MinPrice, MaxPrice);

        _webSite.SearchPage.AssertUrlPage(SEARCH_SHOP_PRODUCTS_PAGE_PRICE_RANGE(MinPrice, MaxPrice));
    }

    [Test]
    public void FilterProductByName_When_AuthenticatedUserFiltersProductsByName_And_ProductsAreSortedCorrectly()
    {
        var loginUser = CustomerFactory.LoginUser(EmailAddress, Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.SearchPage.Navigate();
        _webSite.SearchPage.AssertUrlPage(SEARCH_SHOP_PRODUCTS_PAGE);
        _webSite.SearchPage.SearchProductByName(iPodNano());

        _webSite.SearchPage.AssertTheProductNameAndPrice(iPodNano());
    }

    [Test]
    public void FilterProductByName_When_NonAuthenticatedUserFiltersProductsByName_And_ProductsAreSortedCorrectly()
    {
        _webSite.SearchPage.Navigate();

        _webSite.SearchPage.AssertUrlPage(SEARCH_SHOP_PRODUCTS_PAGE);

        _webSite.SearchPage.SearchProductByName(iPodNano());

        _webSite.SearchPage.AssertTheProductNameAndPrice(iPodNano());
        //The assertion failed because there is a bug in this step. On the search/page page and default product price, the prices are different.
        //Expected: "$100.00"
        //But was: "$122.00"
    }
}