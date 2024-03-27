using System;
using EcommerceLambdaProject.Pages.ProductPage;

namespace EcommerceLambdaProject.Test.EcommerceTests;

public class ProductPageTests : BaseTest
{
   
    string emailAddress = "alabala@gmail.com";
    string password = "tester";

    //AUTHENTICATED USER
    
    [Test]
    public void CompareProducts_WhenOpenProductFromSearchResults_AuthenticatedUser()
    {

        var expectedProduct1 = new ProductDetails
        {
            Name = "Nikon D300",
            Id = 31,
            UnitPrice = "$80.00",
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
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.ClickOnCompareButton();
        _webSite.HomePage.SearchProductByName(expectedProduct2.Name);
        _webSite.ProductPage.ClickOnCompareButton();
        _webSite.HomePage.SearchProductByName(expectedProduct3.Name);
        _webSite.ProductPage.ClickOnCompareButton();
        _driver.GoToUrl(Url.COMPARISON_PAGE);

        _webSite.ProductPage.AssertUrlPage(Url.COMPARISON_PAGE);
        _webSite.ProductPage.AssertTheProductIsAddedToComparePage(expectedProduct3, 46);
        _webSite.ProductPage.AssertTheProductIsAddedToComparePage(expectedProduct2, 32);
        _webSite.ProductPage.AssertTheProductIsAddedToComparePage(expectedProduct1, 31);
        
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
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.AddProductToWishlist();
        _webSite.HomePage.SearchProductByName(expectedProduct2.Name);
        _webSite.ProductPage.AddProductToWishlist();
        _webSite.HomePage.SearchProductByName(expectedProduct3.Name);
        _webSite.ProductPage.AddProductToWishlist();
        _webSite.ProductPage.GoToWishlist();

        _webSite.ProductPage.AssertUrlPage(Url.WISHLIST_PAGE);
        _webSite.ProductPage.AssertProductIsAddedToWishlist(expectedProduct1, 28);
        _webSite.ProductPage.AssertProductIsAddedToWishlist(expectedProduct2, 32);
        _webSite.ProductPage.AssertProductIsAddedToWishlist(expectedProduct3, 46);

    }


    //NON-AUTHENTICATED USER

    [Test]
    public void CompareProducts_WhenOpenProductFromSearchResults_NonAuthenticatedUser()
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
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.ClickOnCompareButton();
        _webSite.HomePage.SearchProductByName(expectedProduct2.Name);
        _webSite.ProductPage.ClickOnCompareButton();
        _webSite.HomePage.SearchProductByName(expectedProduct3.Name);
        _webSite.ProductPage.ClickOnCompareButton();
        _driver.GoToUrl(Url.COMPARISON_PAGE);

        _webSite.ProductPage.AssertUrlPage(Url.COMPARISON_PAGE);
        _webSite.ProductPage.AssertTheProductIsAddedToComparePage(expectedProduct3, 46);
        _webSite.ProductPage.AssertTheProductIsAddedToComparePage(expectedProduct2, 32);
        _webSite.ProductPage.AssertTheProductIsAddedToComparePage(expectedProduct1, 31);

    }

   
}