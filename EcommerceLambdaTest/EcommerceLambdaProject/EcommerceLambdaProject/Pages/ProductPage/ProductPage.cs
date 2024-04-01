using System.Diagnostics;

namespace EcommerceLambdaProject.Pages.ProductPage;
public partial class ProductPages : WebPage
{
    public ProductPages(IDriver driver) : base(driver)
    {
    }

    public void AddProductToCart(string quantity)
    {
        FindProduct.Click();
        QuantityField.TypeText(quantity);
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

    public void SelectSize(DifferentTypeSize sizeType)
    {
        switch (sizeType)
        {
            case DifferentTypeSize.Small:
                SmallSize.Click();
                break;
            case DifferentTypeSize.Medium:
                Medium.Click();
                break;
            case DifferentTypeSize.Large:
                LargeSize.Click();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(sizeType), sizeType, "Unsupported account type");
        }
    }

    public void SelectProductSize()
    {
        FindProduct.Click();
        SizeField.Click();
        SelectSize(DifferentTypeSize.Medium);
        Driver.WaitForAjax();
        
        AddToCartButton.Click();

    }
    public void ClickOnBuyNowButton()
    {
        BuyNowProduct.Click();
    }
}
