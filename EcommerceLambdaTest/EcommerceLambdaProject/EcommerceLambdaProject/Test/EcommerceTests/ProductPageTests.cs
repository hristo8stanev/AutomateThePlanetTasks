namespace EcommerceLambdaProject.Test.EcommerceTests;

public class ProductPageTests : BaseTest
{
    [Test]
    public void When_ThreeProductsSelected_And_ProductInformationCompared()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
       
        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(ProductsFactory.NikonProduct().Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(ProductsFactory.SamsungSyncMaster().Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(ProductsFactory.iPodNano().Name);
        _webSite.ProductPage.CompareProduct();
        _driver.GoToUrl(Urls.Urls.COMPARISON_PAGE);

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.COMPARISON_PAGE);
        _webSite.ProductPage.AssertTheProductAddedToComparePage(ProductsFactory.iPodNano(), ProductsFactory.iPodNano().Id);
        _webSite.ProductPage.AssertTheProductAddedToComparePage(ProductsFactory.SamsungSyncMaster(), ProductsFactory.SamsungSyncMaster().Id);
        _webSite.ProductPage.AssertTheProductAddedToComparePage(ProductsFactory.NikonProduct(), ProductsFactory.NikonProduct().Id);
    }

    [Test]
    public void AddProductToWishList_When_ProductAddedToWishlist_And_ProductSuccessfullyAddedToWishlist()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
       
        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(ProductsFactory.HtcTouch().Name);
        _webSite.ProductPage.AddProductToWishList();
        _webSite.HomePage.SearchProductByName(ProductsFactory.SamsungSyncMaster().Name);
        _webSite.ProductPage.AddProductToWishList();
        _webSite.HomePage.SearchProductByName(ProductsFactory.iPodNano().Name);
        _webSite.ProductPage.AddProductToWishList();
        _webSite.ProductPage.ProceedToWishList();

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.WISHLIST_PAGE);
        _webSite.ProductPage.AssertProductAddedToWishList(ProductsFactory.HtcTouch(), ProductsFactory.HtcTouch().Id);
        _webSite.ProductPage.AssertProductAddedToWishList(ProductsFactory.SamsungSyncMaster(), ProductsFactory.SamsungSyncMaster().Id);
        _webSite.ProductPage.AssertProductAddedToWishList(ProductsFactory.iPodNano(), ProductsFactory.iPodNano().Id);
    }

    [Test]
    public void SelectDifferentSizeOfProduct_When_DifferentSizeOfProductsSelected()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
       
        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(ProductsFactory.AppleProduct().Name);
        _webSite.ProductPage.SelectProductSize();
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ProductPage.AssertSizeProductIsCorrect(ProductsFactory.AppleProduct(), ProductsFactory.AppleProduct().Id);
    }

    [Test]
    public void CompareProducts_When_CompareProductsAsAuthenticatedUser()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);
    
        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(ProductsFactory.IPodShuffleProduct().Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(ProductsFactory.SamsungSyncMaster().Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(ProductsFactory.iPodNano().Name);
        _webSite.ProductPage.CompareProduct();

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.COMPARISON_PAGE);
        _webSite.ProductPage.AssertTheProductAddedToComparePage(ProductsFactory.iPodNano(), ProductsFactory.iPodNano().Id);
        _webSite.ProductPage.AssertTheProductAddedToComparePage(ProductsFactory.SamsungSyncMaster(), ProductsFactory.SamsungSyncMaster().Id);
        _webSite.ProductPage.AssertTheProductAddedToComparePage(ProductsFactory.IPodShuffleProduct(), ProductsFactory.IPodShuffleProduct().Id);
    }

    [Test]
    public void CompareProducts_When_CompareProductsAsNonAuthenticatedUser()
    {
        _webSite.LoginPage.Navigate();
        _webSite.HomePage.SearchProductByName(ProductsFactory.NikonProduct().Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(ProductsFactory.SamsungSyncMaster().Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(ProductsFactory.iPodNano().Name);
        _webSite.ProductPage.CompareProduct();

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.COMPARISON_PAGE);

        //The assertions failed because there is a bug in this step, because the prices on product/compare page and  default price of the products are different.
        //Expected: "$100.00"
        //But was: "$122.00"
        _webSite.ProductPage.AssertTheProductAddedToComparePage(ProductsFactory.iPodNano(), ProductsFactory.iPodNano().Id);
        _webSite.ProductPage.AssertTheProductAddedToComparePage(ProductsFactory.SamsungSyncMaster(), ProductsFactory.SamsungSyncMaster().Id);
        _webSite.ProductPage.AssertTheProductAddedToComparePage(ProductsFactory.NikonProduct(), ProductsFactory.NikonProduct().Id);
    }

    [Test]
    public void SelectDifferentSizeProduct_When_DifferentSizeProductSelectedAsNonAuthenticatedUser()
    {
        _webSite.LoginPage.Navigate();
        _webSite.HomePage.SearchProductByName(ProductsFactory.AppleProduct().Name);
        _webSite.ProductPage.SelectProductSize();
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ProductPage.AssertSizeProductIsCorrect(ProductsFactory.AppleProduct(), ProductsFactory.AppleProduct().Id);
    }
}