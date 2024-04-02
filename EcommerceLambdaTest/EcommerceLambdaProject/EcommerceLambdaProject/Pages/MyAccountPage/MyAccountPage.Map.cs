namespace EcommerceLambdaProject.Pages;

public partial class MyAccountPage
{
    public IComponent EditMyAccountButton => Driver.FindComponents(By.XPath("//a[contains(@href, 'account/edit')]")).Last();
    public IComponent ChangeMyPasswordButton => Driver.FindComponents(By.XPath("//a[contains(@href, 'account/password')]")).Last();
    public IComponent AddressBookSection => Driver.FindComponents(By.XPath("//a[contains(@href, 'account/address')]")).Last();
    public IComponent NewAddressButton => Driver.FindComponent(By.XPath("//a[@class='btn btn-primary' and contains(text(),'New Address')]"));
    public IComponent CompanyField => Driver.FindComponent(By.Id("input-company"));
    public IComponent AddressField1 => Driver.FindComponent(By.Id("input-address-1"));
    public IComponent AddressField2 => Driver.FindComponent(By.Id("input-address-2"));
    public IComponent CityField => Driver.FindComponent(By.Id("input-city"));
    public IComponent PostCodeField => Driver.FindComponent(By.Id("input-postcode"));
    public IComponent CountryField => Driver.FindComponent(By.Id("input-country"));
    public IComponent firstName => Driver.FindComponent(By.XPath("//*[@id='input-payment-firstname']"));
    public IComponent lastName => Driver.FindComponent(By.XPath("//*[@id='input-payment-lastname']"));

    public IComponent SelectCountry(string country) => CountryField.FindComponent(By.XPath($".//option[contains(text(), '{country}')]"));

    public IComponent Region => Driver.FindComponent(By.Id("input-zone"));

    public IComponent SelectRegion(string region) => Region.FindComponent(By.XPath($".//option[contains(text(), '{region}')]"));

    public IComponent PasswordField => Driver.FindComponent(By.Id("input-password"));
    public IComponent ConfirmPasswordField => Driver.FindComponent(By.Id("input-confirm"));
    public IComponent ContinueButton => Driver.FindComponent(By.XPath("//*[@value='Continue']"));
    public IComponent SuccessfullyMessage => Driver.FindComponent(By.XPath("//*[@class='alert alert-success alert-dismissible']"));
    public IComponent SuccessfullyPurchaseCertificate => Driver.FindComponent(By.XPath("//h1[@class='page-title my-3']"));
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

    public IComponent DateTimeElement(string dateTime) => Driver.FindComponent(By.XPath($"//div[@id='content']//tr/td[@class='text-left' and contains(text(), '{dateTime}')]"));

    public IComponent CustomerElement(string name) => Driver.FindComponent(By.XPath($"//div[@id='content']//tr/td[@class='text-left' and contains(text(), '{name}')]"));
}