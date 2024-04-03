namespace EcommerceLambdaProject.Pages;

public partial class ShoppingCartPage : WebPage
{
    public ShoppingCartPage(IDriver driver) : base(driver)
    {
    }

    public override string Url => Urls.Urls.CART_PAGE;

    public void UpdateQuantity(string product)
    {
        UpdateQuantityTextField.TypeText(product);
        UpdateQuantityButton.Click();
    }

    public void RemoveProductFromTheCart()
    {
        Driver.WaitForAjax();
        RemoveButton.Click();
    }
}