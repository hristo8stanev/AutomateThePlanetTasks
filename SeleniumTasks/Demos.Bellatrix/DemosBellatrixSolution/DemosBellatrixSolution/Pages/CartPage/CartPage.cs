using DemosBellatrixSolution.Pages.BaseWebPage;
using OpenQA.Selenium;

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
         Thread.Sleep(3000);
       // var waitProceedButtonToBeClickable = _webDriverWait.Until(ExpectedConditions.ElementToBeClickable(ProceedToCheckoutButton));
       // _webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'Cart updated')]")));
       //_webDriverWait.Until(_driver => !CartTotals.GetAttribute("class").Contains("processing"));
        MoveToElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
        ProceedToCheckoutButton.Click();
    }
}
