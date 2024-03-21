namespace EcommerceLambdaProject.Pages.ShoppingCartPage;
public partial class ShoppingCartPages
{

    public IComponent UpdateQuantityButton => Driver.FindComponent(By.XPath("//*[@data-original-title='Update']"));
    public IComponent UpdateQuantityTextField => Driver.FindComponent(By.XPath("//*[@data-original-title='Update']"));
    public IComponent RemoveButton => Driver.FindComponent(By.XPath("//button[contains(@onclick, 'cart.remove')]"));
    public IComponent ProductNameElement => Driver.FindComponent(By.XPath("//table//tr/td[@class='text-left'][1]"));
    public IComponent EmptyShoppingCart => Driver.FindComponent(By.XPath("//p[@class='m-0 py-5 text-center']"));

}
