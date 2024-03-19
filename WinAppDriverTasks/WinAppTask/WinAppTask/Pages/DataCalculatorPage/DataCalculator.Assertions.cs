namespace WinAppTask.Pages.DataCalculatorPage;
public partial class DataCalculator
{ 
    public void AssertResultBytesToGigabytesIsCorrect(double expectedReslt)
    {
        Assert.AreEqual(expectedReslt.ToString("F9"), ResultBytesToGigabytes, "The calculation result wasn't correct.");
    }
}