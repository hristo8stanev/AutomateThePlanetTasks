namespace WinAppTask.Views;
public partial class StandardCalculatorPage
{
    public void AssertDoubleResult(double expectedResult)
    {

        string result = GetCalculatorResultText();
        var actualResult = double.Parse(result);

        Assert.AreEqual(expectedResult, actualResult);
    }
}