namespace EcommerceLambdaProject.Pages;

public partial class ProductPage : WebPage
{
    public ProductPage(IDriver driver) : base(driver)
    {
    }

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
    }

    public void AddProductToWishlist()
    {
        FindProduct.Click();
        WishlistButton.Click();
        Driver.WaitForAjax();
    }

    public void ProceedToWishlist()
    {
        SearchField.Hover();
        WishlistPage.Click();
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

    public void NikonProduct(ProductDetails productDetails)
    {
        productDetails.Name = "Nikon D300";
        productDetails.Brand = "Nikon";
        productDetails.Weight = "0.00kg";
        productDetails.Id = 31;
        productDetails.Availability = "In Stock";
        productDetails.UnitPrice = "$80.00";
        productDetails.Model = "Product 4";
        productDetails.Quantity = "4";
    }

    public void IpodProduct(ProductDetails productDetails)
    {
        productDetails.Name = "iPod Touch";
        productDetails.Brand = "Apple";
        productDetails.Weight = "5.00kg";
        productDetails.Id = 32;
        productDetails.Availability = "In Stock";
        productDetails.UnitPrice = "$160.00";
        productDetails.Model = "Product 5";
        productDetails.Quantity = "2";
    }

    public void SonyProduct(ProductDetails productDetails)
    {

        productDetails.Name = "Sony VAIO";
        productDetails.Brand = "Sony";
        productDetails.Weight = "0.00kg";
        productDetails.Id = 46;
        productDetails.Availability = "In Stock";
        productDetails.UnitPrice = "$1,000.00";
        productDetails.Model = "Product 19";
        productDetails.Quantity = "5";
    }

    public void AppleProduct(ProductDetails productDetails)
    {

        productDetails.Name = "Apple Cinema 30";
        productDetails.Brand = "Apple";
        productDetails.Weight = "0.00kg";
        productDetails.Id = 42;
        productDetails.Availability = "In Stock";
        productDetails.UnitPrice = "$76.00";
        productDetails.Model = "Product 15";
        productDetails.Quantity = "6";
        productDetails.Size = "Size: Medium";
    }

    public void iPodShuffleProduct(ProductDetails productDetails)
    {
        productDetails.Name = "iPod Shuffle";
        productDetails.Brand = "HTC";
        productDetails.Weight = "0.00kg";
        productDetails.Id = 34;
        productDetails.Availability = "In Stock";
        productDetails.UnitPrice = "$182.00";
        productDetails.Model = "Product 7";
        productDetails.Quantity = "5";
    }



    public void BoschProduct(ProductDetails productDetails)
    {

        productDetails.Name = "Bosch";
        productDetails.Brand = "Bosch";
        productDetails.Weight = "0.00kg";
        productDetails.Id = 99;
        productDetails.Availability = "In Stock";
        productDetails.UnitPrice = "$298.00";
        productDetails.Model = "Product 15";
        productDetails.Quantity = "6";
    }

}