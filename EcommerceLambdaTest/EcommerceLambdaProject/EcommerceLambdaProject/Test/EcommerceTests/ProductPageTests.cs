using EcommerceLambdaProject.Pages.ProductPage;

namespace EcommerceLambdaProject.Test.EcommerceTests;

public class ProductPageTests : BaseTest
{
    string  existingProduct1= "HTC Touch HD";
    string  existingProduct2 = "iPod Touch";
    string  existingProduct3 = "Sony VAIO";
    string emailAddress = "alabala@gmail.com";
    string password = "tester";

    
    [Test]
    public void CompareProducts_WhenOpenProductFromSearchResults_TwoProducts()
    {
        var expectedProduct1 = new ProductDetails
        {
            Name = "HTC Touch HD",
            Id = 28,
            UnitPrice = "$146.00",
            Model = "Product 1",
            Brand = "HTC",
            Availability = "In Stock",
            Weight = "146.40g"
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

        var expectedProduct3 = new ProductDetails
        {
            Name = "Sony VAIO",
            Id = 46,
            UnitPrice = "$1,202.00",
            Model = "Product 19",
            Brand = "Sony",
            Availability = "In Stock",
            Weight = "0.00kg"
        };

        _driver.GoToUrl(Url.COMPARISON_PAGE);
        _webSite.HomePage.SearchProductByName(existingProduct1);
        _webSite.ProductPage.ClickOnCompareButton();
        _webSite.HomePage.SearchProductByName(existingProduct2);
        _webSite.ProductPage.ClickOnCompareButton();
        _webSite.HomePage.SearchProductByName(existingProduct3);
        _webSite.ProductPage.ClickOnCompareButton();
        _driver.GoToUrl(Url.COMPARISON_PAGE);

        _webSite.MyAccountPage.AssertUrlPage(Url.COMPARISON_PAGE);
        _webSite.ProductPage.AssertTheProductDetailsIsCorrect(expectedProduct1, 1);
        _webSite.ProductPage.AssertTheProductDetailsIsCorrect(expectedProduct2, 2);
        _webSite.ProductPage.AssertTheProductDetailsIsCorrect(expectedProduct3, 3);
    }

    [Test]
    public void AddProductToTheWishlist_When_AuthenticatedUser()
    {
        var expectedProduct1 = new ProductDetails
        {
           

            Name = "HTC Touch HD",
            Id = 28,
            UnitPrice = "$120.00",
            Model = "Product 1",
            Brand = "HTC",
            Availability = "In Stock",
            Weight = "146.40g"
        };

        var expectedProduct2 = new ProductDetails
        {
            Name = "iPod Touch",
            Id = 32,
            UnitPrice = "$160.00",
            Model = "Product 5",
            Brand = "Apple",
            Availability = "In Stock",
            Weight = "5.00kg"
        };

        var expectedProduct3 = new ProductDetails
        {
            Name = "Sony VAIO",
            Id = 46,
            UnitPrice = "$1,000.00",
            Model = "Product 19",
            Brand = "Sony",
            Availability = "In Stock",
            Weight = "0.00kg"
        };

        var loginUser = Factories.CustomerFactory.LoginUser(emailAddress, password);

        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(existingProduct1);
        _webSite.ProductPage.AddProductToWishlist();
        _webSite.HomePage.SearchProductByName(existingProduct2);
        _webSite.ProductPage.AddProductToWishlist();
        _webSite.HomePage.SearchProductByName(existingProduct3);
        _webSite.ProductPage.AddProductToWishlist();
        _webSite.ProductPage.GoToWishlist();

        _webSite.MyAccountPage.AssertUrlPage(Url.WISHLIST_PAGE);
        _webSite.ProductPage.AssertProductIsAddedToWishlist(expectedProduct1, 1, 2, 3, 4);
        _webSite.ProductPage.AssertProductIsAddedToWishlist(expectedProduct2, 1, 2, 3, 4);
        _webSite.ProductPage.AssertProductIsAddedToWishlist(expectedProduct3, 1, 2, 3, 4);

    }
}