using WinAppTask.Enums;
using WinAppTask.Tests.BaseTest;

namespace WinAppTask.Tests.TemperatureCalculatorTests;
public class TemperatureCalculatorTests : BaseCalculatorTest
{

    [Test]
    [TestCase("32", "89.6")]
    [TestCase("1", "33.8")]
    [TestCase("21", "69.8")]
    public void ConvertingFromCelsiumToFahrenheitTest(string value, double expectedResult)
    {
        SelectCalculator(CalculatorType.Temperature);
        _temperatureCalculatorPage.ConvertTemperatures(value);

        _temperatureCalculatorPage.AssertResult(expectedResult);

    }
}
