using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemosBellatrixSolution.Pages.MainPage;
public partial class BellatrixMainPage
{
    public IWebElement SearchField => WaitAndFindElement(By.XPath("//input[@id='woocommerce-product-search-field-0']"));
    public IWebElement ShoppingCart => WaitAndFindElement(By.XPath("//a[@class='cart-contents']"));
    public IWebElement AddToCartButton => WaitAndFindElement(By.XPath("//a[@class='button product_type_simple add_to_cart_button ajax_add_to_cart']"));
    public IWebElement MyAccountButton => WaitAndFindElement(By.XPath("(//li[@class='page_item page-item-8'])[1]"));
    public IWebElement CheckoutButton => WaitAndFindElement(By.XPath("//li[@class='page_item page-item-7'][0]"));
    public IWebElement ViewCartButton => WaitAndFindElement(By.XPath("//a[@title='View cart']"));
    public IWebElement Checkout => WaitAndFindElement(By.XPath("//a[@class='button checkout wc-forward']"));
    public IWebElement MyOrders => WaitAndFindElement(By.XPath("(//a[@href='https://demos.bellatrix.solutions/my-account/orders/'])[1]"));


}
