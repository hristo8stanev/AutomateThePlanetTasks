using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace DemosBellatrixSolution.Pages.MainPage;
public partial class BellatrixMainPage
{

    public void AssertMyOrdersIsShown()
    {
       
        bool isDisplayed = OrdersAssert.Displayed;
        Assert.That(isDisplayed);
    }
}