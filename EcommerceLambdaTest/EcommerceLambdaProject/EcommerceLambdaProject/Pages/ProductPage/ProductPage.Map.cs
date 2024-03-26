namespace EcommerceLambdaProject.Pages.ProductPage;
public partial class ProductPages
{

    public IComponent SearchField => Driver.FindComponent(By.Name("search"));
    public IComponent RemoveFromWishlist => Driver.FindComponent(By.XPath("//*//tbody//td[contains(@class, 'text-right text-nowrap')]//a[contains(@href, 'account/wishlist&remove')]"));
    public IComponent QuantityField => Driver.FindComponents(By.XPath("//input[@name='quantity']")).Last();
    public IComponent AddToCartButton => Driver.FindComponents(By.XPath("//*[@title='Add to Cart']")).Last();
    public IComponent CompareProductButton => Driver.FindComponents(By.XPath("//*[@title='Compare this Product']")).Last();
    public IComponent ProceedToCompare => Driver.FindComponent(By.XPath("//*[@data-original-title='Compare']"));
    public IComponent Qunatity => Driver.WaitAndFindElementJS(By.Name("quantity"));
    public IComponent FindProduct => Driver.FindComponent(By.XPath("//h4/a"));
    public IComponent WishlistPage => Driver.FindComponents(By.XPath("//a[contains(@href, 'account/wishlist')]")).Last();
    public IComponent WishlistButton => Driver.FindComponent(By.XPath("//*[@title='Add to Wish List' and @onclick]"));
    public IComponent GetCompareProduct(string cell, int index) => Driver.FindComponent(By.XPath($"//*//tbody//td[contains(text(),'{cell}')]/following-sibling::td[{index}]"));
    public IComponent GetProduct(string cell, int index) => Driver.FindComponent(By.XPath($"//*//tbody//td[@class='{cell}']//following-sibling::td[{index}]"));
  
}