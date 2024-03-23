
namespace EcommerceLambdaProject.Pages.HomePage;
public partial class HomePages : WebPage
{
    public HomePages(IDriver driver) : base(driver)
    {
    }



    public void SearchProductByName(string productName)
    {
        SearchField.TypeText(productName);
    }
}