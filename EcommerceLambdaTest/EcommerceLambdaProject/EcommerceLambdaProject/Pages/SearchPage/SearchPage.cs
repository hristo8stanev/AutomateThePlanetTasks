
using EcommerceLambdaProject.Pages.ProductPage;

namespace EcommerceLambdaProject.Pages.SearchPage;
public partial class SearchPages : WebPage
{
    public SearchPages(IDriver driver) : base(driver)
    {
    }

    public void SearchProductByName(ProductDetails product)
    {
        SearchInputSearchPage.TypeText(product.Name);
        SearchButtonSearchPage.Click();
    }

}
