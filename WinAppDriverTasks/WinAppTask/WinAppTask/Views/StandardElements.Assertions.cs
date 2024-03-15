using NUnit.Framework;


namespace WinAppTask.Views;
public partial class CalculatorStandardView
{
    public void AssertResult(double expectedReslt)
    {
        Assert.AreEqual(expectedReslt.ToString(),ResultTextTemp, "The calculation result wasn't correct.");
    }

        public void AssertDoubleResult(double expectedResult)
    {

        string result = GetCalculatorResultText();
        var actualResult = double.Parse(result);

        Assert.AreEqual(expectedResult, actualResult);

    }
    public void AssertResultStartsWith(double expectedResult)
    {
        Assert.IsTrue(ResultText.StartsWith(expectedResult.ToString()), "The calculation result wasn't correct.");
    }
}