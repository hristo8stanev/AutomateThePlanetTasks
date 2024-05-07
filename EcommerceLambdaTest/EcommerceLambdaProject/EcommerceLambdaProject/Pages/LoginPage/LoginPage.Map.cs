namespace EcommerceLambdaProject.Pages;

public partial class LoginPage
{
    public IComponent EmailAddressInput => Driver.FindComponent(By.Id("input-email"));
    public IComponent PasswordInput => Driver.FindComponent(By.Id("input-password"));
    public IComponent LoginButton => Driver.FindComponent(By.XPath("//*[@value='Login']"));
    public IComponent MyAccountNavigationBarElement => Driver.FindComponent(By.XPath("//ul[@class='navbar-nav horizontal']//a[contains(@href, 'account/account')]"));
    public IComponent LogoutButton => Driver.FindComponent(By.XPath("//div[@id='account-account']//a[contains(normalize-space(@href),'account/logout')]"));
    public IComponent ForgotPasswordButton => Driver.FindComponent(By.XPath("//div[@id='content']//a[contains(normalize-space(@href),'account/forgotten')]"));
    public IComponent EmailAddress => Driver.FindComponent(By.Name("email"));
    public IComponent ContinueButton => Driver.FindComponent(By.XPath("//div[@id='content']//button[contains(normalize-space(@type),'submit')]"));
    public IComponent ConfirmationMessage => Driver.FindComponent(By.XPath("//div[@id='account-login']//div[contains(normalize-space(@class), 'alert alert-success')]"));
    public IComponent WarningMessage => Driver.FindComponent(By.XPath("//div[@id='account-login']//div[contains(normalize-space(@class), 'alert alert-danger')]"));
    public IComponent AccountLogout => Driver.FindComponent(By.XPath("//h1[@class='page-title my-3']"));
}