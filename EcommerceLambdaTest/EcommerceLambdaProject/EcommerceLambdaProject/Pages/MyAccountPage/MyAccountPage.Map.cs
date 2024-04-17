﻿namespace EcommerceLambdaProject.Pages;

public partial class MyAccountPage
{
    public IComponent EditMyAccountButton => Driver.FindComponents(By.XPath("//a[contains(@href, 'account/edit')]")).Last();
    public IComponent ChangeMyPasswordButton => Driver.FindComponents(By.XPath("//a[contains(@href, 'account/password')]")).Last();
    public IComponent AddressBookButton => Driver.FindComponents(By.XPath("//a[contains(@href, 'account/address')]")).Last();
    public IComponent NewAddressButton => Driver.FindComponent(By.XPath("//a[@class='btn btn-primary' and contains(text(),'New Address')]"));
    public IComponent CompanyInput => Driver.FindComponent(By.Id("input-company"));
    public IComponent AddressInput1 => Driver.FindComponent(By.Id("input-address-1"));
    public IComponent AddressInput2 => Driver.FindComponent(By.Id("input-address-2"));
    public IComponent CityInput => Driver.FindComponent(By.Id("input-city"));
    public IComponent PostCodeInput => Driver.FindComponent(By.Id("input-postcode"));
    public IComponent FirstNameInputPayment => Driver.FindComponent(By.XPath("//*[@id='input-payment-firstname']"));
    public IComponent LastNameInputPayment => Driver.FindComponent(By.XPath("//*[@id='input-payment-lastname']"));
    public IComponent OrderIdInput => Driver.FindComponent(By.Id("input-order-id"));
    public IComponent ProductNameInput => Driver.FindComponent(By.Id("input-product"));
    public IComponent ProductCodeInput => Driver.FindComponent(By.Id("input-model"));
    public IComponent OrderDateInput => Driver.FindComponent(By.Id("input-date-ordered"));
    public IComponent ProductQuantityInput => Driver.FindComponent(By.Id("input-quantity"));

    public IComponent ReturnReasonInput(int reasonId) => Driver.FindComponent(By.XPath($"//div[@id='content']//input[@name='return_reason_id' and @value='{reasonId}']"));

    public IComponent ProductOpenedInput(int reasonId) => Driver.FindComponent(By.XPath($"//div[@id='content']//input[@name='opened' and @value='{reasonId}']"));

    public IComponent Country(string country) => Driver.FindComponent(By.Id("input-country")).FindComponent(By.XPath($".//option[contains(text(), '{country}')]"));

    public IComponent Region(string region) => Driver.FindComponent(By.Id("input-zone")).FindComponent(By.XPath($".//option[contains(text(), '{region}')]"));

    public IComponent PasswordInput => Driver.FindComponent(By.Id("input-password"));
    public IComponent ConfirmPasswordInput => Driver.FindComponent(By.Id("input-confirm"));

    public IComponent SubmitButton => Driver.FindComponent(By.XPath("//*[@value='Submit']"));
    public IComponent ContinueButton => Driver.FindComponent(By.XPath("//*[@value='Continue']"));
    public IComponent SuccessfullyMessage => Driver.FindComponent(By.XPath("//*[@class='alert alert-success alert-dismissible']"));

    public IComponent SuccessfullyProductReturn(string expectedMessage) => Driver.FindComponent(By.XPath($"//div[@id='content']//p[contains(text(),'{expectedMessage}')]"));

    public IComponent SuccessfullyPurchaseCertificate => Driver.FindComponent(By.XPath("//h1[@class='page-title my-3']"));
    public IComponent FirstNameInput => Driver.FindComponent(By.Id("input-firstname"));
    public IComponent LastNameInput => Driver.FindComponent(By.Id("input-lastname"));
    public IComponent EmailAddressNameInput => Driver.FindComponent(By.Id("input-email"));
    public IComponent TelephoneInput => Driver.FindComponent(By.Id("input-telephone"));
    public IComponent RecipientNameInput => Driver.FindComponent(By.XPath("//*[@id='input-to-name']"));
    public IComponent RecipientEmailInput => Driver.FindComponent(By.XPath("//*[@id='input-to-email']"));
    public IComponent YourNameInput => Driver.FindComponent(By.Id("input-from-name"));
    public IComponent YourEmailInput => Driver.FindComponent(By.Id("input-from-email"));
    public IComponent BirthdayCertificate => Driver.FindComponent(By.XPath("//*[contains(text(), 'Birthday')]"));
    public IComponent ChristmasCertificate => Driver.FindComponent(By.XPath("//*[contains(text(), ' Christmas')]"));
    public IComponent GeneralCertificate => Driver.FindComponent(By.XPath("//*[contains(text(), ' General')]"));
    public IComponent AmountCertificateInput => Driver.FindComponent(By.Id("input-amount"));
    public IComponent MessageCertificate => Driver.FindComponent(By.Id("input-message"));
    public IComponent AgreeGiftCertificate => Driver.FindComponent(By.Name("agree"));

    public IComponent DateTimeElement(string dateTime) => Driver.FindComponent(By.XPath($"//div[@id='content']//tr/td[@class='text-left' and contains(text(), '{dateTime}')]"));

    public IComponent CustomerElement(string name) => Driver.FindComponent(By.XPath($"//div[@id='content']//tr/td[@class='text-left' and contains(text(), '{name}')]"));

    public IComponent GiftPriceNameElement(string amount, string name) => Driver.FindComponent(By.XPath($"//div[@id='content']//tr/td[@class='text-left' and contains(text(), '${amount}.00 Gift Certificate for {name}')]"));

    public IComponent MyAccountMenuSection => Driver.FindComponent(By.XPath("//ul[@class='navbar-nav horizontal']//li[.//a[contains(@href, 'account/account')]]"));
    public IComponent MyOrderHistoryButton => Driver.FindComponent(By.XPath("//div[@id='content']//div[.//a[contains(@href, 'account/order')]]//a[contains(text(), ' View your order history')]"));
    public IComponent MyVoucherButton => MyAccountMenuSection.FindComponents(By.XPath("//li[.//a[contains(@href, 'account/voucher') and normalize-space()='My voucher']]")).Last();
    public IComponent ReturnOrderButton => MyAccountMenuSection.FindComponents(By.XPath("//li[.//a[contains(@href, 'account') and normalize-space()='Return']]")).Last();
    public IComponent RemoveButton => Driver.FindComponent(By.XPath("//button[contains(@onclick, 'voucher.remove')]"));
    public IComponent RemovedProduct(string value) => Driver.FindComponent(By.XPath($"//div[@id='content']//p[contains(text(), '{value}')]"));
}