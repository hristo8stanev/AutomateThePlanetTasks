namespace EcommerceLambdaProject.Test.EcommerceTests;
public class ShoppingCartPageTests : BaseTest
{
    string emailAddress = "alabala@gmail.com";
    string password = "tester";
    string existingProduct = "Sony VAIO";

    [Test]
    public void AddProductToTheShoppingCart_When_ExistingUserTest()
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
    public void UpdateTheQuantityOfTheProductsTest_When_ExistingUserTest()
    {


    }

    [Test]
    public void RemoveProductFromTheShoppingCartTest_When_ExistingUserTest()
    {
        var loginUser = Factories.CustomerFactory.LoginUser(emailAddress, password);
        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(existingProduct);
        _webSite.ProductPage.AddProductToCart(existingProduct);
        _driver.GoToUrl(Url.CART_PAGE);

        _webSite.ShoppingCartPage.RemoveProductFromTheCart();
        _webSite.ShoppingCartPage.AssertSuccessfullyShoppingCartUrl(Url.CART_PAGE);
        _webSite.ShoppingCartPage.assertProductRemoveFromTheCart(existingProduct);

    }
}
