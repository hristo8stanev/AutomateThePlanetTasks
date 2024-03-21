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
    
    public void RemoveFromCart()
    {


    }
}
