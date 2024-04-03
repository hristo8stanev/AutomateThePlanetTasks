namespace EcommerceLambdaProject.Test.EcommerceTests;

public class ShoppingCartPageTests : BaseTest
{
    [Test]
    public void AddProductToTheShopping_When_AuthenticatedUser()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
        var firstProduct = CustomerFactory.Product();
        var secondProduct = CustomerFactory.Product();
        var thirdProduct = CustomerFactory.Product();
        _webSite.ProductPage.NikonProduct(firstProduct);
        _webSite.ProductPage.IpodProduct(secondProduct);
        _webSite.ProductPage.SonyProduct(thirdProduct);

        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _webSite.HomePage.SearchProductByName(secondProduct.Name);
        _webSite.ProductPage.AddProductToCart(secondProduct.Quantity);
        _webSite.HomePage.SearchProductByName(thirdProduct.Name);
        _webSite.ProductPage.AddProductToCart(thirdProduct.Quantity);

        _driver.GoToUrl(Urls.Urls.CART_PAGE);

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductName(firstProduct, firstProduct.Id);
        _webSite.ShoppingCartPage.AssertProductName(secondProduct, secondProduct.Id);
        _webSite.ShoppingCartPage.AssertProductName(thirdProduct, thirdProduct.Id);

        _webSite.ShoppingCartPage.AssertProductInformation(firstProduct, 1);
        _webSite.ShoppingCartPage.AssertProductInformation(secondProduct, 1);
        _webSite.ShoppingCartPage.AssertProductInformation(thirdProduct, 1);
    }

    [Test]
    public void UpdateTheQuantityOfTheProducts_When_AuthenticatedUser()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
        var firstProduct = CustomerFactory.Product();
        _webSite.ProductPage.NikonProduct(firstProduct);

        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _driver.GoToUrl(Urls.Urls.CART_PAGE);

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductName(firstProduct, firstProduct.Id);

        _webSite.ShoppingCartPage.UpdateQuantity(Constants.Constants.updateQuantity);

        _webSite.ShoppingCartPage.AssertSuccessfullyUpdatedQuantityOfProduct(Constants.Constants.updateQuantity);
    }

    [Test]
    public void RemoveProductFromTheShoppingCart_When_AuthenticatedUser()
    {
        var firstProduct = CustomerFactory.Product();
        _webSite.ProductPage.NikonProduct(firstProduct);

        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _driver.GoToUrl(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.RemoveProductFromTheCart();

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductRemovedFromTheCart(firstProduct.Name);
    }

    [Test]
    public void AddProductToTheShopping_When_NonAuthenticatedUser()
    {
        var firstProduct = CustomerFactory.Product();
        _webSite.ProductPage.iPodShuffleProduct(firstProduct);

        _driver.GoToUrl(Urls.Urls.CART_PAGE);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _driver.GoToUrl(Urls.Urls.CART_PAGE);

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductName(firstProduct, firstProduct.Id);
        _webSite.ShoppingCartPage.AssertProductInformation(firstProduct, 1);
    }

    [Test]
    public void UpdateTheQuantityOfTheProducts_When_NonAuthenticatedUser()
    {
        var firstProduct = CustomerFactory.Product();
        _webSite.ProductPage.iPodShuffleProduct(firstProduct);

        _driver.GoToUrl(Urls.Urls.CART_PAGE);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _driver.GoToUrl(Urls.Urls.CART_PAGE);

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);

        _webSite.ShoppingCartPage.UpdateQuantity(Constants.Constants.updateQuantity);
        _webSite.ShoppingCartPage.AssertSuccessfullyUpdatedQuantityOfProduct(Constants.Constants.updateQuantity);
    }

    [Test]
    public void RemoveProductTheShoppingCart_When_NonAuthenticatedUserTest()
    {
        var firstProduct = CustomerFactory.Product();
        _webSite.ProductPage.iPodShuffleProduct(firstProduct);

        _driver.GoToUrl(Urls.Urls.CART_PAGE);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _driver.GoToUrl(Urls.Urls.CART_PAGE);

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);

        _webSite.ShoppingCartPage.RemoveProductFromTheCart();

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductRemovedFromTheCart(firstProduct.Name);
    }
}