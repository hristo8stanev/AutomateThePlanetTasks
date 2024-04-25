namespace EcommerceLambdaProject.Test.EcommerceTests;

public class ShoppingCartPageTests : BaseTest
{
    [Test]
    public void AddProductToTheShopping_When_AuthenticatedUserAddsProductsToCart_And_ProductDetailsCorrect()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
        var firstProduct = CustomerFactory.GenerateProduct();
        var secondProduct = CustomerFactory.GenerateProduct();
        var thirdProduct = CustomerFactory.GenerateProduct();
        ProductsFactory.NikonProduct(firstProduct);
        ProductsFactory.SamsungSyncMaster(secondProduct);
        ProductsFactory.iPodNano(thirdProduct);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _webSite.HomePage.SearchProductByName(secondProduct.Name);
        _webSite.ProductPage.AddProductToCart(secondProduct.Quantity);
        _webSite.HomePage.SearchProductByName(thirdProduct.Name);
        _webSite.ProductPage.AddProductToCart(thirdProduct.Quantity);

        _webSite.ShoppingCartPage.Navigate();

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductName(firstProduct, firstProduct.Id);
        _webSite.ShoppingCartPage.AssertProductName(secondProduct, secondProduct.Id);
        _webSite.ShoppingCartPage.AssertProductName(thirdProduct, thirdProduct.Id);

        _webSite.ShoppingCartPage.AssertProductInformation(firstProduct, 1);
        _webSite.ShoppingCartPage.AssertProductInformation(secondProduct, 1);
        _webSite.ShoppingCartPage.AssertProductInformation(thirdProduct, 1);
    }

    [Test]
    public void UpdateTheQuantityOfTheProducts_When_AuthenticatedUserUpdatesProductQuantityInCart_And_QuantityIsUpdatedCorrectly()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
        var firstProduct = CustomerFactory.GenerateProduct();
        ProductsFactory.NikonProduct(firstProduct);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductName(firstProduct, firstProduct.Id);

        _webSite.ShoppingCartPage.UpdateQuantity(Constants.Constants.updateQuantity);

        _webSite.ShoppingCartPage.AssertSuccessfullyUpdatedQuantity(Constants.Constants.updateQuantity);
    }

    [Test]
    public void RemoveProductFromTheShoppingCart_When_AuthenticatedUserRemovesProductFromCart_And_ProductIsSuccessfullyRemoved()
    {
        var firstProduct = CustomerFactory.GenerateProduct();
        ProductsFactory.NikonProduct(firstProduct);
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _webSite.ShoppingCartPage.Navigate();
        _webSite.ShoppingCartPage.RemoveProductFromCart();

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductRemoved(firstProduct.Name);
    }

    [Test]
    public void AddProductToTheShopping_NonAuthenticatedUserAddsProductToCart_And_ProductIsAddedSuccessfully()
    {
        var firstProduct = CustomerFactory.GenerateProduct();
        ProductsFactory.IPodShuffleProduct(firstProduct);

        _webSite.ShoppingCartPage.Navigate();
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductName(firstProduct, firstProduct.Id);
        _webSite.ShoppingCartPage.AssertProductInformation(firstProduct, 1);
    }

    [Test]
    public void UpdateTheQuantityOfTheProducts_When_NonAuthenticatedUserUpdatesProductQuantityInCart_And_QuantityIsUpdatedCorrectly()
    {
        var firstProduct = CustomerFactory.GenerateProduct();
        ProductsFactory.iPodNano(firstProduct);

        _webSite.ShoppingCartPage.Navigate();
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);

        _webSite.ShoppingCartPage.UpdateQuantity(Constants.Constants.updateQuantity);
        _webSite.ShoppingCartPage.AssertSuccessfullyUpdatedQuantity(Constants.Constants.updateQuantity);
    }

    [Test]
    public void RemoveProductTheShoppingCart_When_NonAuthenticatedUserRemovesProductFromCart_And_ProductIsSuccessfullyRemoved()
    {
        var firstProduct = CustomerFactory.GenerateProduct();
        ProductsFactory.NikonProduct(firstProduct);

        _webSite.ShoppingCartPage.Navigate();
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToCart(firstProduct.Quantity);
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);

        _webSite.ShoppingCartPage.RemoveProductFromCart();

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductRemoved(firstProduct.Name);
    }
}