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
    public void TestCalculateFormula()
    {
        // Locating elements
        var piButton = _driver.FindElementByName("Pi");
        var logButton = _driver.FindElementByName("Log");
        var InverseButton = _driver.FindElementByAccessibilityId("shiftButton");
        //var PowerButton = _driver.FindElementByAccessibilityId("powerOfEbutton");
        var subtractButton = _driver.FindElementByName("Minus");
        var equalButton = _driver.FindElementByName("Equals");
        //var resultText = _driver.FindElementByAccessibilityId("CalculatorResults");

        // Providing data
        int n = 45;
        int x = 5;
        int y = 2;

        // Click on necessary buttons to perform the calculations
        piButton.Click();
        _calcStandardView.FourButton.Click();
        _calcStandardView.FiveButton.Click();
        logButton.Click();
        InverseButton.Click();
        _calcStandardView.FiveButton.Click();
        var PowerButton = _driver.FindElementByAccessibilityId("powerOfEButton");
        PowerButton.Click();
        _calcStandardView.TwoButton.Click();
        subtractButton.Click();
        _calcStandardView.SixButton.Click();
        equalButton.Click();

        // Get the result and validate
        var resultText = _driver.FindElementByAccessibilityId("CalculatorResults");
        string result = resultText.Text;
        Assert.AreEqual("The expected result", result); // Replace "The expected result" with your expected result
    }

    [Test]
    public void CalculatingSinAndTan()
    {
        //SIN a = b/c

        //TAN

    }
}