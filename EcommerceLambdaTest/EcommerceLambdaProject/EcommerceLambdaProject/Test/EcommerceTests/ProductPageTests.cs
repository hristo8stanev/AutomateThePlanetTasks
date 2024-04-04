namespace EcommerceLambdaProject.Test.EcommerceTests;

public class ProductPageTests : BaseTest
{
    [Test]
    public void When_ThreeProductsSelected_And_ProductInformationCompared()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
        var firstProduct = CustomerFactory.GenerateProduct();
        var secondProduct = CustomerFactory.GenerateProduct();
        var thirdProduct = CustomerFactory.GenerateProduct();
        Products.Products.NikonProduct(firstProduct);
        Products.Products.IPodProduct(secondProduct);
        Products.Products.SonyProduct(thirdProduct);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(secondProduct.Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(thirdProduct.Name);
        _webSite.ProductPage.CompareProduct();
        _driver.GoToUrl(Urls.Urls.COMPARISON_PAGE);

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.COMPARISON_PAGE);
        _webSite.ProductPage.AssertTheProductAddedToComparePage(thirdProduct, thirdProduct.Id);
        _webSite.ProductPage.AssertTheProductAddedToComparePage(secondProduct, secondProduct.Id);
        _webSite.ProductPage.AssertTheProductAddedToComparePage(firstProduct, firstProduct.Id);
    }

    [Test]
    public void AddProductToWishList_When_ProductAddedToWishlist_And_ProductSuccessfullyAddedToWishlist()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
        var firstProduct = CustomerFactory.GenerateProduct();
        var secondProduct = CustomerFactory.GenerateProduct();
        var thirdProduct = CustomerFactory.GenerateProduct();
        Products.Products.NikonProduct(firstProduct);
        Products.Products.IPodProduct(secondProduct);
        Products.Products.SonyProduct(thirdProduct);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToWishList();
        _webSite.HomePage.SearchProductByName(secondProduct.Name);
        _webSite.ProductPage.AddProductToWishList();
        _webSite.HomePage.SearchProductByName(thirdProduct.Name);
        _webSite.ProductPage.AddProductToWishList();
        _webSite.ProductPage.ProceedToWishList();

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.WISHLIST_PAGE);
        _webSite.ProductPage.AssertProductAddedToWishList(firstProduct, firstProduct.Id);
        _webSite.ProductPage.AssertProductAddedToWishList(secondProduct, secondProduct.Id);
        _webSite.ProductPage.AssertProductAddedToWishList(thirdProduct, thirdProduct.Id);
    }

    [Test]
    public void SelectDifferentSizeOfProduct_When_DifferentSizeOfProductsSelected()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
        var firstProduct = CustomerFactory.GenerateProduct();
        Products.Products.AppleProduct(firstProduct);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.SelectProductSize();
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ProductPage.AssertSizeProductIsCorrect(firstProduct, firstProduct.Id);
    }

    [Test]
    public void CompareProducts_When_CompareProductsAsAuthenticatedUser()
    {
        var firstProduct = CustomerFactory.GenerateProduct();
        var secondProduct = CustomerFactory.GenerateProduct();
        var thirdProduct = CustomerFactory.GenerateProduct();
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
        Products.Products.NikonProduct(firstProduct);
        Products.Products.IPodProduct(secondProduct);
        Products.Products.SonyProduct(thirdProduct);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(secondProduct.Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(thirdProduct.Name);
        _webSite.ProductPage.CompareProduct();

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.COMPARISON_PAGE);
        _webSite.ProductPage.AssertTheProductAddedToComparePage(thirdProduct, thirdProduct.Id);
        _webSite.ProductPage.AssertTheProductAddedToComparePage(secondProduct, secondProduct.Id);
        _webSite.ProductPage.AssertTheProductAddedToComparePage(firstProduct, firstProduct.Id);
    }

    [Test]
    public void CompareProducts_When_CompareProductsAsNonAuthenticatedUser()
    {
        var firstProduct = CustomerFactory.GenerateProduct();
        var secondProduct = CustomerFactory.GenerateProduct();
        var thirdProduct = CustomerFactory.GenerateProduct();

        Products.Products.NikonProduct(firstProduct);
        Products.Products.IPodProduct(secondProduct);
        Products.Products.SonyProduct(thirdProduct);

        _webSite.LoginPage.Navigate();
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(secondProduct.Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(thirdProduct.Name);
        _webSite.ProductPage.CompareProduct();

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.COMPARISON_PAGE);

        // The assertions failed because there is a bug in this step, because the prices for Authenticated and Non Authenticated user are different.
        _webSite.ProductPage.AssertTheProductAddedToComparePage(thirdProduct, thirdProduct.Id);
        _webSite.ProductPage.AssertTheProductAddedToComparePage(secondProduct, secondProduct.Id);
        _webSite.ProductPage.AssertTheProductAddedToComparePage(firstProduct, firstProduct.Id);
    }

    [Test]
    public void SelectDifferentSizeProduct_When_DifferentSizeProductSelectedAsNonAuthenticatedUser()
    {
        var firstProduct = CustomerFactory.GenerateProduct();
        Products.Products.AppleProduct(firstProduct);

        _webSite.LoginPage.Navigate();
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.SelectProductSize();
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ProductPage.AssertSizeProductIsCorrect(firstProduct, firstProduct.Id);
    }
}