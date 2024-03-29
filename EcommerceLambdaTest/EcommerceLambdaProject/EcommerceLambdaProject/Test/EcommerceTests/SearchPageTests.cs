

using EcommerceLambdaProject.Pages.ProductPage;

namespace EcommerceLambdaProject.Test.EcommerceTests;
public class SearchPageTests : BaseTest
{


    [Test]
    public void SearchExistingProductByName_When_NonAuthenticatedUserSearchedProduct()
    {
        var expectedProduct1 = new ProductDetails
        {
            Name = "Nikon D300",
            Id = 31,
            UnitPrice = "$98.00",
            Model = "Product 4",
            Brand = "Nikon",
            Quantity = "4",
            Availability = "In Stock",
            Weight = "0.00kg"

        };

        var expectedProduct2 = new ProductDetails
        {
            Name = "iPod Touch",
            Id = 32,
            UnitPrice = "$194.00",
            Model = "Product 5",
            Brand = "Apple",
            Availability = "In Stock",
            Weight = "5.00kg"
        };

        _driver.GoToUrl(Url.SEARCH_SHOP_PRODUCTS_PAGE);
        _webSite.SearchPage.AssertUrlPage(Url.SEARCH_SHOP_PRODUCTS_PAGE);

        _webSite.SearchPage.SearchProductByName(expectedProduct1);
        _webSite.SearchPage.AssertTheProductNameAndPriceIsCorrect(expectedProduct1, 31);

        _webSite.SearchPage.SearchProductByName(expectedProduct2);
        _webSite.SearchPage.AssertTheProductNameAndPriceIsCorrect(expectedProduct2, 32);

    }

    [Test]
    public void SearchNonExistingProductByName_When_NonAuthenticatedUserSearchedProduct()
    {
        var expectedProduct1 = new ProductDetails
        {
            Name = "Bosch",
            Id = 31,
            UnitPrice = "$98.00",
            Model = "Product 4",
            Brand = "Nikon",
            Quantity = "4",
            Availability = "In Stock",
            Weight = "0.00kg"

        };


        _driver.GoToUrl(Url.SEARCH_SHOP_PRODUCTS_PAGE);
        _webSite.SearchPage.AssertUrlPage(Url.SEARCH_SHOP_PRODUCTS_PAGE);

        _webSite.SearchPage.SearchProductByName(expectedProduct1);
        _webSite.SearchPage.AssertErrorMessageWhenNonExistingProductIsSearched();
    }
}