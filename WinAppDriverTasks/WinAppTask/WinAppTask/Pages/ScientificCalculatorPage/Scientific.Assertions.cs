namespace WinAppTask.Pages.ScientificCalculatorPage;
public partial class ScientificCalculatorPages
{
    
    public void AssertResultStartsWith(double expectedResult)
    {
        Assert.IsTrue(ResultText.StartsWith(expectedResult.ToString()), "The calculation result wasn't correct.");
    }
}