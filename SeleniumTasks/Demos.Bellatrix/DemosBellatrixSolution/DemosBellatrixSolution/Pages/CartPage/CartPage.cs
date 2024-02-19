using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AngleSharp.Dom;
using DemosBellatrixSolution.Pages.BaseWebPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumWebdriverHelpers;

namespace DemosBellatrixSolution.Pages.CartPage;
public partial class CartPage : WebPage
{
    public CartPage(IWebDriver driver)
        : base(driver)
    {
    }
    protected override string Url => "https://demos.bellatrix.solutions/cart/";



    public void AppluCouponVaucher(string vaucher)
    {
        CouponCodeField.SendKeys(vaucher);
        ApplyCoupon.Click();
    }

    public void IncreaseProductQuantity(int quantity)
    {
        IncreaseQuantity.Clear();
        IncreaseQuantity.SendKeys("" + quantity);
        UpdateCart.Click();

    }

    public void ProceedToCheckoOut()
    {
        // Thread.Sleep(3000);
        WebDriverWait.Until(driver => string.IsNullOrEmpty(UpdateCart.GetAttribute("disabled")));
        var errorMessageElement = WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(ProceedToCheckoutButton));
        MoveToElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
        ProceedToCheckoutButton.Click();
    }
}
