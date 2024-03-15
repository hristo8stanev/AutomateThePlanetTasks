using OpenQA.Selenium;
using WinAppTask.BaseClass;


namespace WinAppTask.Tests;
public class CalculatorTests : CalculatorPageObject
{


    [Test]
    [TestCase("32", "89.6")]
    public void ConvertingFromCelsiumToFahrenheit(string value, double expectedResult)
    {
        _calcStandardView.NavigationalMenu();
        _calcStandardView.ConvertTemperatures(value);

        _calcStandardView.AssertResult(expectedResult);

    }

    [Test]
    [TestCase("5", "1", 0.005)]
    [TestCase("4", "1", 0.004)]
    [TestCase("3", "1", 0.003)]
    [TestCase("2", "1", 0.002)]
    [TestCase("1", "1", 0.001)]

    public void ConvertingSquareCentimeters(string x, string y, double expectedResult)
    {
        _calcStandardView.NavigationalMenu();

        _calcStandardView.StandardTypeCalculatorButton.Click();
        _calcStandardView.PerformSquareCantimetersCalculation(x, y);

        _calcStandardView.AssertDoubleResult(expectedResult);

    }

      [Test]
      [TestCase("45", "5", "2", -8.88)]
      [TestCase("6", "2", "6", -3.94)]
      [TestCase("77", "9.12", "1.6", -5.87)]
      public void ScientificFormula(string n, string x, string y, double expectedResult)
      {
       _calcStandardView.NavigationalMenu();
       _calcStandardView.NavigateToScientificMenu();
       _calcStandardView.ExecuteFormulaFormula(n, x, y);

        _calcStandardView.AssertResultStartsWith(expectedResult);
      }

    [Test]
    public void CalculatingSinAndTan()
    {
        //SIN a = b/c

        //TAN

    }
}