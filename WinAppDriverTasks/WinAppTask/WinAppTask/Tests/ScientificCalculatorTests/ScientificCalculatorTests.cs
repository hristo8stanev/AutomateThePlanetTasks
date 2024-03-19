using WinAppTask.Enums;
using WinAppTask.Tests.BaseTest;

namespace WinAppTask.Tests.ScientificCalculatorPage;
public class ScientificCalculatorTests : BaseCalculatorTest
{

    [Test]
    [TestCase("45", "5", "2", -8.88)]
    [TestCase("6", "2", "6", -3.94)]
    [TestCase("77", "9.12", "1.6", -5.87)]
    public void ScientificCalculateFormulaTest(string n, string x, string y, double expectedResult)
    {
        SelectCalculator(CalculatorType.Scientific);
        _scientificCalculatorPages.ExecuteFormulaFormula(n, x, y);

        _scientificCalculatorPages.AssertResultStartsWith(expectedResult);
    }

    [Test]
    [TestCase("-8.88", -0.518)]
    [TestCase("-3.94", 0.716)]
    [TestCase("-5.87", 0.401)]
    public void CalculatingSinFunctionOfNumbersTest(string num, double expectedResult)
    {
        SelectCalculator(CalculatorType.Scientific);
        _scientificCalculatorPages.ExecuteSinFucntionOfNumbers(num);

        _scientificCalculatorPages.AssertResultStartsWith(expectedResult);
    }

    [Test]
    [TestCase("-8.88", 0.605)]
    [TestCase("-3.94", -1.026)]
    [TestCase("-5.87", 0.438)]
    public void CalculatingTanFunctionOfNumbersTest(string num, double expectedResult)
    {
        SelectCalculator(CalculatorType.Scientific);
        _scientificCalculatorPages.ExecuteTanFucntionOfNumbers(num);

        _scientificCalculatorPages.AssertResultStartsWith(expectedResult);
    }
}
