namespace EcommerceLambdaProject.Pages.ProductPage;
public partial class ProductPages
{


    public IComponent AddToCartButton => Driver.FindComponents(By.XPath("//*[@title='Add to Cart']")).Last();
    public IComponent CompareProductButton => Driver.FindComponents(By.XPath("//*[@title='Compare this Product']")).Last();
    public IComponent Qunatity => Driver.WaitAndFindElementJS(By.Name("quantity"));
    public IComponent FindProduct => Driver.FindComponent(By.XPath("//h4/a"));

}