using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemosBellatrixSolution.Pages.BaseWebPage;
using OpenQA.Selenium;
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

        var errorMessageElement = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[class*='checkout-button button alt wc-forward']")));
        MoveToElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
        ProceedToCheckoutButton.Click();
    }
}
