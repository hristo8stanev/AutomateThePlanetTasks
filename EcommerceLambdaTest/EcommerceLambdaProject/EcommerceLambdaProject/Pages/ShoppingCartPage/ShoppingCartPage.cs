namespace EcommerceLambdaProject.Pages;

public partial class ShoppingCartPage : WebPage
{
    public ShoppingCartPage(IDriver driver) : base(driver)
    {
    }

    public void UpdateQuantity(string product)
    {
        UpdateQuantityTextField.TypeText(product);
        UpdateQuantityButton.Click();
    }

    public void RemoveProductFromTheCart()
    {
        RemoveButton.Click();
    }
}