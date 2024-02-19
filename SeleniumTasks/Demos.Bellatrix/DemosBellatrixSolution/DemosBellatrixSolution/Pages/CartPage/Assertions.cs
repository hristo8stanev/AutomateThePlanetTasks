using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace DemosBellatrixSolution.Pages.CartPage;
public partial class CartPage
{
    private string ErrorMessageIncorrectUrl => "Your URL is not correct";
    public void AssertCouponApplied()
    {
        var errorMessageElement = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@class='cart-discount coupon-happybirthday']")));
        bool isDisplayed = errorMessageElement.Displayed;
        Assert.That(isDisplayed);
    }

   //public void AssertQuantityOfTheProductCartPage(string product, int expectedQuantity)
   //{
   //    var quantity = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@type='number' and @title='Qty']"))).Text;
   //   // Assert.That(quantity.Equals($"{product}  × {expectedQuantity}"));
   //   // Console.WriteLine(" ");
   //    Console.WriteLine(quantity);
   //}

}

