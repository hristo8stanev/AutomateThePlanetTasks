namespace WinAppTask.Pages.DateCalculatorPage;
public partial class DateCalculatorPage
{
    public void AssertDate(string expectedResult)
    {
        var result = DateResult.Text;
        Assert.AreEqual(expectedResult, result);
    }
}