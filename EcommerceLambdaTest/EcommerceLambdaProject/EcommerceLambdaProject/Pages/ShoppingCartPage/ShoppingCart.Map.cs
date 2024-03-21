namespace EcommerceLambdaProject.Pages.ShoppingCartPage;
public partial class ShoppingCartPages
{

    public IComponent UpdateQuantityButton => Driver.FindComponent(By.XPath("//*[@data-original-title='Update']"));
    public IComponent UpdateQuantityTextField => Driver.FindComponent(By.XPath("//*[@data-original-title='Update']"));
    public IComponent RemoveButton => Driver.WaitAndFindElementJS(By.Id("//*[@data-original-title='Remove']"));

}
