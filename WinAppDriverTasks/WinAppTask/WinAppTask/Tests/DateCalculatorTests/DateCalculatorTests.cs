using WinAppTask.Enums;
using WinAppTask.Tests.BaseTest;

namespace WinAppTask.Tests.DateCalculator;
public class DateCalculatorTests : BaseCalculatorTest
{

    [Test]
    [TestCase("1", "30", "Difference 4 weeks, 1 day")]
    [TestCase("7", "15", "Difference 1 week, 1 day")]
    [TestCase("10", "25", "Difference 2 weeks")]
    [TestCase("15", "15", "Difference Same dates")]

    public void CalculatingTheDifferenceBetweenTwoDatesTest(string firstDate, string SecondDate, string expectedResult)
    {
        SelectCalculator(CalculatorType.Date);
        _dateCalculatorPage.ChooseFromDateToDate(firstDate, SecondDate);

        _dateCalculatorPage.AssertDate(expectedResult);
    }
}