namespace EcommerceLambdaProject.Test.EcommerceTests;

public class ProductPageTests : BaseTest
{
    [Test]
    public void CompareProducts_WhenOpenProductFromSearchResults_AuthenticatedUser()
    {
        var expectedProduct1 = new ProductDetails
        {
            Name = "Nikon D300",
            Id = 31,
            UnitPrice = "$80.00",
            Model = "Product 4",
            Brand = "Nikon",
            Quantity = "4",
            Availability = "In Stock",
            Weight = "0.00kg"
        };

        var expectedProduct2 = new ProductDetails
        {
            Name = "iPod Touch",
            Id = 32,
            UnitPrice = "$160.00",
            Model = "Product 5",
            Brand = "Apple",
            Availability = "In Stock",
            Weight = "5.00kg"
        };

        var expectedProduct3 = new ProductDetails
        {
            Name = "Sony VAIO",
            Id = 46,
            UnitPrice = "$1,000.00",
            Model = "Product 19",
            Brand = "Sony",
            Availability = "In Stock",
            Weight = "0.00kg"
        };
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);

        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(expectedProduct2.Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(expectedProduct3.Name);
        _webSite.ProductPage.CompareProduct();
        _driver.GoToUrl(Urls.Urls.COMPARISON_PAGE);

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.COMPARISON_PAGE);
        _webSite.ProductPage.AssertTheProductIsAddedToComparePage(expectedProduct3, expectedProduct3.Id);
        _webSite.ProductPage.AssertTheProductIsAddedToComparePage(expectedProduct2, expectedProduct2.Id);
        _webSite.ProductPage.AssertTheProductIsAddedToComparePage(expectedProduct1, expectedProduct1.Id);
    }

    [Test]
    public void AddProductToTheWishList_When_AuthenticatedUser()
    {
        var expectedProduct1 = new ProductDetails
        {
            Name = "HTC Touch HD",
            Id = 28,
            UnitPrice = "$120.00",
            Model = "Product 1",
            Brand = "HTC",
            Availability = "In Stock",
            Weight = "146.40g"
        };

        var expectedProduct2 = new ProductDetails
        {
            Name = "iPod Touch",
            Id = 32,
            UnitPrice = "$160.00",
            Model = "Product 5",
            Brand = "Apple",
            Availability = "In Stock",
            Weight = "5.00kg"
        };

        var expectedProduct3 = new ProductDetails
        {
            Name = "Sony VAIO",
            Id = 46,
            UnitPrice = "$1,000.00",
            Model = "Product 19",
            Brand = "Sony",
            Availability = "In Stock",
            Weight = "0.00kg"
        };

        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);

        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.AddProductToWishlist();
        _webSite.HomePage.SearchProductByName(expectedProduct2.Name);
        _webSite.ProductPage.AddProductToWishlist();
        _webSite.HomePage.SearchProductByName(expectedProduct3.Name);
        _webSite.ProductPage.AddProductToWishlist();
        _webSite.ProductPage.ProceedToWishlist();

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.WISHLIST_PAGE);
        _webSite.ProductPage.AssertProductIsAddedToWishlist(expectedProduct1, 28);
        _webSite.ProductPage.AssertProductIsAddedToWishlist(expectedProduct2, 32);
        _webSite.ProductPage.AssertProductIsAddedToWishlist(expectedProduct3, 46);
    }

    [Test]
    public void SelectDifferentSizeOfProduct_When_AuthenticatedUserSelectSize()
    {
        var expectedProduct = new ProductDetails
        {
            Name = "Apple Cinema 30",
            Id = 42,
            UnitPrice = "$100.00",
            Model = "Product 15",
            Brand = "Apple",
            Quantity = "4",
            Availability = "In Stock",
            Weight = "0.00kg",
            Size = "Size: Medium"
        };

        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);

        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);
        _webSite.HomePage.SearchProductByName(expectedProduct.Name);
        _webSite.ProductPage.SelectProductSize();
        _driver.GoToUrl(Urls.Urls.CART_PAGE);

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ProductPage.AssertSizeProductIsCorrect(expectedProduct, expectedProduct.Id);
    }

    [Test]
    public void CompareProducts_When_OpenProductFromSearchResults_NonAuthenticatedUser()
    {
        var expectedProduct1 = new ProductDetails
        {
            Name = "Nikon D300",
            Id = 31,
            UnitPrice = "$98.00",
            Model = "Product 4",
            Brand = "Nikon",
            Quantity = "4",
            Availability = "In Stock",
            Weight = "0.00kg"
        };

        var expectedProduct2 = new ProductDetails
        {
            Name = "iPod Touch",
            Id = 32,
            UnitPrice = "$194.00",
            Model = "Product 5",
            Brand = "Apple",
            Availability = "In Stock",
            Weight = "5.00kg"
        };

        var expectedProduct3 = new ProductDetails
        {
            Name = "Sony VAIO",
            Id = 46,
            UnitPrice = "$1,202.00",
            Model = "Product 19",
            Brand = "Sony",
            Availability = "In Stock",
            Weight = "0.00kg"
        };

        _driver.GoToUrl(Urls.Urls.COMPARISON_PAGE);
        _webSite.HomePage.SearchProductByName(expectedProduct1.Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(expectedProduct2.Name);
        _webSite.ProductPage.CompareProduct();
        _webSite.HomePage.SearchProductByName(expectedProduct3.Name);
        _webSite.ProductPage.CompareProduct();
        _driver.GoToUrl(Urls.Urls.COMPARISON_PAGE);

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.COMPARISON_PAGE);
        _webSite.ProductPage.AssertTheProductIsAddedToComparePage(expectedProduct3, expectedProduct3.Id);
        _webSite.ProductPage.AssertTheProductIsAddedToComparePage(expectedProduct2, expectedProduct2.Id);
        _webSite.ProductPage.AssertTheProductIsAddedToComparePage(expectedProduct1, expectedProduct1.Id);
    }

    [Test]
    public void SelectDifferentSizeOfProduct_When_NonAuthenticatedUserSelectSize()
    {
        var expectedProduct = new ProductDetails
        {
            Name = "Apple Cinema 30",
            Id = 42,
            UnitPrice = "$100.00",
            Model = "Product 15",
            Brand = "Apple",
            Quantity = "4",
            Availability = "In Stock",
            Weight = "0.00kg",
            Size = "Size: Medium"
        };

        _driver.GoToUrl(Urls.Urls.COMPARISON_PAGE);
        _webSite.HomePage.SearchProductByName(expectedProduct.Name);
        _webSite.ProductPage.SelectProductSize();
        _driver.GoToUrl(Urls.Urls.CART_PAGE);

        _webSite.ProductPage.AssertUrlPage(Urls.Urls.CART_PAGE);
        _webSite.ProductPage.AssertSizeProductIsCorrect(expectedProduct, expectedProduct.Id);
    }
}