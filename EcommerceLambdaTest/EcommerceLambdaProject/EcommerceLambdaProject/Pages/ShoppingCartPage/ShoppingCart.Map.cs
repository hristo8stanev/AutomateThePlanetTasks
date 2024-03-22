namespace EcommerceLambdaProject.Pages.ShoppingCartPage;
public partial class ShoppingCartPages
{
    
    public IComponent UpdateQuantityButton => Driver.FindComponent(By.XPath("//*[@class='table table-bordered']//td[@class='text-left']//div//button[1]"));
    public IComponent UpdateQuantityTextField => Driver.FindComponent(By.XPath("//*[contains(@type, 'text') and contains(@name, 'quantity')]"));
    public IComponent RemoveButton => Driver.FindComponent(By.XPath("//button[contains(@onclick, 'cart.remove')]"));
    public IComponent ProductNameElement => Driver.FindComponent(By.XPath("//table//tr/td[@class='text-left'][1]"));
    public IComponent RemovedProduct(string value) => Driver.FindComponent(By.XPath($"//div[@id='content']//p[contains(text(), '{value}')]"));
}
