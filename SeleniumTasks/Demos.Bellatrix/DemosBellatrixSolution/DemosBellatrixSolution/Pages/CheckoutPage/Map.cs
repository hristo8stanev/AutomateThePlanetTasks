using OpenQA.Selenium;

namespace DemosBellatrixSolution.Pages.CheckoutPage;
public partial class CheckoutPage
{
    public IWebElement BillingFirstName => WaitAndFindElement(By.Id("billing_first_name"));
    public IWebElement BillingLastName => WaitAndFindElement(By.Id("billing_last_name"));
    public IWebElement BillingCompany => WaitAndFindElement(By.Id("billing_company"));
    public IWebElement BillingAddress1 => WaitAndFindElement(By.Id("billing_address_1"));
    public IWebElement BillingAddress2 => WaitAndFindElement(By.Id("billing_address_2"));
    public IWebElement BillingCountryWrapper => WaitAndFindElement(By.Id("select2-billing_country-container"));
    public IWebElement BillingCountryFilter => WaitAndFindElement(By.XPath("//input[@class='select2-search__field']"));
    public IWebElement GetCountryByName(string countryName) => WaitAndFindElement(By.XPath($"//*[contains(text(),'{countryName}')]"));
    public IWebElement BillingCountry => WaitAndFindElement(By.XPath("//span[@id='select2-billing_country-container']"));
    public IWebElement BillingCity => WaitAndFindElement(By.Id("billing_city"));
    public IWebElement BillingZip => WaitAndFindElement(By.Id("billing_postcode"));
    public IWebElement BillingPhone => WaitAndFindElement(By.Id("billing_phone"));
    public IWebElement BillingEmail => WaitAndFindElement(By.Id("billing_email"));
    public IWebElement PlaceOrderButton => WaitAndFindElement(By.Id("place_order"));
    public IWebElement ShowCoupon => WaitAndFindElement(By.XPath("//a[@class='showcoupon']"));
    public IWebElement CreateAccountButtonBox => WaitAndFindElement(By.Id("createaccount"));
    public IWebElement CheckPaymentsButton => WaitElementToBeClickable(By.CssSelector("[for*='payment_method_cheque']"));
    public IWebElement OrderReceive => WaitAndFindElement(By.XPath("//h1"));

}
