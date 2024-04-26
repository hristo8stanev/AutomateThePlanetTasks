namespace EcommerceLambdaProject.Pages;

public partial class HomePage
{
    public IComponent MyAccount => Driver.FindComponent(By.XPath("//ul[@class='navbar-nav horizontal']//a[contains(@href, 'account/account')]"));
    public IComponent RegisterButton => Driver.FindComponent(By.XPath("//div[@id='main-navigation']//a[contains(@href, 'account/register')]//following-sibling::span"));
    public IComponent LoginButton => Driver.FindComponent(By.XPath("(//div[@id='main-navigation']//a[contains(@href, 'account/login')]//following-sibling::span"));
    public IComponent SearchField => Driver.FindComponent(By.Name("search"));
    public IComponent SearchButton => Driver.FindComponent(By.XPath("//div[@id='search']//button[contains(normalize-space(@type),'submit')]"));
}