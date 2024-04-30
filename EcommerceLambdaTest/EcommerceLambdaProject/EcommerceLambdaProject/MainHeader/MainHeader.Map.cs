namespace EcommerceLambdaProject.Pages;

public partial class MainHeader

{
    public IComponent MyAccount => Driver.FindComponent(By.XPath("//ul[@class='navbar-nav horizontal']//a[contains(@href, 'account/account')]"));
    public IComponent RegisterButton => Driver.FindComponent(By.XPath("//div[@id='main-navigation']//a[contains(@href, 'account/register')]//following-sibling::span"));
    public IComponent LoginButton => Driver.FindComponent(By.XPath("(//div[@id='main-navigation']//a[contains(@href, 'account/login')]//following-sibling::span"));
    public IComponent SearchField => Driver.FindComponent(By.Name("search"));
    public IComponent FindProduct => Driver.FindComponent(By.XPath("//h4/a"));
    public IComponent QuantityInput => Driver.FindComponent(By.XPath("//div[@id='product-product']//input[contains(normalize-space(@name), 'quantity')]"));
    public IComponent AddToCartButton => Driver.FindComponent(By.XPath("//div[@class='content']//button[contains(text(),'Add to Cart')]"));
    public IComponent SearchButton => Driver.FindComponent(By.XPath("//div[@id='search']//button[contains(normalize-space(@type),'submit')]"));
}