namespace EcommerceLambdaProject.Pages;

public partial class ShoppingCartPage : WebPage
{
    public ShoppingCartPage(IDriver driver)
        : base(driver)
    {
    }

    public override string Url => CART_PAGE;

    public void UpdateQuantity(string product)
    {
        UpdateQuantityField.TypeText(product);
        UpdateQuantityButton.Click();
    }

    public void RemoveProductFromCart()
    {
        Driver.WaitForAjax();
        RemoveButton.Click();
    }
}