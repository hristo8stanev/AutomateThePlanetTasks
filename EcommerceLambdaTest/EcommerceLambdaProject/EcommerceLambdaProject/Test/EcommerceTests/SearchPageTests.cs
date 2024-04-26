namespace EcommerceLambdaProject.Test.EcommerceTests;

public class SearchPageTests : BaseTest
{

    [Test]
    public void SearchExistingProductByName_When_NonAuthenticatedUserSearchesProducts()
    {
        var firstProduct = ProductsFactory.GenerateProduct();
        var secondProduct = ProductsFactory.GenerateProduct();
        ProductsFactory.NikonProduct(firstProduct);
        ProductsFactory.SamsungSyncMaster(secondProduct);

        _webSite.SearchPage.Navigate();
        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);

        _webSite.SearchPage.SearchProductByName(firstProduct);
        // The assertion failed because there is a bug in this step. On the search/page page and default product price, the prices are different.
        //Expected: "$80.00"
        // But was:  "$98.00"
        _webSite.SearchPage.AssertTheProductNameAndPrice(firstProduct, firstProduct.Id);


        _webSite.SearchPage.SearchProductByName(secondProduct);
        _webSite.SearchPage.AssertTheProductNameAndPrice(secondProduct, secondProduct.Id);


    }

    [Test]
    public void SearchNonExistingProductByName_When_NonAuthenticatedUserSearchedProduct()
    {
        var firstProduct = ProductsFactory.GenerateProduct();
        ProductsFactory.BoschProduct(firstProduct);

        _webSite.SearchPage.Navigate();
        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);

        _webSite.SearchPage.SearchProductByName(firstProduct);
        _webSite.SearchPage.AssertErrorMessageWhenNonExistingProductIsSearched();
    }

    [Test]
    public void FilterProductByPrice_When_NonAuthenticatedUserFiltersProductsByPrice_And_ProductsAreFilteredCorrectly()
    {
        var firstProduct = ProductsFactory.GenerateProduct();
        ProductsFactory.NikonProduct(firstProduct);

        _webSite.SearchPage.Navigate();
        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);
        _webSite.SearchPage.TypeRangePrices(Constants.Constants.MinPrice, Constants.Constants.MaxPrice);

        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE_PRICE_RANGE(Constants.Constants.MinPrice, Constants.Constants.MaxPrice));
    }

    [Test]
    public void FilterProductByName_When_AuthenticatedUserFiltersProductsByName_And_ProductsAreSortedCorrectly()
    {
        var firstProduct = ProductsFactory.GenerateProduct();
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
        ProductsFactory.iPodNano(firstProduct);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);

        _webSite.SearchPage.Navigate();
        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);

        _webSite.SearchPage.SearchProductByName(firstProduct);

        _webSite.SearchPage.AssertTheProductNameAndPrice(firstProduct, firstProduct.Id);
    }

    [Test]
    public void FilterProductByName_When_NonAuthenticatedUserFiltersProductsByName_And_ProductsAreSortedCorrectly()
    {
        var firstProduct = ProductsFactory.GenerateProduct();
        ProductsFactory.iPodNano(firstProduct);

        _webSite.SearchPage.Navigate();
        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);

        _webSite.SearchPage.SearchProductByName(firstProduct);

        _webSite.SearchPage.AssertTheProductNameAndPrice(firstProduct, firstProduct.Id);
        // The assertion failed because there is a bug in this step. On the search/page page and default product price, the prices are different.
        //Expected: "$100.00"
        // But was: "$122.00"
    }
}