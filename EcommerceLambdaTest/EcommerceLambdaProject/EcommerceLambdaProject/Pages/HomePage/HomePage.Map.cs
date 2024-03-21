
namespace EcommerceLambdaProject.Pages.HomePage;
public partial class HomePages
{

    public IComponent MyAccount => Driver.FindComponent(By.XPath("(//*[contains(text(), 'My account')])[2])"));
    public IComponent RegisterButton => Driver.FindComponent(By.XPath("//*[@class='list-group-item'][1]"));
    public IComponent LoginButton => Driver.FindComponent(By.XPath("(//*[contains(text(), 'Login')])[2]"));
    public IComponent SearchField => Driver.FindComponent(By.Name("search"));
   // public IComponent FindProduct(string value) => Driver.FindComponent(By.XPath($"//h4/a[text()='{value}']"));
    public IComponent SearchButton => Driver.FindComponent(By.XPath("//*[@title='Search']"));
}
