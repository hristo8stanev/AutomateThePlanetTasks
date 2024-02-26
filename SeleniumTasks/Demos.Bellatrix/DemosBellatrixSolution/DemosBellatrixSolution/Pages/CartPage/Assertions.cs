using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace DemosBellatrixSolution.Pages.CartPage;
public partial class CartPage
{
 
    public void AssertCouponApplied()
    {
        var couponElement = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@class='cart-discount coupon-happybirthday']")));
        bool isDisplayed = couponElement.Displayed;
        Assert.That(isDisplayed);
    }

   public void AssertQuantityOfTheProductCartPage(int expectedQuantity)
   {
        Thread.Sleep(2000);
        MoveToElement(By.XPath("//*[@id='site-header-cart']"));
        var quantity = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//*[@class='count'])[1]"))).Text;
        Assert.That(quantity.Equals($"{expectedQuantity} items"));
        Console.WriteLine(quantity);
    }
}

