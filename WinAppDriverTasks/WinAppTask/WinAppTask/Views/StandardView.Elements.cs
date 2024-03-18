﻿using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using WinAppTask.Enums;

namespace WinAppTask.Views;
public partial class CalculatorStandardView
{
    public WindowsElement ZeroButton => _driver.FindElementByName("Zero");
    public WindowsElement OneButton => _driver.FindElementByName("One");
    public WindowsElement TwoButton => _driver.FindElementByName("Two");
    public WindowsElement ThreeButton => _driver.FindElementByName("Three");
    public WindowsElement FourButton => _driver.FindElementByName("Four");
    public WindowsElement FiveButton => _driver.FindElementByName("Five");
    public WindowsElement SixButton => _driver.FindElementByName("Six");
    public WindowsElement SevenButton => _driver.FindElementByName("Seven");
    public WindowsElement EightButton => _driver.FindElementByName("Eight");
    public WindowsElement NineButton => _driver.FindElementByName("Nine");
    public WindowsElement MinusButton => _driver.FindElementByName("Minus");
    public WindowsElement PlusButton => _driver.FindElementByName("Plus");
    public WindowsElement PiButton => _driver.FindElementByName("Pi");
    public WindowsElement LogButton => _driver.FindElementByName("Log");
    public WindowsElement PowerButton => _driver.FindElementByAccessibilityId("powerButton");
    public WindowsElement EqualButton => _driver.FindElementByName("Equals");
    public WindowsElement MultiplyButton => _driver.FindElementByName("Multiply by");
    public WindowsElement DivideButton => _driver.FindElementByName("Divide by");
    public WindowsElement BackspaceButton => _driver.FindElementByName("Backspace");
    public WindowsElement ClearButton => _driver.FindElementByName("Clear entry");
    public WindowsElement PercentButton => _driver.FindElementByName("Percent");
    public WindowsElement PositiveNegativeButton => _driver.FindElementByName("Positive negative");
    public WindowsElement ReciprocalButton => _driver.FindElementByName("Reciprocal");
    public WindowsElement SquareButton => _driver.FindElementByName("Square");
    public WindowsElement SquareRootButton => _driver.FindElementByName("Square root");
    public WindowsElement NavigationButton => _driver.FindElementByName("Open Navigation");
    public WindowsElement TemperatureConverterMenuButton => _driver.FindElementByName("Temperature Converter");
    public WindowsElement ClearInput => _driver.FindElementByName("Clear");
    public WindowsElement ScientificMenuButton => _driver.FindElementByAccessibilityId("Scientific");
    public WindowsElement StandardTypeCalculatorButton => _driver.FindElementByName("Standard Calculator");
    public WindowsElement InputUnitButton => _driver.FindElementByName("Input unit");
    public WindowsElement OutputUnitButton => _driver.FindElementByName("Output unit");
    public WindowsElement FahrenheitButton => _driver.FindElementByName("Fahrenheit");
    public WindowsElement CelsiumButton => _driver.FindElementByName("Celsius");
    public WindowsElement CalculatorResultButton => _driver.FindElementByAccessibilityId("CalculatorResults");
    public WindowsElement OutputValueDegreeButton => _driver.FindElementByAccessibilityId("Value2");
    public WindowsElement NegateButton => _driver.FindElementByAccessibilityId("negateButton");
    public WindowsElement DecimalSeparator => _driver.FindElementByAccessibilityId("decimalSeparatorButton");
    public WindowsElement TrigonometricsElement => _driver.FindElementByAccessibilityId("trigButton");
    public WindowsElement NegateButtonElement => _driver.FindElementByAccessibilityId("negateButton");
    public WindowsElement SinFunctionElement => _driver.FindElementByAccessibilityId("sinButton");
    public WindowsElement TanFunctionElement => _driver.FindElementByAccessibilityId("tanButton");
    public WindowsElement DegreeButtonElement => _driver.FindElementByAccessibilityId("degButton");
    public WindowsElement TogglePanelButton => _driver.FindElement(ByAccessibilityId.AccessibilityId("TogglePaneButton"));
    public WindowsElement CalculatorTypeButton(CalculatorType calculatorType) => _driver.FindElement(ByAccessibilityId.AccessibilityId(calculatorType.ToString()));

}
