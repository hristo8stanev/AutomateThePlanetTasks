namespace EcommerceLambdaProject.Pages;

public partial class LoginPage
{
    public IComponent EmailAddressInput => Driver.FindComponent(By.Id("input-email"));
    public IComponent PasswordInput => Driver.FindComponent(By.Id("input-password"));
    public IComponent LoginButton => Driver.FindComponent(By.XPath("//*[@value='Login']"));
    public IComponent LogoutButton => Driver.FindComponent(By.XPath("(//a[contains(@href, 'logout')])[2]"));
    public IComponent ForgotPasswordButton => Driver.FindComponent(By.XPath("//div[@class='form-group']//following-sibling::a"));
    public IComponent EmailAddress => Driver.FindComponent(By.Name("email"));
    public IComponent ContinueButton => Driver.FindComponent(By.XPath("//div[@class='buttons clearfix']//following-sibling::button"));
    public IComponent ConfirmationMessage => Driver.FindComponent(By.XPath("//div[@class='alert alert-success alert-dismissible']"));
    public IComponent WarningMessage => Driver.FindComponent(By.XPath("//div[@class='alert alert-danger alert-dismissible']"));
    public IComponent AccountLogout => Driver.FindComponent(By.XPath("//h1[@class='page-title my-3']"));
}