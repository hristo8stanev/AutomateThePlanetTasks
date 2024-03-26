namespace EcommerceLambdaProject.Pages.ShoppingCartPage;
public partial class ShoppingCartPages
{
    
    public IComponent UpdateQuantityButton => Driver.FindComponent(By.XPath("//*[@class='table table-bordered']//td[@class='text-left']//div//button[1]"));
    public IComponent UpdateQuantityTextField => Driver.FindComponent(By.XPath("//*[contains(@type, 'text') and contains(@name, 'quantity')]"));
    public IComponent RemoveButton => Driver.FindComponent(By.XPath("//button[contains(@onclick, 'cart.remove')]"));
    public IComponent ProductNameElement(int id) => Driver.FindComponents(By.XPath($"//tbody//tr//td//a[contains(@href, 'product/product&product_id={id}')]")).Last();
    public IComponent ProductElementInformation(string cell, int index) => Driver.FindComponent(By.XPath($"//*//tbody//tr//td[@class='{cell}']//following-sibling::td[{index}]"));
    public IComponent ProductQuantityInformation(string cell) => Driver.FindComponent(By.XPath($"//*//tbody//tr//td[@class='{cell}']//div[@class='input-group flex-nowrap']//following-sibling::input"));
    public IComponent RemovedProduct(string value) => Driver.FindComponent(By.XPath($"//div[@id='content']//p[contains(text(), '{value}')]"));
}
