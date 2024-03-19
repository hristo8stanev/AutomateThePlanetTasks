namespace WinAppTask.Pages.TimeCalculatorPage;
public partial class TimeCalculatorPage
{
   
    public void AssertResultDaysToSecondsIsCorrect(double expectedReslt)
    {
      
        Assert.AreEqual(expectedReslt.ToString("F3").Replace(".", ","), ResultTextDays, "The calculation result wasn't correct.");
    }
}
   