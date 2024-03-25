namespace EcommerceLambdaProject.Pages.MyAccountPage;
public partial class MyAccountPages
{

    public IComponent EditMyAccountButton => Driver.FindComponents(By.XPath("//a[contains(@href, 'account/edit')]")).Last();
    public IComponent ChangeMyPasswordButton => Driver.FindComponents(By.XPath("//a[contains(@href, 'account/password')]")).Last();
    public IComponent PasswordField => Driver.FindComponent(By.Id("input-password"));
    public IComponent ConfirmPasswordField => Driver.FindComponent(By.Id("input-confirm"));
    public IComponent ContinueButton => Driver.FindComponent(By.XPath("//*[@value='Continue']"));
    public IComponent SuccessfullyMessageChangePassword => Driver.FindComponent(By.XPath("//*[@class='alert alert-success alert-dismissible']"));
    public IComponent FirstNameInput => Driver.FindComponent(By.Id("input-firstname"));
    public IComponent LastaNameInput => Driver.FindComponent(By.Id("input-lastname"));
    public IComponent EmailAddressNameInput => Driver.FindComponent(By.Id("input-email"));
    public IComponent TelephoneInput => Driver.FindComponent(By.Id("input-telephone"));
    public IComponent RecipientName => Driver.WaitAndFindElementJS(By.XPath("//*[@id='input-to-name']"));
    public IComponent RecipientEmail => Driver.WaitAndFindElementJS(By.XPath("//*[@id='input-to-email']"));
    public IComponent YourName => Driver.WaitAndFindElementJS(By.Id("input-from-name"));
    public IComponent YourEmail => Driver.WaitAndFindElementJS(By.Id("input-from-email"));
    public IComponent BirthdayCertificate => Driver.WaitAndFindElementJS(By.XPath("//*[contains(text(), 'Birthday')]"));
    public IComponent ChristmasCertificate => Driver.WaitAndFindElementJS(By.XPath("//*[contains(text(), ' Christmas')]"));
    public IComponent GeneralCertificate => Driver.WaitAndFindElementJS(By.XPath("//*[contains(text(), ' General')]"));
    public IComponent AmountCertificate => Driver.WaitAndFindElementJS(By.Id("input-amount"));
    public IComponent MessageCertificate => Driver.WaitAndFindElementJS(By.Id("input-message"));
    public IComponent AgreeGiftCertificate => Driver.WaitAndFindElementJS(By.Name("agree"));

}