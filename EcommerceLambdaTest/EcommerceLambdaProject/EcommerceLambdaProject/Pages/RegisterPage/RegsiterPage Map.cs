namespace EcommerceLambdaProject.Pages;

public partial class RegisterPage
{
    public IComponent FirstNameInput => Driver.FindComponent(By.Id("input-firstname"));
    public IComponent LastNameInput => Driver.FindComponent(By.Id("input-lastname"));
    public IComponent EmailAddressNameInput => Driver.FindComponent(By.Id("input-email"));
    public IComponent TelephoneInput => Driver.FindComponent(By.Id("input-telephone"));
    public IComponent PasswordInput => Driver.FindComponent(By.Id("input-password"));
    public IComponent ConfirmPasswordInput => Driver.FindComponent(By.Id("input-confirm"));
    public IComponent AgreePrivacy => Driver.FindComponent(By.XPath("//*[@for='input-agree']"));
    public IComponent ContinueButton => Driver.FindComponent(By.XPath("//*[@value='Continue']"));
    public IComponent LogoutButton => Driver.FindComponent(By.XPath("(//a[contains(@href, 'logout')])[2]"));
    public IComponent ErrorMessageEmptyFistNameField => Driver.FindComponent(By.XPath("//*[@id='input-firstname']//following-sibling::div"));
    public IComponent ErrorMessageEmptyEmailAddressField => Driver.FindComponent(By.XPath("//*[@id='input-email']//following-sibling::div"));
    public IComponent ErrorMessageEmptyPasswordField => Driver.FindComponent(By.XPath("//*[@id='input-password']//following-sibling::div"));
}