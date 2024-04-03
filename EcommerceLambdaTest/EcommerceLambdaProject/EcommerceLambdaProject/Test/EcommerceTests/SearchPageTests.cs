using EcommerceLambdaProject.Pages.BasePage;

namespace EcommerceLambdaProject.Test.EcommerceTests;

public class SearchPageTests : BaseTest
{

    [Test]
    public void SearchExistingProductByName_When_NonAuthenticatedUserSearchedProduct()
    {
        var firstProduct = CustomerFactory.Product();
        var secondProduct = CustomerFactory.Product();
        Products.Products.NikonProduct(firstProduct);
        Products.Products.IpodProduct(secondProduct);

        _driver.GoToUrl(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);
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

        _driver.GoToUrl(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);
        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);

        _webSite.SearchPage.SearchProductByName(firstProduct);
        _webSite.SearchPage.AssertErrorMessageWhenNonExistingProductIsSearched();
    }

    [Test]
    public void FilterProductByPrice_When_NonAuthenticatedUserTryToFilterTheProductsByPrice()
    {
        var firstProduct = CustomerFactory.Product();
        Products.Products.NikonProduct(firstProduct);

        _driver.GoToUrl(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);
        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);
        _webSite.SearchPage.EnterRangePrices(Constants.Constants.MinPrice, Constants.Constants.MaxPrice);

        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE_PRICE_RANGE(Constants.Constants.MinPrice, Constants.Constants.MaxPrice));
    }

    [Test]
    public void FilterProductByName_When_NonAuthenticatedUserTryToFilterProductByName()
    {
        var firstProduct = CustomerFactory.Product();
        Products.Products.SonyProduct(firstProduct);

        _driver.GoToUrl(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);
        _webSite.SearchPage.AssertUrlPage(Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE);

        _webSite.SearchPage.SearchProductByName(firstProduct);

        _webSite.SearchPage.AssertTheProductNameAndPriceIsCorrect(firstProduct, firstProduct.Id);
    }
}