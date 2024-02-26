using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace DemosBellatrixSolution.Pages.CheckoutPage;
public partial class CheckoutPage
{
    private string ErrorMessageUrl => "The URL does not contain 'order-received'";

    public void AssertOrderReceived()
    {
        var errorMessageElement = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1")));
        bool isDisplayed = errorMessageElement.Displayed;
        Assert.That(isDisplayed);
    }

    public void AssertOrderReceivedUr(string receiveOrderUrl)
    {  
            Assert.That(receiveOrderUrl.Contains("order-received"), Is.True, ErrorMessageUrl);
    }
    
  public void AssertQuantityOfTheProductCheckoutPage(string product, int expectedQuantity)
  {

      var quantity = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[@class='product-name']"))).Text;
      Assert.That(quantity.Equals($"{product}  × {expectedQuantity}"));
      Console.WriteLine(quantity);
  }

    public void AssertCheckoutPage(string currentUrl)
    {

        Assert.That(currentUrl, Is.EqualTo("https://demos.bellatrix.solutions/checkout/"), ErrorMessageUrl);
    }
}
