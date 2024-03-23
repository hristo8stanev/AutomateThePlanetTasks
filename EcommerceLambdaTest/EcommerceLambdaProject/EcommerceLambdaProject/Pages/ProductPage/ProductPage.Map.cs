namespace EcommerceLambdaProject.Pages.ProductPage;
public partial class ProductPages
{


    public IComponent AddToCartButton => Driver.FindComponents(By.XPath("//*[@title='Add to Cart']")).Last();
    public IComponent CompareProductButton => Driver.FindComponents(By.XPath("//*[@title='Compare this Product']")).Last();
    public IComponent ProceedToCompare => Driver.FindComponent(By.XPath("//*[@data-original-title='Compare']"));
    public IComponent Qunatity => Driver.WaitAndFindElementJS(By.Name("quantity"));
    public IComponent FindProduct => Driver.FindComponent(By.XPath("//h4/a"));
    public IComponent GetCompareProduct(string cell) => Driver.FindComponent(By.XPath($"//*//tbody//td[contains(text(),'{cell}')]/following-sibling::td"));
   // public IComponent SelectCell(string cell) => GetCompareProduct.FindComponent(By.XPath(GetCompareProduct(cell));
}