namespace EcommerceLambdaProject.Pages.LoginPage;
public partial class LoginPages
{

    public IComponent EmailAddressLogin => Driver.FindComponent(By.Id("input-email"));
    public IComponent PasswordLogin => Driver.FindComponent(By.Id("input-password"));
    public IComponent LoginButton => Driver.FindComponent(By.XPath("//*[@value='Login']"));
    public IComponent LogoutButton => Driver.WaitAndFindElementJS(By.XPath("(//a[contains(@href, 'logout')])[2]"));
}