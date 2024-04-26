namespace EcommerceLambdaProject.Pages.BasePage;

public abstract class WebPage
{
    protected readonly IDriver Driver;

    public WebPage(IDriver driver)
    {
        Driver = driver;
    }

    public abstract string Url { get; }

    public void Navigate()
    {
        Driver.GoToUrl(Url);
    }

    public void AssertUrlPage(string expectedUrl)
    {
        Assert.That(expectedUrl, Is.EqualTo(Driver.Url),Constants.Constants.ErrorMessageUrl);
        Driver.WaitForAjax();
    }
}