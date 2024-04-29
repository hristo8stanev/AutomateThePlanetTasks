namespace EcommerceLambdaProject.Pages;

public partial class RegisterPage
{
    public IComponent FirstNameInput => Driver.FindComponent(By.Id("input-firstname"));
    public IComponent LastNameInput => Driver.FindComponent(By.Id("input-lastname"));
    public IComponent EmailAddressNameInput => Driver.FindComponent(By.Id("input-email"));
    public IComponent TelephoneInput => Driver.FindComponent(By.Id("input-telephone"));
    public IComponent PasswordInput => Driver.FindComponent(By.Id("input-password"));
    public IComponent ConfirmPasswordInput => Driver.FindComponent(By.Id("input-confirm"));
    public IComponent AgreePrivacy => Driver.FindComponent(By.XPath("//div[@id='content']//label[contains(normalize-space(@for),'input-agree')]"));
    public IComponent ContinueButton => Driver.FindComponent(By.XPath("//div[@id='content']//input[contains(normalize-space(@type),'submit')]"));
    public IComponent LogoutButton => Driver.FindComponent(By.XPath("//aside[@id='column-right']//a[contains(normalize-space(@href),'account/logout')]"));
    public IComponent ErrorMessageEmptyFistNameField => Driver.FindComponent(By.XPath("//div[@id='content']//div[contains(normalize-space(@class),'text-danger')]"));
    public IComponent ErrorMessageEmptyEmailAddressField => Driver.FindComponent(By.XPath("//div[@id='content']//div[contains(normalize-space(@class),'text-danger')]"));
    public IComponent ErrorMessageEmptyPasswordField => Driver.FindComponent(By.XPath("//div[@id='content']//div[contains(normalize-space(@class),'text-danger')]"));
}