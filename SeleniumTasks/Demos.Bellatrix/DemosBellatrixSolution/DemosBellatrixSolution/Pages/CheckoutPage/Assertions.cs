using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace DemosBellatrixSolution.Pages.CheckoutPage;
public partial class CheckoutPage
{
    private string errorMessageUrl => "The URL does not contain 'order-received'";
    public void AssertOrderReceived()
    {
        var errorMessageElement = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1")));
        bool isDisplayed = errorMessageElement.Displayed;
        Assert.That(isDisplayed);
    }

    public void AssertOrderReceivedUr(string receiveOrderUrl)
    {  
            Assert.That(receiveOrderUrl.Contains("order-received"), Is.True, errorMessageUrl);
    }
}
