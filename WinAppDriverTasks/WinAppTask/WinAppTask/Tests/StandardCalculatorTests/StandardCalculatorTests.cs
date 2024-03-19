using WinAppTask.Enums;
using WinAppTask.Tests.BaseTest;

namespace WinAppTask.Tests.StandardCalculatorTests;
public class StandardCalculatorTests : BaseCalculatorTest
{

    [Test]
    [TestCase("5", "1", 0.005)]
    [TestCase("4", "1", 0.004)]
    [TestCase("3", "1", 0.003)]
    [TestCase("2", "1", 0.002)]
    [TestCase("1", "1", 0.001)]

    public void ConvertingSquareCentimetersTest(string x, string y, double expectedResult)
    {
        SelectCalculator(CalculatorType.Standard);
        _standardCalculatorPage.PerformSquareCantimetersCalculation(x, y);

        _standardCalculatorPage.AssertDoubleResult(expectedResult);
    }

}