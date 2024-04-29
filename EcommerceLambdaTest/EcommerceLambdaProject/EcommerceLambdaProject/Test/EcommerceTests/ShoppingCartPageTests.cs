namespace EcommerceLambdaProject.Test.EcommerceTests;

public class ShoppingCartPageTests : BaseTest
{
    [Test]
    public void AddProductToTheShopping_When_AuthenticatedUserAddsProductsToCart_And_ProductDetailsCorrect()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(ProductsFactory.IPodShuffleProduct().Name);
        _webSite.ProductPage.AddProductToCart(ProductsFactory.IPodShuffleProduct().Quantity);
        _webSite.HomePage.SearchProductByName(ProductsFactory.SamsungSyncMaster().Name);
        _webSite.ProductPage.AddProductToCart(ProductsFactory.SamsungSyncMaster().Quantity);
        _webSite.HomePage.SearchProductByName(ProductsFactory.iPodNano().Name);
        _webSite.ProductPage.AddProductToCart(ProductsFactory.iPodNano().Quantity);
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductName(ProductsFactory.IPodShuffleProduct(), ProductsFactory.IPodShuffleProduct().Id);
        _webSite.ShoppingCartPage.AssertProductName(ProductsFactory.SamsungSyncMaster(), ProductsFactory.SamsungSyncMaster().Id);
        _webSite.ShoppingCartPage.AssertProductName(ProductsFactory.iPodNano(), ProductsFactory.iPodNano().Id);

        _webSite.ShoppingCartPage.AssertProductInformation(ProductsFactory.SamsungSyncMaster());
        _webSite.ShoppingCartPage.AssertProductInformation(ProductsFactory.IPodShuffleProduct());
        _webSite.ShoppingCartPage.AssertProductInformation(ProductsFactory.iPodNano());
    }

    [Test]
    public void UpdateTheQuantityOfTheProducts_When_AuthenticatedUserUpdatesProductQuantityInCart_And_QuantityIsUpdatedCorrectly()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);   

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(ProductsFactory.iPodNano().Name);
        _webSite.ProductPage.AddProductToCart(ProductsFactory.iPodNano().Quantity);
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductName(ProductsFactory.iPodNano(), ProductsFactory.iPodNano().Id);

        _webSite.ShoppingCartPage.UpdateQuantity(Constants.Constants.updateQuantity);

        _webSite.ShoppingCartPage.AssertSuccessfullyUpdatedQuantity(Constants.Constants.updateQuantity);
    }

    [Test]
    public void RemoveProductFromTheShoppingCart_When_AuthenticatedUserRemovesProductFromCart_And_ProductIsSuccessfullyRemoved()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(ProductsFactory.HtcTouch().Name);
        _webSite.ProductPage.AddProductToCart(ProductsFactory.HtcTouch().Quantity);
        _webSite.ShoppingCartPage.Navigate();
        _webSite.ShoppingCartPage.RemoveProductFromCart();

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductRemoved(ProductsFactory.HtcTouch().Name);
    }

    [Test]
    public void AddProductToTheShopping_NonAuthenticatedUserAddsProductToCart_And_ProductIsAddedSuccessfully()
    {
        _webSite.ShoppingCartPage.Navigate();
        _webSite.HomePage.SearchProductByName(ProductsFactory.SamsungSyncMaster().Name);
        _webSite.ProductPage.AddProductToCart(ProductsFactory.SamsungSyncMaster().Quantity);
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductName(ProductsFactory.SamsungSyncMaster(), ProductsFactory.SamsungSyncMaster().Id);
        _webSite.ShoppingCartPage.AssertProductInformation(ProductsFactory.SamsungSyncMaster());
        // The assertion failed because there is a bug in this step. On the product/page page and checkout/cart page, the prices are different.
        // Expected: "$200.00"
        // But was:  "$242.00"
    }

    [Test]
    public void UpdateTheQuantityOfTheProducts_When_NonAuthenticatedUserUpdatesProductQuantityInCart_And_QuantityIsUpdatedCorrectly()
    {
        _webSite.ShoppingCartPage.Navigate();
        _webSite.HomePage.SearchProductByName(ProductsFactory.iPodNano().Name);
        _webSite.ProductPage.AddProductToCart(ProductsFactory.IPodShuffleProduct().Quantity);
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);

        _webSite.ShoppingCartPage.UpdateQuantity(Constants.Constants.updateQuantity);
        _webSite.ShoppingCartPage.AssertSuccessfullyUpdatedQuantity(Constants.Constants.updateQuantity);
    }

    [Test]
    public void RemoveProductTheShoppingCart_When_NonAuthenticatedUserRemovesProductFromCart_And_ProductIsSuccessfullyRemoved()
    {
        _webSite.ShoppingCartPage.Navigate();
        _webSite.HomePage.SearchProductByName(ProductsFactory.HtcTouch().Name);
        _webSite.ProductPage.AddProductToCart(ProductsFactory.HtcTouch().Quantity);
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);

        _webSite.ShoppingCartPage.RemoveProductFromCart();

        _webSite.ShoppingCartPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductRemoved(ProductsFactory.HtcTouch().Name);
    }
}