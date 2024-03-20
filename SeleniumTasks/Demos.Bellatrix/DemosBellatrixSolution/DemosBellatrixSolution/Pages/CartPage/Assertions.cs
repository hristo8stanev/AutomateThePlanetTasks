using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace DemosBellatrixSolution.Pages.CartPage;
public partial class CartPage
{
 
    public void AssertCouponApplied()
    {
        
        bool isDisplayed = AppliedCoupon.Displayed;
        Assert.That(isDisplayed);
    }

   public void AssertQuantityOfTheProductCartPage(int expectedQuantity)
   {
        Thread.Sleep(2000);
        var cartHeader = CartHeader.Displayed;
        Assert.That(CountProductElement.Text.Equals($"{expectedQuantity} items"));
        Console.WriteLine(CountProductElement.Text);
    }
}

