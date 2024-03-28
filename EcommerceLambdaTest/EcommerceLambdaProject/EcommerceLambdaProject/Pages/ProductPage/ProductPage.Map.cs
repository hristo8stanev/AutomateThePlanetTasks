namespace EcommerceLambdaProject.Pages.ProductPage;
public partial class ProductPages
{

    public IComponent SearchField => Driver.FindComponent(By.Name("search"));
    public IComponent RemoveFromWishlist => Driver.FindComponent(By.XPath("//*//tbody//td[contains(@class, 'text-right text-nowrap')]//a[contains(@href, 'account/wishlist&remove')]"));
    public IComponent RemoveFromComparelist(int id) => Driver.FindComponent(By.XPath($"//div[@id='content']//tr//td//a[contains(@href, 'remove={id}') and normalize-space()='Remove']"));
    public IComponent QuantityField => Driver.FindComponents(By.XPath("//input[@name='quantity']")).Last();
    public IComponent AddToCartButton => Driver.FindComponents(By.XPath("//*[@title='Add to Cart']")).Last();
    public IComponent CompareProductButton => Driver.FindComponents(By.XPath("//*[@title='Compare this Product']")).Last();
    public IComponent ProceedToCompare => Driver.FindComponent(By.XPath("//*[@data-original-title='Compare']"));
    public IComponent Qunatity => Driver.WaitAndFindElementJS(By.Name("quantity"));
    public IComponent FindProduct => Driver.FindComponent(By.XPath("//h4/a"));
    public IComponent WishlistPage => Driver.FindComponents(By.XPath("//a[contains(@href, 'account/wishlist')]")).Last();
    public IComponent WishlistButton => Driver.FindComponent(By.XPath("//*[@title='Add to Wish List' and @onclick]"));
    public IComponent ProductNameElement(int id, string productName) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[.//a[contains(@href, 'product_id={id}') and normalize-space()='{productName}']]"));
    public IComponent ProductPriceWishlistElement(string price) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[@class='text-right' and normalize-space()='{price}']"));
    public IComponent ProductElementInformation(string expectedElement) => Driver.FindComponent(By.XPath($"//div[@id='content']//tr//td[contains(text(),'{expectedElement}')]"));
    public IComponent ProductWeightElement(string weight) => Driver.WaitAndFindElementJS(By.XPath($"//div[@id='content']//tr//td[contains(text(),'{weight}')]"));
}