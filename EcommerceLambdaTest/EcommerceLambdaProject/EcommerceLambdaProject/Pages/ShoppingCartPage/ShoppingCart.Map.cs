namespace EcommerceLambdaProject.Pages;

public partial class ShoppingCartPage
{
    public IComponent UpdateQuantityButton => Driver.FindComponent(By.XPath("//div[@id='content']//button[contains(normalize-space(@type),'submit')]"));
    public IComponent UpdateQuantityField => Driver.FindComponent(By.XPath("//div[@id='content']//input[contains(normalize-space(@name),'quantity')]"));
    public IComponent RemoveButton => Driver.FindComponent(By.XPath("//button[contains(@onclick, 'cart.remove')]"));

    public IComponent ProductNameElement(int id, string productName) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[.//a[contains(@href, 'product_id={id}') and normalize-space()='{productName}']]"));

    public IComponent ProductPriceElement(string price) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[@class='text-right' and contains(text(), '{price}')]"));

    public IComponent ProductModel(string modelProduct) => Driver.FindComponent(By.XPath($"//div[@id='content']//tbody//td[contains(text(), '{modelProduct}')]"));

    public IComponent ProductTotalPriceElement(string price) => Driver.FindComponent(By.XPath($"//div[@id='content']//tbody//td[contains(text(), '{price}')]"));

    public IComponent ProductQuantity(string cell) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[.//input[@class='{cell}']]//following-sibling::input"));

    public IComponent RemovedProduct(string value) => Driver.FindComponent(By.XPath($"//div[@id='content']//p[contains(text(), '{value}')]"));
}