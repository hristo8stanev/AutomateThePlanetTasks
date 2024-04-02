namespace EcommerceLambdaProject.Test.EcommerceTests;

public class ShoppingCartPageTests : BaseTest
{
    private string emailAddress = "alabala@gmail.com";
    private string password = "tester";
    private string updateQuantity = "5";

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

        var expectedProduct3 = new ProductDetails
        {
            Name = "Nikon D300",
            Id = 31,
            UnitPrice = "$80.00",
            Model = "Product 4",
            Brand = "Nikon",
            Quantity = "4",
        };

        var loginUser = Factories.CustomerFactory.LoginUser(emailAddress, password);
        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct1.Quantity);
        _webSite.HomePage.SearchProductByName(expectedProduct2.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct2.Quantity);
        _webSite.HomePage.SearchProductByName(expectedProduct3.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct3.Quantity);

        _driver.GoToUrl(Urls.Urls.CART_PAGE);

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductName(expectedProduct1, 46);
        _webSite.ShoppingCartPage.AssertProductName(expectedProduct2, 32);
        _webSite.ShoppingCartPage.AssertProductName(expectedProduct3, 31);

        _webSite.ShoppingCartPage.AssertProductInformation(expectedProduct3, 1);
        _webSite.ShoppingCartPage.AssertProductInformation(expectedProduct2, 1);
        _webSite.ShoppingCartPage.AssertProductInformation(expectedProduct1, 1);
    }

    [Test]
    public void UpdateTheQuantityOfTheProducts_When_AuthenticatedUserTest()
    {
        var expectedProduct1 = new ProductDetails
        {
            Name = "Nikon D300",
            Id = 31,
            UnitPrice = "$80.00",
            Model = "Product 4",
            Brand = "Nikon",
            Quantity = "4",
        };

        var loginUser = Factories.CustomerFactory.LoginUser(emailAddress, password);
        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct1.Quantity);
        _driver.GoToUrl(Urls.Urls.CART_PAGE);

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductName(expectedProduct1, 31);

        _webSite.ShoppingCartPage.UpdateQuantity(updateQuantity);

        _webSite.ShoppingCartPage.AssertSuccessfullyUpdatedQuantityOfProduct(updateQuantity);
    }

    [Test]
    public void RemoveProductFromTheShoppingCart_When_AuthenticatedUserTest()
    {
        var expectedProduct1 = new ProductDetails
        {
            Name = "Nikon D300",
            Id = 31,
            UnitPrice = "$80.00",
            Model = "Product 4",
            Brand = "Nikon",
            Quantity = "4",
        };

        var loginUser = Factories.CustomerFactory.LoginUser(emailAddress, password);
        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct1.Quantity);
        _driver.GoToUrl(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.RemoveProductFromTheCart();

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductRemovedFromTheCart(expectedProduct1.Name);
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

        _driver.GoToUrl(Urls.Urls.CART_PAGE);
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct1.Quantity);
        _driver.GoToUrl(Urls.Urls.CART_PAGE);

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);

        _webSite.ShoppingCartPage.AssertProductName(expectedProduct1, 46);
        _webSite.ShoppingCartPage.AssertProductInformation(expectedProduct1, 1);
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

        _driver.GoToUrl(Urls.Urls.CART_PAGE);
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct1.Quantity);
        _driver.GoToUrl(Urls.Urls.CART_PAGE);

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);

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

        _driver.GoToUrl(Urls.Urls.CART_PAGE);
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.AddProductToCart(expectedProduct1.Quantity);
        _driver.GoToUrl(Urls.Urls.CART_PAGE);

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);

        _webSite.ShoppingCartPage.RemoveProductFromTheCart();

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductRemovedFromTheCart(expectedProduct1.Name);
    }
}