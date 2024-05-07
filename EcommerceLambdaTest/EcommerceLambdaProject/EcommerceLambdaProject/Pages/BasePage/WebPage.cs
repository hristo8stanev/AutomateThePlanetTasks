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

    public void AssertUrlPage()
    {
        Assert.That(Url, Is.EqualTo(Driver.Url), ErrorMessageUrl);
        Driver.WaitForAjax();
    }
}