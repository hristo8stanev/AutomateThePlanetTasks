namespace WinAppTask.Pages.DataCalculatorPage;
public partial class DataCalculator
{ 
    public void AssertResult(double expectedReslt)
    {
        Assert.AreEqual(expectedReslt.ToString(), ResultTextTemp, "The calculation result wasn't correct.");
    }

    public void AssertResultWeightResulIsCorrect(double expectedReslt)
    {
        Assert.AreEqual(expectedReslt.ToString(), ResultTextWeitght, "The calculation result wasn't correct.");
    }

    public void AssertResultDaysToSecondsIsCorrect(double expectedReslt)
    {
        //var expectedResult = 

        Assert.AreEqual(expectedReslt.ToString("F3").Replace(".", ","), ResultTextDays, "The calculation result wasn't correct.");
    }

    public void AssertResultBytesToGigabytesIsCorrect(double expectedReslt)
    {
        Assert.AreEqual(expectedReslt.ToString("F9"), ResultBytesToGigabytes, "The calculation result wasn't correct.");
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


    public void AssertDate(string expectedResult)
    {
        var result = DateResult.Text;
        Assert.AreEqual(expectedResult, result);
    }
}