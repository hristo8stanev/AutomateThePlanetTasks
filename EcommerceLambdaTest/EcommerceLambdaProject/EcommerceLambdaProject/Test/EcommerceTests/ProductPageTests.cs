
using EcommerceLambdaProject.Pages.ProductPage;

namespace EcommerceLambdaProject.Test.EcommerceTests;

public class ProductPageTests : BaseTest
{
    string existingProduct = "Sony VAIO";
    string existingProduct2 = "Ip";
    string existingProduct3 = "HTC";

    public void Product1(ProductDetails product)
    {
        product.Name = "iPod Touch";
        product.Id = 32;
        product.Price = "$194.00";
        product.Model = "Product 5";
        product.Brand = "Apple";
        product.Weight = "5.00kg";
    }

    [Test]
    public void CompareProducts_WhenOpenProductFromSearchResults_TwoProducts()
    {
        var product1 = new ProductDetails
        {

        Name = "iPod Touch",
        Id = 32,
        Price = "$194.00",
        Model = "Product 5",
        Brand = "Apple",
        Weight = "5.00kg",
    };



        _driver.GoToUrl(Url.COMPARISON_PAGE);
        _webSite.HomePage.SearchProductByName(existingProduct);
        _webSite.ProductPage.ClickOnCompareButton();

        _webSite.HomePage.SearchProductByName(existingProduct2);
        _webSite.ProductPage.ClickOnCompareButton();

        _webSite.HomePage.SearchProductByName(existingProduct3);
        _webSite.ProductPage.ClickOnCompareButton();

        _driver.GoToUrl(Url.COMPARISON_PAGE);
        _webSite.ProductPage.AssertTheProductNameIsCorrect(product1.Name);
       // _webSite.ProductPage.AssertTheProductNameIsCorrect("iPod Touch");


    }
}
