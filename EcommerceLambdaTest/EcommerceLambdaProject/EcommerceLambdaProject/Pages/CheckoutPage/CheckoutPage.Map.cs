namespace EcommerceLambdaProject.Pages.CheckoutPage;
public partial class CheckoutPages
{
    public IComponent ApplyCoupon => Driver.FindComponent(By.XPath("//*[@id='button-coupon'][1]"));
    public IComponent LoginAccType => Driver.FindComponent(By.XPath("//*[@for='input-account-login']"));
    public IComponent EmailField => Driver.FindComponent(By.Id("input-login-email"));
    public IComponent PasswordField => Driver.FindComponent(By.Id("input-login-password"));
    public IComponent LoginButton => Driver.FindComponent(By.XPath("//*[@id='button-login']"));
    public IComponent RegisterAccType => Driver.FindComponent(By.XPath("//*[@for='input-account-register']"));
    public IComponent GuestAccType => Driver.FindComponent(By.XPath("//*[@for='input-account-guest']"));
    public IComponent AgreeTerms => Driver.FindComponent(By.XPath("//*[@for='input-agree']"));
    public IComponent ContinueButton => Driver.FindComponent(By.Id("button-save"));
    public IComponent ConfirmOrderButton => Driver.FindComponent(By.Id("button-confirm"));
    public IComponent SuccessfullyConfirmOrderText => Driver.WaitAndFindElementJS(By.XPath("//h1[@class='page-title my-3']"));
    public IComponent FirstNameField => Driver.FindComponent(By.Id("input-payment-firstname"));
    public IComponent LastNameField => Driver.FindComponent(By.Id("input-payment-lastname"));
    public IComponent EmailPaymentField => Driver.FindComponent(By.Id("input-payment-email"));
    public IComponent TelephonePaymentField => Driver.FindComponent(By.Id("input-payment-telephone"));
    public IComponent PasswordPaymentField => Driver.FindComponent(By.Id("input-payment-password"));
    public IComponent ConfirmPasswordPaymentField => Driver.FindComponent(By.Id("input-payment-confirm"));
    public IComponent CompanyField => Driver.FindComponent(By.Id("input-payment-company"));
    public IComponent AddressField1 => Driver.FindComponent(By.Name("address_1"));
    public IComponent AddressField2 => Driver.FindComponent(By.Name("address_2"));
    public IComponent CityField => Driver.FindComponent(By.Id("input-payment-city"));
    public IComponent PostCodeField => Driver.FindComponent(By.Name("postcode"));
    public IComponent CountryField => Driver.FindComponent(By.Id("input-payment-country"));
    public IComponent SelectCountry(string country) => CountryField.FindComponent(By.XPath($".//option[contains(text(), '{country}')]"));
    public IComponent Region => Driver.FindComponent(By.Id("input-payment-zone"));
    public IComponent SelectRegion(string region) => Region.FindComponent(By.XPath($".//option[contains(text(), '{region}')]"));
    public IComponent AgreePrivacy => Driver.FindComponent(By.XPath("//*[@for='input-account-agree']"));
    public IComponent ConfirmOrderProductName(string cell, string productName) => Driver.FindComponent(By.XPath($"//div[@id='content']//tr/td[@class='{cell}' and normalize-space()='{productName}']"));
    public IComponent ConfirmOrderInformation(string cell, string productInfo) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[@class='{cell}' and contains(text(), '{productInfo}')]"));
    public IComponent ConfirmOrderQuantityElement(string productModel) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[.//preceding-sibling::td[normalize-space()='{productModel}']]"));
    public IComponent ConfirmOrderPriceElement (string quantityOfProduct) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[.//preceding-sibling::td[normalize-space()='{quantityOfProduct}']]"));
    public IComponent ProductNameElementCheckoutPage(int id, string name) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[.//a[contains(@href, 'product_id={id}') and normalize-space()='{name}']]//a"));
    public IComponent ProductQuantityElementCheckout(int id, string productName) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[.//a[contains(@href, 'product_id={id}') and normalize-space()='{productName}']]//following-sibling::td//input")); 
    public IComponent ProductPriceElementCheckout(string cell, string price) => Driver.FindComponent(By.XPath($"//div[@id='content']//tr//td[@class='{cell}' and contains(text(), '{price}')]"));
}