using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemosBellatrixSolution.Pages;
using DemosBellatrixSolution.Pages.CheckoutPage;
using OpenQA.Selenium;

namespace DemosBellatrixSolution.Pages.MainPage;
public partial class BellatrixMainPage : WebPage
{
    public BellatrixMainPage(IWebDriver driver)
        : base(driver)
    {
    }
    protected override string Url => "https://demos.bellatrix.solutions/";


    public void AddRocketToCart(string rocket)
    {
        SearchField.SendKeys(rocket + Keys.Enter);
        AddToCartButton.Click();
        ViewCartButton.Click();
    }
}
