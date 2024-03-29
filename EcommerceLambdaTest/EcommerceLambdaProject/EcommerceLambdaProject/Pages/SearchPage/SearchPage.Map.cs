namespace EcommerceLambdaProject.Pages.SearchPage;
public partial class SearchPages
{

    public IComponent SearchInputSearchPage => Driver.FindComponent(By.XPath("//*[@class='col-sm-5 mb-3']//following-sibling::input"));
    public IComponent SearchButtonSearchPage => Driver.FindComponent(By.Id("button-search"));
    public IComponent GetProductName(int id, string name) => Driver.FindComponent(By.XPath($"//h4[.//a[contains(@href, 'product_id={id}') and normalize-space()='{name}']]"));
    public IComponent GetProductPrice => Driver.FindComponent(By.XPath("//*[@class='price']//following-sibling::span"));
    public IComponent ErrorMessageNonExistingProduct(string mesage) => Driver.FindComponent(By.XPath($"//p[contains(text(),'{mesage}')]"));
    public IComponent MinPriceField => Driver.FindComponent(By.XPath("//div[@class='content']//div//input[contains(@placeholder, 'Minimum Price')]"));
    public IComponent MaxPriceField => Driver.FindComponent(By.XPath("//div[@class='content']//div//input[contains(@placeholder, 'Maximum Price')]"));
    public IComponent FirstProduct => Driver.FindComponent(By.XPath("//h4[@class='title'][1]"));
    public IComponent Desktop => Driver.WaitAndFindElementJS(By.XPath("//div[@class='nav flex-column nav-pills custom-pills-left']//following-sibling::a"));

}
