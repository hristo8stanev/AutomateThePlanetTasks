using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace DemosBellatrixSolution.Pages.CheckoutPage;
public partial class CheckoutPage
{
    private string ErrorMessageUrl => "The URL does not contain 'order-received'";

    public void AssertOrderReceived()
    {

        bool isDisplayed = OrderReceive.Displayed;
        Assert.That(isDisplayed);
    }

    public void AssertOrderReceivedUr(string receiveOrderUrl)
    {  
            Assert.That(receiveOrderUrl.Contains("order-received"), Is.True, ErrorMessageUrl);
    }
    
  public void AssertQuantityOfTheProductCheckoutPage(string product, int expectedQuantity)
  {

        
      Assert.That(QuantityElement.Text.Equals($"{product}  × {expectedQuantity}"));
      Console.WriteLine(QuantityElement.Text);
  }

    public void AssertCheckoutPage(string currentUrl)
    {

        Assert.That(currentUrl, Is.EqualTo("https://demos.bellatrix.solutions/checkout/"), ErrorMessageUrl);
    }
}
