namespace EcommerceLambdaProject.Test.EcommerceTests;

public class ProductPageTests : BaseTest
{
    [Test]
    public void When_ThreeProductsSelected_And_ProductInformationCompared()
    {
        var loginUser = CustomerFactory.LoginUser(EmailAddress, Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MainHeader.AddProductToCart(IPodShuffleProduct());
        _webSite.ProductPage.CompareProduct();
        _webSite.MainHeader.AddProductToCart(SamsungSyncMaster());
        _webSite.ProductPage.CompareProduct();
        _webSite.MainHeader.AddProductToCart(iPodNano());
        _webSite.ProductPage.CompareProduct();
        _driver.GoToUrl(COMPARISON_PAGE);

        _webSite.ProductPage.AssertUrlPage(COMPARISON_PAGE);
        _webSite.ProductPage.AssertTheProductAddedToComparePage(iPodNano());
        _webSite.ProductPage.AssertTheProductAddedToComparePage(SamsungSyncMaster());
        _webSite.ProductPage.AssertTheProductAddedToComparePage(IPodShuffleProduct());
    }

    [Test]
    public void AddProductToWishList_When_ProductAddedToWishlist_And_ProductSuccessfullyAddedToWishlist()
    {
        var loginUser = CustomerFactory.LoginUser(EmailAddress, Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MainHeader.AddProductToCart(HtcTouch());
        _webSite.ProductPage.AddProductToWishList();
        _webSite.MainHeader.AddProductToCart(SamsungSyncMaster());
        _webSite.ProductPage.AddProductToWishList();
        _webSite.MainHeader.AddProductToCart(iPodNano());
        _webSite.ProductPage.AddProductToWishList();
        _webSite.ProductPage.ProceedToWishList();

        _webSite.ProductPage.AssertUrlPage(WISHLIST_PAGE);
        _webSite.ProductPage.AssertProductAddedToWishList(HtcTouch());
        _webSite.ProductPage.AssertProductAddedToWishList(SamsungSyncMaster());
        _webSite.ProductPage.AssertProductAddedToWishList(iPodNano());
    }

    [Test]
    public void SelectDifferentSizeOfProduct_When_DifferentSizeOfProductsSelected()
    {
        var loginUser = CustomerFactory.LoginUser(EmailAddress, Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MainHeader.AddProductToCart(AppleProduct());
        _webSite.ProductPage.SelectProductSize();
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ProductPage.AssertUrlPage(CART_PAGE);
        _webSite.ProductPage.AssertSizeProductIsCorrect(AppleProduct());
    }

    [Test]
    public void CompareProducts_When_CompareProductsAsAuthenticatedUser()
    {
        var loginUser = CustomerFactory.LoginUser(EmailAddress, Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.MainHeader.AddProductToCart(IPodShuffleProduct());
        _webSite.ProductPage.CompareProduct();
        _webSite.MainHeader.AddProductToCart(SamsungSyncMaster());
        _webSite.ProductPage.CompareProduct();
        _webSite.MainHeader.AddProductToCart(iPodNano());
        _webSite.ProductPage.CompareProduct();

        _webSite.ProductPage.AssertUrlPage(COMPARISON_PAGE);
        _webSite.ProductPage.AssertTheProductAddedToComparePage(iPodNano());
        _webSite.ProductPage.AssertTheProductAddedToComparePage(SamsungSyncMaster());
        _webSite.ProductPage.AssertTheProductAddedToComparePage(IPodShuffleProduct());
    }

    [Test]
    public void CompareProducts_When_CompareProductsAsNonAuthenticatedUser()
    {
        _webSite.LoginPage.Navigate();
        _webSite.MainHeader.AddProductToCart(NikonProduct());
        _webSite.ProductPage.CompareProduct();
        _webSite.MainHeader.AddProductToCart(SamsungSyncMaster());
        _webSite.ProductPage.CompareProduct();
        _webSite.MainHeader.AddProductToCart(iPodNano());
        _webSite.ProductPage.CompareProduct();

        _webSite.ProductPage.AssertUrlPage(COMPARISON_PAGE);

        //The assertions failed because there is a bug in this step, because the prices on product/compare page and  default price of the products are different.
        //Expected: "$100.00"
        //But was: "$122.00"
        _webSite.ProductPage.AssertTheProductAddedToComparePage(iPodNano());
        _webSite.ProductPage.AssertTheProductAddedToComparePage(SamsungSyncMaster());
        _webSite.ProductPage.AssertTheProductAddedToComparePage(NikonProduct());
    }

    [Test]
    public void SelectDifferentSizeProduct_When_DifferentSizeProductSelectedAsNonAuthenticatedUser()
    {
        _webSite.LoginPage.Navigate();
        _webSite.MainHeader.AddProductToCart(AppleProduct());
        _webSite.ProductPage.SelectProductSize();
        _webSite.ShoppingCartPage.Navigate();

        _webSite.ProductPage.AssertUrlPage(CART_PAGE);
        _webSite.ProductPage.AssertSizeProductIsCorrect(AppleProduct());
    }
}