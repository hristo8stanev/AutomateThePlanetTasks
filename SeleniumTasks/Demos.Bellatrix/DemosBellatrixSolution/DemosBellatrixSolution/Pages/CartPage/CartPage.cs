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
        ProceedToCheckoutButton.Click();
    }
}
