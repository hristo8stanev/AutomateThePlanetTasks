namespace EcommerceLambdaProject.Pages;

public partial class ProductPage : WebPage
{
    public ProductPage(IDriver driver)
        : base(driver)
    {
    }

    public override string Url => SEARCH_SHOP_PRODUCTS_PAGE;

    public void CompareProduct()
    {
        CompareProductButton.Hover();
        CompareProductButton.Click();
        Driver.WaitForAjax();
        CompareButton.Click();
    }

    public void AddProductToWishList()
    {
        WishListButton.Click();
        Driver.WaitForAjax();
    }

    public void ProceedToWishList()
    {
        SearchField.Hover();
        Driver.WaitForAjax();
        WishListSection.Click();
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
        SizeField.Click();
        SelectSize(DifferentTypeSize.Medium);
        Driver.WaitForAjax();
        AddToCartButton.Click();
    }
}