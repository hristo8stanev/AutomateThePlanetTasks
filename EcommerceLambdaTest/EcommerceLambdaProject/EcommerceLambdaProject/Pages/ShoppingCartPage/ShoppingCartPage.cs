using OpenQA.Selenium;

namespace EcommerceLambdaProject.Pages.ShoppingCartPage;
public partial class ShoppingCartPages : WebPage
{
    public ShoppingCartPages(IDriver driver) : base(driver)
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
