using System.Diagnostics;

namespace EcommerceLambdaProject.Pages.ProductPage;
public partial class ProductPages : WebPage
{
    public ProductPages(IDriver driver) : base(driver)
    {
    }

    public void AddProductToCart(string product)
    {
        FindProduct.Click();
        AddToCartButton.Click();

    }
    
    public void ClickOnCompareButton()
    {
        FindProduct.Click();
        CompareProductButton.Hover();
        CompareProductButton.Click();
        Driver.WaitForAjax();
    }

    public void AddProductToWishlist()
    {
        FindProduct.Click();
        WishlistButton.Click();
        Driver.WaitForAjax();
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
