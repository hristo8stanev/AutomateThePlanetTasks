namespace EcommerceLambdaProject.Test.EcommerceTests;

public class SearchPageTests : BaseTest
{

    [Test]
    public void SearchExistingProductByName_When_NonAuthenticatedUserSearchesProducts()
    {
        var firstProduct = CustomerFactory.Product();
        var secondProduct = CustomerFactory.Product();
        Products.Products.NikonProduct(firstProduct);
        Products.Products.IPodProduct(secondProduct);

        _webSite.SearchPage.Navigate();
        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);

        _webSite.SearchPage.SearchProductByName(firstProduct);
        _webSite.SearchPage.AssertTheProductNameAndPriceIsCorrect(firstProduct, firstProduct.Id);

        _webSite.SearchPage.SearchProductByName(secondProduct);
        _webSite.SearchPage.AssertTheProductNameAndPriceIsCorrect(secondProduct, secondProduct.Id);
    }

    [Test]
    public void SearchNonExistingProductByName_When_NonAuthenticatedUserSearchedProduct()
    {
        var firstProduct = CustomerFactory.Product();
        Products.Products.BoschProduct(firstProduct);

        _webSite.SearchPage.Navigate();
        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);

        _webSite.SearchPage.SearchProductByName(firstProduct);
        _webSite.SearchPage.AssertErrorMessageWhenNonExistingProductIsSearched();
    }

    [Test]
    public void FilterProductByPrice_When_NonAuthenticatedUserFiltersProductsByPrice_And_ProductsAreFilteredCorrectly()
    {
        var firstProduct = CustomerFactory.Product();
        Products.Products.NikonProduct(firstProduct);

        _webSite.SearchPage.Navigate();
        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);
        _webSite.SearchPage.EnterRangePrices(Constants.Constants.MinPrice, Constants.Constants.MaxPrice);

        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE_PRICE_RANGE(Constants.Constants.MinPrice, Constants.Constants.MaxPrice));
    }

    [Test]
    public void FilterProductByName_When_AuthenticatedUserFiltersProductsByName_And_ProductsAreSortedCorrectly()
    {
        var firstProduct = CustomerFactory.Product();
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
        Products.Products.SonyProduct(firstProduct);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);

        _webSite.SearchPage.Navigate();
        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);

        _webSite.SearchPage.SearchProductByName(firstProduct);

        _webSite.SearchPage.AssertTheProductNameAndPriceIsCorrect(firstProduct, firstProduct.Id);
    }

    [Test]
    public void FilterProductByName_When_NonAuthenticatedUserFiltersProductsByName_And_ProductsAreSortedCorrectly()
    {
        var firstProduct = CustomerFactory.Product();
        Products.Products.SonyProduct(firstProduct);

        _webSite.SearchPage.Navigate();
        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);

        _webSite.SearchPage.SearchProductByName(firstProduct);

        _webSite.SearchPage.AssertTheProductNameAndPriceIsCorrect(firstProduct, firstProduct.Id);
    }
}