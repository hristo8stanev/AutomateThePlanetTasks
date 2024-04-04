﻿namespace EcommerceLambdaProject.Pages;

public partial class CheckoutPage
{
    public IComponent ApplyCoupon => Driver.FindComponent(By.XPath("//*[@id='button-coupon'][1]"));
    public IComponent LoginInput => Driver.FindComponent(By.XPath("//*[@for='input-account-login']"));
    public IComponent EmailInput => Driver.FindComponent(By.Id("input-login-email"));
    public IComponent PasswordInput => Driver.FindComponent(By.XPath("//input[@id='input-login-password']"));
    public IComponent LoginButton => Driver.FindComponent(By.XPath("//*[@id='button-login']"));
    public IComponent RegisterAccountType => Driver.FindComponent(By.XPath("//*[@for='input-account-register']"));
    public IComponent GuestAccountType => Driver.FindComponent(By.XPath("//*[@for='input-account-guest']"));
    public IComponent AgreeTerms => Driver.FindComponent(By.XPath("//*[@for='input-agree']"));
    public IComponent ContinueButton => Driver.FindComponent(By.Id("button-save"));
    public IComponent ConfirmOrderButton => Driver.FindComponent(By.Id("button-confirm"));
    public IComponent SuccessfullyConfirmOrderText => Driver.FindComponent(By.XPath("//h1[@class='page-title my-3']"));
    public IComponent FirstNameInput => Driver.FindComponent(By.Id("input-payment-firstname"));
    public IComponent LastNameInput => Driver.FindComponent(By.Id("input-payment-lastname"));
    public IComponent EmailPaymentInput => Driver.FindComponent(By.Id("input-payment-email"));
    public IComponent TelephonePaymentInput => Driver.FindComponent(By.Id("input-payment-telephone"));
    public IComponent PasswordPaymentInput => Driver.FindComponent(By.Id("input-payment-password"));
    public IComponent ConfirmPasswordPaymentInput => Driver.FindComponent(By.Id("input-payment-confirm"));
    public IComponent CompanyInput => Driver.FindComponent(By.Id("input-payment-company"));
    public IComponent AddressField1 => Driver.FindComponent(By.Name("address_1"));
    public IComponent AddressField2 => Driver.FindComponent(By.Name("address_2"));
    public IComponent CityInput => Driver.FindComponent(By.Id("input-payment-city"));
    public IComponent PostCodeInput => Driver.FindComponent(By.Name("postcode"));

    public IComponent Country(string country) => Driver.FindComponent(By.Id("input-payment-country")).FindComponent(By.XPath($".//option[contains(text(), '{country}')]"));

    public IComponent Region(string region) => Driver.FindComponent(By.Id("input-payment-zone")).FindComponent(By.XPath($".//option[contains(text(), '{region}')]"));

    public IComponent AgreePrivacy => Driver.FindComponent(By.XPath("//*[@for='input-account-agree']"));

    public IComponent ConfirmOrderProductName(string cell, string productName) => Driver.FindComponent(By.XPath($"//div[@id='content']//tr/td[@class='{cell}' and normalize-space()='{productName}']"));

    public IComponent ConfirmOrderInformation(string cell, string productInfo) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[@class='{cell}' and contains(text(), '{productInfo}')]"));

    public IComponent ConfirmOrderQuantityElement(string productModel) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[.//preceding-sibling::td[normalize-space()='{productModel}']]"));

    public IComponent ConfirmOrderPriceElement(string quantityOfProduct) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[.//preceding-sibling::td[normalize-space()='{quantityOfProduct}']]"));

    public IComponent ProductNameElement(int id, string name) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[.//a[contains(@href, 'product_id={id}') and normalize-space()='{name}']]//a"));

    public IComponent ProductQuantityElement(int id, string productName) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[.//a[contains(@href, 'product_id={id}') and normalize-space()='{productName}']]//following-sibling::td//input"));

    public IComponent ProductPriceElement(string cell, string price) => Driver.FindComponent(By.XPath($"//div[@id='content']//tr//td[@class='{cell}' and contains(text(), '{price}')]"));
}