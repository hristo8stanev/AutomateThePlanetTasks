using NUnit.Framework;


namespace WinAppTask.Views;
public partial class CalculatorStandardView
{

    public void AssertResult(decimal expectedReslt)
    {
        string strResult = GetCalculatorResultText();
        var actualResult = decimal.Parse(strResult);

        Assert.AreEqual(expectedReslt, actualResult);
    }

    public void AssertSquareCentimetersResult(double expectedResult)
    {

        string result = GetCalculatorResultText();
        var actualResult = double.Parse(result);

        Assert.AreEqual(expectedResult, actualResult);

    }

    public void AssertCorrectConvertioningFromCelsiumToFahrenheit(double expectedResult)
    {
        string result = GetCalculatorResultTextValue2();
        var actualResult = double.Parse(result);

        Assert.AreEqual(expectedResult, actualResult);
    }
}
