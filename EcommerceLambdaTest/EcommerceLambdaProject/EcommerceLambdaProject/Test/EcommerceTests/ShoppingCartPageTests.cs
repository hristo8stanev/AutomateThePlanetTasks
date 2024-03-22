namespace EcommerceLambdaProject.Test.EcommerceTests;
public class ShoppingCartPageTests : BaseTest
{
    string emailAddress = "alabala@gmail.com";
    string password = "tester";

    string existingProduct = "Sony VAIO";
    string quantity = "3";


    //AUTHENTICATED USER

    [Test]
    public void AddProductToTheShopping_When_AuthenticatedUserTest()
    {

        var loginUser = Factories.CustomerFactory.LoginUser(emailAddress, password);
        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(existingProduct);
        _webSite.ProductPage.AddProductToCart(existingProduct);
        _driver.GoToUrl(Url.CART_PAGE);

        _webSite.ShoppingCartPage.AssertProductNameIsCorrect(existingProduct);
        _webSite.ShoppingCartPage.AssertSuccessfullyShoppingCartUrl(_driver.Url);

    }

    [Test]
    public void UpdateTheQuantityOfTheProducts_When_AuthenticatedUserTest()
    {

        var loginUser = Factories.CustomerFactory.LoginUser(emailAddress, password);
        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(existingProduct);
        _webSite.ProductPage.AddProductToCart(existingProduct);
        _driver.GoToUrl(Url.CART_PAGE);

        _webSite.ShoppingCartPage.AssertSuccessfullyShoppingCartUrl(Url.CART_PAGE);

        _webSite.ShoppingCartPage.UpdateQuantity(quantity);
        _webSite.ShoppingCartPage.AssertSuccessfullyUpdatedQuantityOfProduct(quantity);

    }

    [Test]
    public void RemoveProductFromTheShoppingCart_When_AuthenticatedUserTest()
    {
        var loginUser = Factories.CustomerFactory.LoginUser(emailAddress, password);
        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(existingProduct);
        _webSite.ProductPage.AddProductToCart(existingProduct);
        _driver.GoToUrl(Url.CART_PAGE);

        _webSite.ShoppingCartPage.RemoveProductFromTheCart();
        _webSite.ShoppingCartPage.AssertSuccessfullyShoppingCartUrl(Url.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductRemoveFromTheCart(existingProduct);

    }


    //NON-AUTHENTICATED USER

    [Test]
    public void AddProductToTheShopping_When_NonAuthenticatedUserTest()
    {

        _driver.GoToUrl(Url.CART_PAGE);
        _webSite.HomePage.SearchProductByName(existingProduct);
        _webSite.ProductPage.AddProductToCart(existingProduct);
        _driver.GoToUrl(Url.CART_PAGE);

        _webSite.ShoppingCartPage.AssertSuccessfullyShoppingCartUrl(Url.CART_PAGE);

        _webSite.ShoppingCartPage.AssertProductNameIsCorrect(existingProduct);
        _webSite.ShoppingCartPage.AssertSuccessfullyShoppingCartUrl(_driver.Url);

    }



    [Test]
    public void UpdateTheQuantityOfTheProducts_When_NonAuthenticatedUserTest()
    {

        _driver.GoToUrl(Url.CART_PAGE);
        _webSite.HomePage.SearchProductByName(existingProduct);
        _webSite.ProductPage.AddProductToCart(existingProduct);
        _driver.GoToUrl(Url.CART_PAGE);

        _webSite.ShoppingCartPage.AssertSuccessfullyShoppingCartUrl(Url.CART_PAGE);

        _webSite.ShoppingCartPage.UpdateQuantity(quantity);
        _webSite.ShoppingCartPage.AssertSuccessfullyUpdatedQuantityOfProduct(quantity);


    }

    [Test]
    public void RemoveProductTheShoppingCart_When_NonAuthenticatedUserTest()
    {
        _driver.GoToUrl(Url.CART_PAGE);
        _webSite.HomePage.SearchProductByName(existingProduct);
        _webSite.ProductPage.AddProductToCart(existingProduct);
        _driver.GoToUrl(Url.CART_PAGE);

        _webSite.ShoppingCartPage.AssertSuccessfullyShoppingCartUrl(Url.CART_PAGE);

        _webSite.ShoppingCartPage.RemoveProductFromTheCart();
        _webSite.ShoppingCartPage.AssertSuccessfullyShoppingCartUrl(Url.CART_PAGE);
        _webSite.ShoppingCartPage.AssertProductRemoveFromTheCart(existingProduct);

    }
}
