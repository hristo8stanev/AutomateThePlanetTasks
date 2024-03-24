using System.Diagnostics;

namespace EcommerceLambdaProject.Pages.ProductPage;
public partial class ProductPages : WebPage
{
    public ProductPages(IDriver driver) : base(driver)
    {
    }

    public void Product1(ProductDetails product)
    {
        product.Name = "iPod Touch";
        product.Id = 32;
        product.Price = "$194.00";
        product.Model = "Product 5";
        product.Brand = "Apple";
        product.Weight = "5.00kg";
    }

    public void Product2(ProductDetails product)
    {
        product.Name = "Sony VAIO";
        product.Id = 46;
        product.Price = "$1,202.00";
        product.Model = "Product 19";
        product.Brand = "Sony";
        product.Weight = "0.00kg";
    }

    public void AddProductToCart(string product)
    {
        FindProduct.Click();
        AddToCartButton.Click();

    }
    
    public void ClickOnCompareButton()
    {
        FindProduct.Click();
        CompareProductButton.Click();
    }

    public void AddProductToWishlist()
    {
        FindProduct.Click();
        WishlistButton.Click();
    }
    
    public void GoToWishlist()
    {
        SearchField.Hover();
        WishlistPage.Click();
       
    }
    public void GoToCompare()
    {

        ProceedToCompare.Click();
    }
}
