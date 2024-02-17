using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemosBellatrixSolution.Pages.CheckoutPage;
public partial class CheckoutPage
{
    public IWebElement BillingFirstName => WaitAndFindElement(By.XPath("//input[@name='billing_first_name']"));
    public IWebElement BillingLastName => WaitAndFindElement(By.XPath(" //input[@name='billing_last_name']"));
    public IWebElement BillingCompany => WaitAndFindElement(By.XPath("//input[@name='billing_company']"));
    public IWebElement BillingAddress => WaitAndFindElement(By.XPath("//input[@name='billing_address_1']"));
    public IWebElement CountryWrapper => WaitAndFindElement(By.XPath("//span[@class='select2-selection__arrow']"));
    public IWebElement BillingCountry => WaitAndFindElement(By.XPath("//span[@id='select2-billing_country-container']"));
    public IWebElement BillingCity => WaitAndFindElement(By.XPath("//input[@name='billing_city']"));
    public IWebElement BillingPostCode => WaitAndFindElement(By.XPath("//input[@name='billing_postcode']"));
    public IWebElement BillingPhone => WaitAndFindElement(By.XPath("//input[@name='billing_phone']"));
    public IWebElement BillingEmail => WaitAndFindElement(By.XPath("//input[@name='billing_email']"));
    public IWebElement BillingOrder => WaitAndFindElement(By.XPath("//button[@id='place_order']"));
    public IWebElement PlaceOrder => WaitAndFindElement(By.XPath("//button[@id='place_order']"));
    public IWebElement ShowCoupon => WaitAndFindElement(By.XPath("//a[@class='showcoupon']"));

}
