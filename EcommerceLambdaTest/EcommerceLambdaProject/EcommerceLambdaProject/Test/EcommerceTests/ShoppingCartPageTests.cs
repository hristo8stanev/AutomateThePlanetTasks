namespace EcommerceLambdaProject.Test.EcommerceTests;

public class ShoppingCartPageTests : BaseTest
{
    [Test]
    public void AddProductToTheShopping_When_AuthenticatedUserAddsProductsToCart_And_ProductDetailsCorrect()
    {
        var loginUser = CustomerFactory.LoginUser(EmailAddress, Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MainHeader.AddProductToCart(IPodShuffleProduct());
        _webSite.MainHeader.AddProductToCart(SamsungSyncMaster());
        _webSite.MainHeader.AddProductToCart(iPodNano());
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ShoppingCartPage.AssertUrlPage(CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductName(IPodShuffleProduct());
        _webSite.ShoppingCartPage.AssertProductName(SamsungSyncMaster());
        _webSite.ShoppingCartPage.AssertProductName(iPodNano());

        _webSite.ShoppingCartPage.AssertProductInformation(SamsungSyncMaster());
        _webSite.ShoppingCartPage.AssertProductInformation(IPodShuffleProduct());
        _webSite.ShoppingCartPage.AssertProductInformation(iPodNano());
    }

    [Test]
    public void UpdateTheQuantityOfTheProducts_When_AuthenticatedUserUpdatesProductQuantityInCart_And_QuantityIsUpdatedCorrectly()
    {
        var loginUser = CustomerFactory.LoginUser(EmailAddress, Password);   

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MainHeader.AddProductToCart(iPodNano());
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ShoppingCartPage.AssertUrlPage(CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductName(iPodNano());

        _webSite.ShoppingCartPage.UpdateQuantity(updateQuantity);

        _webSite.ShoppingCartPage.AssertSuccessfullyUpdatedQuantity(updateQuantity);
    }

    [Test]
    public void RemoveProductFromTheShoppingCart_When_AuthenticatedUserRemovesProductFromCart_And_ProductIsSuccessfullyRemoved()
    {
        var loginUser = CustomerFactory.LoginUser(EmailAddress, Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MainHeader.AddProductToCart(HtcTouch());
        _webSite.ShoppingCartPage.Navigate();
        _webSite.ShoppingCartPage.RemoveProductFromCart();

        _webSite.ShoppingCartPage.AssertUrlPage(CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductRemoved();
    }

    [Test]
    public void AddProductToTheShopping_NonAuthenticatedUserAddsProductToCart_And_ProductIsAddedSuccessfully()
    {
        _webSite.ShoppingCartPage.Navigate();
        _webSite.MainHeader.AddProductToCart(SamsungSyncMaster());
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ShoppingCartPage.AssertUrlPage(CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductName(SamsungSyncMaster());
        _webSite.ShoppingCartPage.AssertProductInformation(SamsungSyncMaster());
        // The assertion failed because there is a bug in this step. On the product/page page and checkout/cart page, the prices are different.
        // Expected: "$200.00"
        // But was:  "$242.00"
    }

    [Test]
    public void UpdateTheQuantityOfTheProducts_When_NonAuthenticatedUserUpdatesProductQuantityInCart_And_QuantityIsUpdatedCorrectly()
    {
        _webSite.ShoppingCartPage.Navigate();
        _webSite.MainHeader.AddProductToCart(iPodNano());
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ShoppingCartPage.AssertUrlPage(CART_PAGE);

        _webSite.ShoppingCartPage.UpdateQuantity(updateQuantity);
        _webSite.ShoppingCartPage.AssertSuccessfullyUpdatedQuantity(updateQuantity);
    }

    [Test]
    public void RemoveProductTheShoppingCart_When_NonAuthenticatedUserRemovesProductFromCart_And_ProductIsSuccessfullyRemoved()
    {
        _webSite.ShoppingCartPage.Navigate();
        _webSite.MainHeader.AddProductToCart(HtcTouch());
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ShoppingCartPage.AssertUrlPage(CART_PAGE);

        _webSite.ShoppingCartPage.RemoveProductFromCart();

        _webSite.ShoppingCartPage.AssertUrlPage(CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductRemoved();
    }
}