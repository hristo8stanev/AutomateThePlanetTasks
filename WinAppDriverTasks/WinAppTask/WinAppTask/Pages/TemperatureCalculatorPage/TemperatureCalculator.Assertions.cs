namespace WinAppTask.Pages.TemperatureCalculatorPage;
public partial class TemperatureCalculatorPage
{
    public void AssertResult(double expectedReslt)
    {
        Assert.AreEqual(expectedReslt.ToString(), ResultTextTemp, "The calculation result wasn't correct.");
    }

}