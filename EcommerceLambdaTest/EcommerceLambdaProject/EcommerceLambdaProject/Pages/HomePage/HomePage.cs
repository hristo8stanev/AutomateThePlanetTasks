namespace EcommerceLambdaProject.Pages;

public partial class HomePage : WebPage
{
    public HomePage(IDriver driver) : base(driver)
    {
    }

    public override string Url => Urls.Urls.HOME_PAGE;

    public void SearchProductByName(string productName)
    {
        SearchField.TypeText(productName);
        Driver.WaitForAjax();
    }
}