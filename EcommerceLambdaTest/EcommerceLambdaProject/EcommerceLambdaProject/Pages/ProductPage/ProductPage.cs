namespace EcommerceLambdaProject.Pages;

public partial class ProductPage : WebPage
{
    public ProductPage(IDriver driver)
        : base(driver)
    {
    }

    public override string Url => Urls.Urls.SEARCH_SHOP_PRODUCTS_PAGE;
    public void AddProductToCart(string quantity)
    {
        FindProduct.Click();
        QuantityField.TypeText(quantity);
        AddToCartButton.Click();
    }

    public void CompareProduct()
    {
        FindProduct.Click();
        CompareProductButton.Hover();
        CompareProductButton.Click();
        Driver.WaitForAjax();
        CompareButton.Click();
    }

    public void AddProductToWishlist()
    {
        FindProduct.Click();
        WishListButton.Click();
        Driver.WaitForAjax();
    }

    public void ProceedToWishlist()
    {
        SearchField.Hover();
        WishListPage.Click();
    }

    public void SelectSize(DifferentTypeSize sizeType)
    {
        switch (sizeType)
        {
            case DifferentTypeSize.Small:
                SmallSize.Click();
                break;

            case DifferentTypeSize.Medium:
                MediumSize.Click();
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
}