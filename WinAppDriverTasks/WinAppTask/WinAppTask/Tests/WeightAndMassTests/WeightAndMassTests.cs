using WinAppTask.Enums;
using WinAppTask.Tests.BaseTest;

namespace WinAppTask.Tests.WeightAndMassTests;
public class WeightAndMassTests : BaseCalculatorTest
{
    [Test]
    [TestCase("32", 70.54792)]
    [TestCase("1", 2.204623)]
    [TestCase("15", 33.06934)]
    [TestCase("88", 194.0068)]

    public void ConvertingFromKilosToPoundsTest(string weight, double expectedResult)
    {
        SelectCalculator(CalculatorType.Weight);
        _weightAndMassCalculator.ConvertFromKilogramsToPounds(weight);

        _weightAndMassCalculator.AssertResultWeightResulIsCorrect(expectedResult);
    }
}
