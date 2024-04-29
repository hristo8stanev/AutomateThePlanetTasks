namespace EcommerceLambdaProject.Pages;

public partial class SearchPage
{
    public IComponent SearchInput => Driver.FindComponent(By.XPath("//div[@id='product-search']//input[contains(normalize-space(@id),'input-search')]"));
    public IComponent SearchButton => Driver.FindComponent(By.Id("button-search"));

    public IComponent GetProductName(int id, string name) => Driver.FindComponent(By.XPath($"//h4[.//a[contains(@href, 'product_id={id}') and normalize-space()='{name}']]"));

    public IComponent GetProductPrice => Driver.FindComponent(By.XPath("//div[@id='product-search']//span[contains(normalize-space(@class),'price-new')]"));

    public IComponent ErrorMessageNonExistingProduct(string message) => Driver.FindComponent(By.XPath($"//p[contains(text(),'{message}')]"));

    public IComponent MinPriceField => Driver.FindComponent(By.XPath("//div[@class='content']//div//input[contains(normalize-space(@placeholder), 'Minimum Price')]"));
    public IComponent MaxPriceField => Driver.FindComponent(By.XPath("//div[@class='content']//div//input[contains(normalize-space(@placeholder), 'Maximum Price')]"));
}