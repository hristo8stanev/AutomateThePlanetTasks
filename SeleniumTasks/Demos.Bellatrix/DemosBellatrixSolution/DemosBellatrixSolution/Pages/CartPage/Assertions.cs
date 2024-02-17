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

    public void AssertCheckoutPage(string currentUrl)
    {

        Assert.That(currentUrl, Is.EqualTo("https://demos.bellatrix.solutions/checkout/"), ErrorMessageIncorrectUrl);
    }

}

