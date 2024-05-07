namespace EcommerceLambdaProject.Pages;
public partial class ComparisonPage : WebPage
{
    public ComparisonPage(IDriver driver)
        : base(driver)
    {
    }

    public override string Url => COMPARISON_PAGE;
}
