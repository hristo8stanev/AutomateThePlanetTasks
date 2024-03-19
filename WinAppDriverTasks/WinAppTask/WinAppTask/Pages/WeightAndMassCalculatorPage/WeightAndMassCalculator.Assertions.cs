namespace WinAppTask.Pages.WeightAndMassCalculatorPage;
public partial class WeightAndMassCalculator
{
    
    public void AssertResultWeightResulIsCorrect(double expectedReslt)
    {
        Assert.AreEqual(expectedReslt.ToString(), ResultTextWeitght, "The calculation result wasn't correct.");
    }
}