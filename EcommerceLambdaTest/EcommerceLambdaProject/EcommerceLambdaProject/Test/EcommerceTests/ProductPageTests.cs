
using EcommerceLambdaProject.Pages.ProductPage;
using System.Net.Mail;

namespace EcommerceLambdaProject.Test.EcommerceTests;

public class ProductPageTests : BaseTest
{
    string  existingProduct= "Sony VAIO";
    string  existingProduct2 = "Ip";
    string  existingProduct3 = "HTC";

    string emailAddress = "alabala@gmail.com";
    string password = "tester";

    
    [Test]
    public void CompareProducts_WhenOpenProductFromSearchResults_TwoProducts()
    {
        var expectedProduct1 = new ProductDetails
        {
            Name = "iPod Touch",
            Id = 32,
            Price = "$194.00",
            Model = "Product 5",
            Brand = "Apple",
            Weight = "5.00kg"
        };

        _driver.GoToUrl(Url.COMPARISON_PAGE);
        _webSite.HomePage.SearchProductByName(existingProduct2);
        _webSite.ProductPage.ClickOnCompareButton();

        _webSite.HomePage.SearchProductByName(existingProduct);
        _webSite.ProductPage.ClickOnCompareButton();

        _webSite.HomePage.SearchProductByName(existingProduct3);
        _webSite.ProductPage.ClickOnCompareButton();

        _driver.GoToUrl(Url.COMPARISON_PAGE);
        
        _webSite.ProductPage.AssertTheProductNameIsCorrect(expectedProduct1); 
    }

    [Test]
    public void AddProductToTheWishlist_When_AuthenticatedUser()
    {
        var expectedProduct1 = new ProductDetails
        {
            Name = "iPod Touch",
            Id = 32,
            Price = "$194.00",
            Model = "Product 5",
            Brand = "Apple",
            Weight = "5.00kg"
        };

        var loginUser = Factories.CustomerFactory.LoginUser(emailAddress, password);
        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);

        _webSite.HomePage.SearchProductByName(existingProduct2);
        _webSite.ProductPage.AddProductToWishlist();
        _webSite.ProductPage.GoToWishlist();

        _webSite.ProductPage.AssertProductIsAddedToWishlist(expectedProduct1);

    }
}