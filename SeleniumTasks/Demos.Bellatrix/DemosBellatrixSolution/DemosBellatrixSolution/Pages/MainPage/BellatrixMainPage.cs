using DemosBellatrixSolution.Pages.BaseWebPage;
using OpenQA.Selenium;

namespace DemosBellatrixSolution.Pages.MainPage;
public partial class BellatrixMainPage : WebPage
{
    public BellatrixMainPage(IWebDriver driver)
        : base(driver)
    {
    }
    protected override string Url => "https://demos.bellatrix.solutions/";


    public void AddRocketToCart(string rocket)
    {
        SearchField.SendKeys(rocket + Keys.Enter);
        AddToCartButton.Click();
        ViewCartButton.Click();
    }

    public void EnterMyOrderSection()
    {
        //Thread.Sleep(2000);
        MoveToElement(By.XPath("(//li[@class='page_item page-item-8'])[1]"));
        MyAccountButton.Click();
        MyOrders.Click();
    }
}
