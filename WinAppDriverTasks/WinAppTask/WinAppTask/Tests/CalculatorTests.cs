using WinAppTask.BaseClass;


namespace WinAppTask.Tests;
public class CalculatorTests : CalculatorPageObject
{

    [Test]
    public void Addition()
    {
        _calcStandardView.PerformCalculation(5, '+', 7);

        _calcStandardView.AssertResult(12);
    }

    [Test]
    public void ConvertingFromCelsiumToFahrenheit()
    {
        _calcStandardView.NavigationalMenu();
        _calcStandardView.ConvertTemperatures();
        _calcStandardView.AssertCorrectConvertioningFromCelsiumToFahrenheit(41);

    }

    [Test]
    public void ConvertingSquareCentimeters()
    {
        _calcStandardView.NavigationalMenu();

        _calcStandardView.StandardTypeCalculatorButton.Click();
        _calcStandardView.PerformSquareCantimetersCalculation(5, '/', 1, 0, 0, 0);

        _calcStandardView.AssertSquareCentimetersResult(0.005);

    }


    [Test]
    public void ScientificCalculatorModeCalculatingFormula()
    {
        //Pi + log(n) - x ^ y

    }

    [Test]
    public void CalculatingSinAndTan()
    {
        //SIN a = b/c

        //TAN

    }
}