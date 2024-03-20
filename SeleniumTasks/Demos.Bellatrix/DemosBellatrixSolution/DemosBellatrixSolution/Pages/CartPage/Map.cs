using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace DemosBellatrixSolution.Pages.CartPage;
public partial class CartPage
{
    public IWebElement IncreaseQuantity => WaitAndFindElement(By.XPath("//input[@type='number']"));
    public IWebElement RemoveProduct => WaitAndFindElement(By.XPath("//a[@class='remove']"));
    public IWebElement CouponCodeField => WaitAndFindElement(By.XPath("//input[@name='coupon_code']"));
    public IWebElement ApplyCoupon => WaitAndFindElement(By.XPath("//button[@name='apply_coupon']"));
    public IWebElement ProceedToCheckoutButton => MoveToElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
    public IWebElement UpdateCart => WaitAndFindElement(By.XPath("//button[@name='update_cart']"));
    public IWebElement AppliedCoupon => WaitAndFindElement(By.XPath("//tr[@class='cart-discount coupon-happybirthday']"));
    public IWebElement CartTotals => WaitAndFindElement(By.XPath("//*[@class='cart_totals']"));
    public IWebElement CartHeader => MoveToElement(By.XPath("//*[@id='site-header-cart']"));
    public IWebElement CountProductElement => WaitAndFindElement(By.XPath("(//*[@class='count'])[1]"));


}
