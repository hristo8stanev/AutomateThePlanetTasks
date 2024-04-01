namespace EcommerceLambdaProject.Pages.BasePage;
public abstract class WebPage
{
    private string ErrorMessageUrl => "Expected page was not navigated.";
    protected readonly IDriver Driver;


    public WebPage(IDriver driver)
    {
        Driver = driver;
    }

    public void AssertUrlPage(string expectedUrl)
    {
        string actualUrl = Driver.Url;
        CollectionAssert.AreEqual(expectedUrl, actualUrl, ErrorMessageUrl);
        Driver.WaitForAjax();

    }
}