using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace BlueHostingLogin.Pages.BlueHostPage;
public partial class BlueHostMainPage
{
    public void AssertVerifyButtonIsDisplayed()
    {

        var errorMessageElement = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[text()='Couldn’t find your Google Account']")));
        bool isDisplayed = errorMessageElement.Displayed;

        Assert.That(isDisplayed);
    }
}
