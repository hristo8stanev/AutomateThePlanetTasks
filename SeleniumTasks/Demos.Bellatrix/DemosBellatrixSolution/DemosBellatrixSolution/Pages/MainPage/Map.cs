using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace DemosBellatrixSolution.Pages.MainPage;
public partial class BellatrixMainPage
{
    public IWebElement SearchField => WaitAndFindElement(By.XPath("//input[@id='woocommerce-product-search-field-0']"));
    public IWebElement ShoppingCart => WaitAndFindElement(By.XPath("//a[@class='cart-contents']"));
    public IWebElement AddToCartButton => WaitAndFindElement(By.XPath("//a[@class='button product_type_simple add_to_cart_button ajax_add_to_cart']"));
    public IWebElement MyAccountButton => MoveToElement(By.XPath("(//li[@class='page_item page-item-8'])[1]"));
    public IWebElement CheckoutButton => WaitAndFindElement(By.XPath("//li[@class='page_item page-item-7'][0]"));
    public IWebElement ViewCartButton => WaitAndFindElement(By.XPath("//*[@class='added_to_cart wc-forward']"));
    public IWebElement Checkout => WaitAndFindElement(By.XPath("//a[@class='button checkout wc-forward']"));
    public IWebElement MyOrders => WaitAndFindElement(By.XPath("(//a[@href='https://demos.bellatrix.solutions/my-account/orders/'])[1]"));
    public IWebElement OrdersAssert => MoveToElement(By.XPath("(//td[@data-title='Order'][1])//a"));

}
