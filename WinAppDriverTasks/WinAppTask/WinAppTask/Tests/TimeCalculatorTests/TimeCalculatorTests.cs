using WinAppTask.Enums;
using WinAppTask.Tests.BaseTest;

namespace WinAppTask.Tests.TimeCalculatorTests;
public class TimeCalculatorTests : BaseCalculatorTest
{

    [Test]
    [TestCase("2", 172.800)]
    [TestCase("5", 432.000)]
    [TestCase("7", 604.800)]
    [TestCase("9", 777.600)]
    public void ConvertingFromDaysToSecondsTest(string days, double expectedResultSeconds)
    {
        SelectCalculator(CalculatorType.Time);
        _timeCalculatorPage.ConvertBetweenDaysAndSeconds(days);

        _timeCalculatorPage.AssertResultDaysToSecondsIsCorrect(expectedResultSeconds);
    }

}
