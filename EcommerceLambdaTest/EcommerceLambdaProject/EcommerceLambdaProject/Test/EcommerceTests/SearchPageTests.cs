namespace EcommerceLambdaProject.Test.EcommerceTests;

public class SearchPageTests : BaseTest
{

    [Test]
    public void SearchExistingProductByName_When_NonAuthenticatedUserSearchesProducts()
    {
        _webSite.SearchPage.Navigate();
        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);

        _webSite.SearchPage.SearchProductByName(ProductsFactory.NikonProduct());
        // The assertion failed because there is a bug in this step. On the search/page page and default product price, the prices are different.
        //Expected: "$80.00"
        // But was:  "$98.00"
        _webSite.SearchPage.AssertTheProductNameAndPrice(ProductsFactory.NikonProduct(), ProductsFactory.NikonProduct().Id);

        _webSite.SearchPage.SearchProductByName(ProductsFactory.SamsungSyncMaster());
        _webSite.SearchPage.AssertTheProductNameAndPrice(ProductsFactory.SamsungSyncMaster(), ProductsFactory.SamsungSyncMaster().Id);
    }

    [Test]
    public void SearchNonExistingProductByName_When_NonAuthenticatedUserSearchedProduct()
    {
        _webSite.SearchPage.Navigate();
        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);

        _webSite.SearchPage.SearchProductByName(ProductsFactory.BoschProduct());
        _webSite.SearchPage.AssertErrorMessageWhenNonExistingProductIsSearched();
    }

    [Test]
    public void FilterProductByPrice_When_NonAuthenticatedUserFiltersProductsByPrice_And_ProductsAreFilteredCorrectly()
    {
        _webSite.SearchPage.Navigate();
        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);
        _webSite.SearchPage.TypeRangePrices(Constants.Constants.MinPrice, Constants.Constants.MaxPrice);

        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE_PRICE_RANGE(Constants.Constants.MinPrice, Constants.Constants.MaxPrice));
    }

    [Test]
    public void FilterProductByName_When_AuthenticatedUserFiltersProductsByName_And_ProductsAreSortedCorrectly()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.SearchPage.Navigate();
        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);
        _webSite.SearchPage.SearchProductByName(ProductsFactory.iPodNano());

        _webSite.SearchPage.AssertTheProductNameAndPrice(ProductsFactory.iPodNano(), ProductsFactory.iPodNano().Id);
    }

    [Test]
    public void FilterProductByName_When_NonAuthenticatedUserFiltersProductsByName_And_ProductsAreSortedCorrectly()
    {
        _webSite.SearchPage.Navigate();

        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);

        _webSite.SearchPage.SearchProductByName(ProductsFactory.iPodNano());

        _webSite.SearchPage.AssertTheProductNameAndPrice(ProductsFactory.iPodNano(), ProductsFactory.iPodNano().Id);
        //The assertion failed because there is a bug in this step. On the search/page page and default product price, the prices are different.
        //Expected: "$100.00"
        //But was: "$122.00"
    }
}