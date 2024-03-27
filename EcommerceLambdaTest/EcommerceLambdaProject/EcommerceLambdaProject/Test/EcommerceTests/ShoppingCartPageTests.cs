using EcommerceLambdaProject.Pages.ProductPage;

namespace EcommerceLambdaProject.Test.EcommerceTests;
public class ShoppingCartPageTests : BaseTest
{
    string emailAddress = "alabala@gmail.com";
    string password = "tester";
    string updateQuantity = "5";

    //AUTHENTICATED USER
    [Test]
    public void AddProductToTheShopping_When_AuthenticatedUserTest()
    {

        var expectedProduct1 = new ProductDetails
        {
            Name = "Sony VAIO",
            Id = 46,
            UnitPrice = "$1,000.00",
            Model = "Product 19",
            Brand = "Sony",
            Quantity = "3",
        };

        var expectedProduct2 = new ProductDetails
        {
            Name = "iPod Touch",
            Id = 32,
            UnitPrice = "$160.00",
            Model = "Product 5",
            Brand = "Apple",
            Quantity = "4",
        };

        var loginUser = Factories.CustomerFactory.LoginUser(emailAddress, password);
        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct1.Quantity);
        _webSite.HomePage.SearchProductByName(expectedProduct2.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct2.Quantity);
        _driver.GoToUrl(Url.CART_PAGE);

        _webSite.ShoppingCartPage.AssertUrlPage(Url.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductNameIsCorrect(expectedProduct1, 46);
        _webSite.ShoppingCartPage.AssertProductNameIsCorrect(expectedProduct2, 32);
        _webSite.ShoppingCartPage.AssertProductInformationIsCorrect(expectedProduct2, 1, 2, 3);
        _webSite.ShoppingCartPage.AssertProductInformationIsCorrect(expectedProduct1, 1, 2, 3);
       
    }

   [Test]
   public void UpdateTheQuantityOfTheProducts_When_AuthenticatedUserTest()
   {
        var expectedProduct1 = new ProductDetails
        {
            Name = "Sony VAIO",
            Id = 46,
            UnitPrice = "$1,202.00",
            Model = "Product 19",
            Brand = "Sony",
            Quantity = "1",
        };

        var loginUser = Factories.CustomerFactory.LoginUser(emailAddress, password);
       _driver.GoToUrl(Url.LOGIN_PAGE);
       _webSite.LoginPage.LoginUser(loginUser);
       _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
       _webSite.ProductPage.AddProductToCart(expectedProduct1.Quantity);
       _driver.GoToUrl(Url.CART_PAGE);

        _webSite.ShoppingCartPage.AssertUrlPage(Url.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductNameIsCorrect(expectedProduct1, 46);

        _webSite.ShoppingCartPage.UpdateQuantity(updateQuantity);

       _webSite.ShoppingCartPage.AssertSuccessfullyUpdatedQuantityOfProduct(updateQuantity);
 
    }
  
    [Test]
    public void RemoveProductFromTheShoppingCart_When_AuthenticatedUserTest()
    {
        var expectedProduct1 = new ProductDetails
        {
            Name = "Sony VAIO",
            Id = 46,
            UnitPrice = "$1,202.00",
            Model = "Product 19",
            Brand = "Sony",
            Quantity = "1",
        };

        var loginUser = Factories.CustomerFactory.LoginUser(emailAddress, password);
        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct1.Quantity);
        _driver.GoToUrl(Url.CART_PAGE);
        _webSite.ShoppingCartPage.RemoveProductFromTheCart();

        _webSite.ShoppingCartPage.AssertUrlPage(Url.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductRemoveFromTheCart(expectedProduct1.Name);
  
    }
 

 
    //NON-AUTHENTICATED USER
    [Test]
    public void AddProductToTheShopping_When_NonAuthenticatedUserTest()
    {

        var expectedProduct1 = new ProductDetails
        {
            Name = "Sony VAIO",
            Id = 46,
            UnitPrice = "$1,202.00",
            Model = "Product 19",
            Brand = "Sony",
            Quantity = "3",
        };

        _driver.GoToUrl(Url.CART_PAGE);
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct1.Quantity);
        _driver.GoToUrl(Url.CART_PAGE);

        _webSite.ShoppingCartPage.AssertUrlPage(Url.CART_PAGE);
 
        _webSite.ShoppingCartPage.AssertProductNameIsCorrect(expectedProduct1, 46);
        _webSite.ShoppingCartPage.AssertProductInformationIsCorrect(expectedProduct1, 1, 2, 3);
    }
  
    [Test]
    public void UpdateTheQuantityOfTheProducts_When_NonAuthenticatedUserTest()
    {
        var expectedProduct1 = new ProductDetails
        {
            Name = "iPod Touch",
            Id = 32,
            UnitPrice = "$160.00",
            Model = "Product 5",
            Brand = "Apple",
            Quantity = "4",
        };

        _driver.GoToUrl(Url.CART_PAGE);
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct1.Quantity);
        _driver.GoToUrl(Url.CART_PAGE);

        _webSite.ShoppingCartPage.AssertUrlPage(Url.CART_PAGE);

        _webSite.ShoppingCartPage.UpdateQuantity(updateQuantity);
        _webSite.ShoppingCartPage.AssertSuccessfullyUpdatedQuantityOfProduct(updateQuantity);
    }
 
    [Test]
    public void RemoveProductTheShoppingCart_When_NonAuthenticatedUserTest()
    {
        var expectedProduct1 = new ProductDetails
        {
            Name = "Sony VAIO",
            Id = 46,
            UnitPrice = "$1,000.00",
            Model = "Product 19",
            Brand = "Sony",
            Quantity = "3",
        };

        _driver.GoToUrl(Url.CART_PAGE);
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct1.Quantity);
        _driver.GoToUrl(Url.CART_PAGE);

        _webSite.ShoppingCartPage.AssertUrlPage(Url.CART_PAGE);

        _webSite.ShoppingCartPage.RemoveProductFromTheCart();

        _webSite.ShoppingCartPage.AssertUrlPage(Url.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductRemoveFromTheCart(expectedProduct1.Name);
 
    }
}