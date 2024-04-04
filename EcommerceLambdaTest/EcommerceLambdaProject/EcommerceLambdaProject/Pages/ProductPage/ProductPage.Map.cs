namespace EcommerceLambdaProject.Pages;

public partial class ProductPage
{
    public IComponent SearchField => Driver.FindComponent(By.Name("search"));
    public IComponent RemoveButton => Driver.FindComponent(By.XPath("//button[contains(@onclick, 'cart.remove')]"));
    public IComponent CompareButton => Driver.FindComponent(By.PartialLinkText("GenerateProduct Compare"));
    public IComponent RemoveFromWishList => Driver.FindComponent(By.XPath("//div[@id='content']//td[contains(@class, 'text-right text-nowrap')]//a[contains(@href, 'account/wishlist&remove')]"));

    public IComponent RemoveFromCompareList(int id) => Driver.FindComponent(By.XPath($"//div[@id='content']//tr//td//a[contains(@href, 'remove={id}') and normalize-space()='Remove']"));

    public IComponent QuantityInput => Driver.FindComponents(By.XPath("//input[@name='quantity']")).Last();
    public IComponent AddToCartButton => Driver.FindComponent(By.XPath("//div[@class='content']//button[contains(text(),'Add to Cart')]"));
    public IComponent CompareProductButton => Driver.FindComponents(By.XPath("//*[@title='Compare this GenerateProduct']")).Last();
    public IComponent ProceedToCompare => Driver.FindComponent(By.XPath("//*[@data-original-title='Compare']"));
    public IComponent FindProduct => Driver.FindComponent(By.XPath("//h4/a"));
    public IComponent WishListSection => Driver.FindComponents(By.XPath("//a[contains(@href, 'account/wishlist')]")).Last();
    public IComponent WishListButton => Driver.FindComponent(By.XPath("//*[@title='Add to Wish List' and @onclick]"));
    public IComponent SizeField => Driver.FindComponent(By.XPath("//*[@class='custom-select'][1]"));
    public IComponent SmallSize => SizeField.FindComponent(By.XPath($".//option[contains(text(), 'Small')]"));
    public IComponent MediumSize => SizeField.FindComponent(By.XPath($".//option[contains(text(), 'MediumSize')]"));
    public IComponent LargeSize => SizeField.FindComponent(By.XPath($".//option[contains(text(), 'Large')]"));

    public IComponent ProductSize(int id) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[.//a[contains(@href, 'product_id={id}')]]//following-sibling::small"));

    public IComponent ProductNameElement(int id, string productName) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[.//a[contains(@href, 'product_id={id}') and normalize-space()='{productName}']]"));

    public IComponent ProductPriceWishListElement(string price) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[@class='text-right' and normalize-space()='{price}']"));

    public IComponent ProductElementInformation(string expectedElement) => Driver.FindComponent(By.XPath($"//div[@id='content']//tr//td[contains(text(),'{expectedElement}')]"));

    public IComponent ProductWeightElement(string weight) => Driver.FindComponent(By.XPath($"//div[@id='content']//tr//td[contains(text(),'{weight}')]"));
}