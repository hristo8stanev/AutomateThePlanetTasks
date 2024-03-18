using WinAppTask.Enums;
using WinAppTask.Pages.BaseClass;

namespace WinAppTask.Tests.StandardCalculatorTests;
public class StandardCalculatorTests : CalculatorPageObject
{
    [Test]
    [TestCase("32", "89.6")]
    public void ConvertingFromCelsiumToFahrenheit(string value, double expectedResult)
    {
        SelectCalculator(CalculatorType.Temperature);
        _standardCalculatorPage.ConvertTemperatures(value);

        _standardCalculatorPage.AssertResult(expectedResult);

    }

    [Test]
    [TestCase("5", "1", 0.005)]
    [TestCase("4", "1", 0.004)]
    [TestCase("3", "1", 0.003)]
    [TestCase("2", "1", 0.002)]
    [TestCase("1", "1", 0.001)]

    public void ConvertingSquareCentimeters(string x, string y, double expectedResult)
    {
        SelectCalculator(CalculatorType.Standard);
        _standardCalculatorPage.PerformSquareCantimetersCalculation(x, y);

        _standardCalculatorPage.AssertDoubleResult(expectedResult);
    }

    [Test]
    [TestCase("45", "5", "2", -8.88)]
    [TestCase("6", "2", "6", -3.94)]
    [TestCase("77", "9.12", "1.6", -5.87)]
    public void ScientificCalculateFormula(string n, string x, string y, double expectedResult)
    {
        SelectCalculator(CalculatorType.Scientific);
        _standardCalculatorPage.ExecuteFormulaFormula(n, x, y);

        _standardCalculatorPage.AssertResultStartsWith(expectedResult);
    }


    [Test]
    [TestCase("-8.88", -0.518)]
    [TestCase("-3.94", 0.716)]
    [TestCase("-5.87", 0.401)]
    public void CalculatingSinFunctionOfNumbers(string num, double expectedResult)
    {
        SelectCalculator(CalculatorType.Scientific);
        _standardCalculatorPage.ExecuteSinFucntionOfNumbers(num);

        _standardCalculatorPage.AssertResultStartsWith(expectedResult);
    }

    [Test]
    [TestCase("-8.88", 0.605)]
    [TestCase("-3.94", -1.026)]
    [TestCase("-5.87", 0.438)]
    public void CalculatingTanFunctionOfNumbers(string num, double expectedResult)
    {
        SelectCalculator(CalculatorType.Scientific);
        _standardCalculatorPage.ExecuteTanFucntionOfNumbers(num);

        _standardCalculatorPage.AssertResultStartsWith(expectedResult);
    }

    [Test]
    [TestCase("1", "30", "Difference 4 weeks, 1 day")]
    [TestCase("7", "15", "Difference 1 week, 1 day")]
    [TestCase("10", "25", "Difference 2 weeks")]
    [TestCase("15", "15", "Difference Same dates")]

    public void Date(string firstDate, string SecondDate, string expectedResult)
    {
        SelectCalculator(CalculatorType.Date);
        _standardCalculatorPage.ChooseFromDateToDate(firstDate, SecondDate);

        _standardCalculatorPage.AssertDate(expectedResult);
    }

    [Test]
    [TestCase("32", 70.54792)]
    [TestCase("1", 2.204623)]
    [TestCase("15", 33.06934)]
    [TestCase("88", 194.0068)]

    public void Weight(string weight, double expectedResult)
    {
        SelectCalculator(CalculatorType.Weight);
        _standardCalculatorPage.ConvertFromKilogramsToPounds(weight);

        _standardCalculatorPage.AssertResultWeightResulIsCorrect(expectedResult);

    }

    [Test]
    [TestCase("2", 172.800)]
    [TestCase("5", 432.000)]
    [TestCase("7", 604.800)]
    [TestCase("9", 777.600)]
    public void Time(string days, double expectedResultSeconds)
    {
        SelectCalculator(CalculatorType.Time);
        _standardCalculatorPage.ConvertBetweenDaysAndSeconds(days);

        _standardCalculatorPage.AssertResultDaysToSecondsIsCorrect(expectedResultSeconds);

    }

    [Test]
    [TestCase("9", 0.000000009)]
    [TestCase("8", 0.000000008)]
    [TestCase("7", 0.000000007)]
    [TestCase("6", 0.000000006)]
    [TestCase("5", 0.000000005)]
    [TestCase("4", 0.000000004)]
    public void Data_1(string bytes, double expectedResultGigabytes)
    {
        SelectCalculator(CalculatorType.Data);
        _standardCalculatorPage.ConvertBetweenBytesAndGigabytes(bytes);

        _standardCalculatorPage.AssertResultBytesToGigabytesIsCorrect(expectedResultGigabytes);

    }
}