using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemosBellatrixSolution.Pages.CartPage;
public partial class CartPage
{
    public IWebElement IncreaseQuantity => WaitAndFindElement(By.XPath("//input[@type='number']"));
    public IWebElement RemoveProduct => WaitAndFindElement(By.XPath("//a[@class='remove']"));
    public IWebElement CouponCodeField => WaitAndFindElement(By.XPath("//input[@name='coupon_code']"));
    public IWebElement ApplyCoupon => WaitAndFindElement(By.XPath("//button[@name='apply_coupon']"));
    public IWebElement ProceedToCheckout => WaitAndFindElement(By.XPath("//a[@class='checkout-button button alt wc-forward']"));
    public IWebElement UpdateCart => WaitAndFindElement(By.XPath("//button[@name='update_cart']"));
    public IWebElement appliedCoupon => WaitAndFindElement(By.XPath("//tr[@class='cart-discount coupon-happybirthday']"));

}
