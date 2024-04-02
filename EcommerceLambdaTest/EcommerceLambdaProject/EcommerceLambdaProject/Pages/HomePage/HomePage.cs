namespace EcommerceLambdaProject.Pages;

public partial class HomePage : WebPage
{
    public HomePage(IDriver driver) : base(driver)
    {
    }

    public void SearchProductByName(string productName)
    {
        SearchField.TypeText(productName);
        Driver.WaitForAjax();
    }
}