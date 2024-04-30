namespace EcommerceLambdaProject.Pages;

public partial class MainHeader : WebPage
{
    public MainHeader(IDriver driver)
       : base(driver)
    {
    }

    public override string Url => Urls.Urls.HOME_PAGE;

    public void AddProductToCart(ProductDetails product)
    {
        SearchProductByName(product);
        FindProduct.Click();
        QuantityInput.TypeText(product.Quantity);
        AddToCartButton.Click();
    }

    public void SearchProductByName(ProductDetails product)
    {
        SearchField.TypeText(product.Name);
        Driver.WaitForAjax();
        SearchButton.Click();
    }
}