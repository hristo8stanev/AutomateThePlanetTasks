using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace DemosBellatrixSolution.Pages.MainPage;
public partial class BellatrixMainPage
{

    public void AssertMyOrdersIsShown()
    {
        var myOrders = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//td[@data-title='Order'][1])//a")));
        bool isDisplayed = myOrders.Displayed;
        Assert.That(isDisplayed);
    }
}