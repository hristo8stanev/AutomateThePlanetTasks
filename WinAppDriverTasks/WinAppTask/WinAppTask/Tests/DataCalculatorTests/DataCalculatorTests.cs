using WinAppTask.Enums;
using WinAppTask.Tests.BaseTest;

namespace WinAppTask.Tests.DataCalculatorTests;
public class DataCalculatorTests : BaseCalculatorTest
{
    [Test]
    [TestCase("9", 0.000000009)]
    [TestCase("8", 0.000000008)]
    [TestCase("7", 0.000000007)]
    [TestCase("6", 0.000000006)]
    [TestCase("5", 0.000000005)]
    [TestCase("4", 0.000000004)]
    public void ConvertingFromBytesToGigabytesTest(string bytes, double expectedResultGigabytes)
    {
        SelectCalculator(CalculatorType.Data);
        _dataCalculatorPage.ConvertBetweenBytesAndGigabytes(bytes);

        _dataCalculatorPage.AssertResultBytesToGigabytesIsCorrect(expectedResultGigabytes);
    }
}
