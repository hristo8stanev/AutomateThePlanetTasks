namespace EcommerceLambdaProject.Test.EcommerceTests;

public class ProductPageTests : BaseTest
{
    [Test]
    public void CompareProducts_When_ThreeProductSelected_And_ProductInformationCompared()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
        var firstProduct = CustomerFactory.Product();
        var secondProduct = CustomerFactory.Product();
        var thirdProduct = CustomerFactory.Product();
        Products.Products.NikonProduct(firstProduct);
        Products.Products.IpodProduct(secondProduct);
        Products.Products.SonyProduct(thirdProduct);

        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(secondProduct.Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(thirdProduct.Name);
        _webSite.ProductPage.CompareProduct();
        _driver.GoToUrl(Urls.Urls.COMPARISON_PAGE);

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.COMPARISON_PAGE);
        _webSite.ProductPage.AssertTheProductIsAddedToComparePage(thirdProduct, thirdProduct.Id);
        _webSite.ProductPage.AssertTheProductIsAddedToComparePage(secondProduct, secondProduct.Id);
        _webSite.ProductPage.AssertTheProductIsAddedToComparePage(firstProduct, firstProduct.Id);
    }


    //3 products
    [Test]
    public void AddProductToWishList_When_ProductAddedToWishlist_And_ProductSuccessfullyAddedToWishlist()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
        var firstProduct = CustomerFactory.Product();
        var secondProduct = CustomerFactory.Product();
        var thirdProduct = CustomerFactory.Product();
        Products.Products.NikonProduct(firstProduct);
        Products.Products.IpodProduct(secondProduct);
        Products.Products.SonyProduct(thirdProduct);

        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.AddProductToWishlist();
        _webSite.HomePage.SearchProductByName(secondProduct.Name);
        _webSite.ProductPage.AddProductToWishlist();
        _webSite.HomePage.SearchProductByName(thirdProduct.Name);
        _webSite.ProductPage.AddProductToWishlist();
        _webSite.ProductPage.ProceedToWishlist();

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.WISHLIST_PAGE);
        _webSite.ProductPage.AssertProductIsAddedToWishlist(firstProduct, firstProduct.Id);
        _webSite.ProductPage.AssertProductIsAddedToWishlist(secondProduct, secondProduct.Id);
        _webSite.ProductPage.AssertProductIsAddedToWishlist(thirdProduct, thirdProduct.Id);
    }

    [Test]
    public void SelectDifferentSizeOfProduct_When_DifferentSizeOfProductIsSelected()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
        var firstProduct = CustomerFactory.Product();
        Products.Products.AppleProduct(firstProduct);

        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.SelectProductSize();
        _driver.GoToUrl(Urls.Urls.CART_PAGE);

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ProductPage.AssertSizeProductIsCorrect(firstProduct, firstProduct.Id);
    }

    [Test]
    public void CompareProducts_When_CompareProductsAsNonAuthenticatedUser()
    {
        var firstProduct = CustomerFactory.Product();
        var secondProduct = CustomerFactory.Product();
        var thirdProduct = CustomerFactory.Product();
        Products.Products.NikonProduct(firstProduct);
        Products.Products.IpodProduct(secondProduct);
        Products.Products.SonyProduct(thirdProduct);


        _driver.GoToUrl(Urls.Urls.COMPARISON_PAGE);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(secondProduct.Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(thirdProduct.Name);
        _webSite.ProductPage.CompareProduct();
        _driver.GoToUrl(Urls.Urls.COMPARISON_PAGE);

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.COMPARISON_PAGE);
        _webSite.ProductPage.AssertTheProductIsAddedToComparePage(thirdProduct, thirdProduct.Id);
        _webSite.ProductPage.AssertTheProductIsAddedToComparePage(secondProduct, secondProduct.Id);
        _webSite.ProductPage.AssertTheProductIsAddedToComparePage(firstProduct, firstProduct.Id);
    }

    [Test]
    public void SelectDifferentSizeProduct_When_DifferentSizeProductSelectedAsNonAuthenticatedUser()
    {
        var firstProduct = CustomerFactory.Product();
        Products.Products.AppleProduct(firstProduct);

        _driver.GoToUrl(Urls.Urls.COMPARISON_PAGE);
        _webSite.HomePage.SearchProductByName(firstProduct.Name);
        _webSite.ProductPage.SelectProductSize();
        _driver.GoToUrl(Urls.Urls.CART_PAGE);

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ProductPage.AssertSizeProductIsCorrect(firstProduct, firstProduct.Id);
    }
}