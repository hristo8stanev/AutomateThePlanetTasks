namespace EcommerceLambdaProject.Pages;

public partial class LoginPage
{
    public IComponent EmailAddressLogin => Driver.FindComponent(By.Id("input-email"));
    public IComponent PasswordLogin => Driver.FindComponent(By.Id("input-password"));
    public IComponent LoginButton => Driver.FindComponent(By.XPath("//*[@value='Login']"));
    public IComponent LogoutButton => Driver.WaitAndFindElementJS(By.XPath("(//a[contains(@href, 'logout')])[2]"));
    public IComponent ForgotPasswordButton => Driver.WaitAndFindElementJS(By.XPath("//div[@class='form-group']//following-sibling::a"));
    public IComponent EmailAddressFieldForgotPassword => Driver.FindComponent(By.Name("email"));
    public IComponent ContinueButton => Driver.FindComponent(By.XPath("//div[@class='buttons clearfix']//following-sibling::button"));
    public IComponent ConfirmationMessage => Driver.FindComponent(By.XPath("//div[@class='alert alert-success alert-dismissible']"));
    public IComponent WarningMessage => Driver.FindComponent(By.XPath("//div[@class='alert alert-danger alert-dismissible']"));
    public IComponent AccountLogout => Driver.FindComponent(By.XPath("//h1[@class='page-title my-3']"));
}