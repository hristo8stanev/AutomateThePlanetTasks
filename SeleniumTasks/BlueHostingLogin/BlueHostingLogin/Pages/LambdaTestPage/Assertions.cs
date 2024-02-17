using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace BlueHostingLogin.Pages.LambdaTestPage;
public partial class LambdaMainPage
{

    private string ErrorMessageEmailMismatch => "Email displayed does not match the expected email";
    private string ErrorMessageIncorrectUrl => "Your URL is not correct";

    public void AssertUserSuccssesfullyLoginUrl(string currentUrl)
    {

        Assert.That(currentUrl, Is.EqualTo("https://accounts.lambdatest.com/email/verify"), ErrorMessageIncorrectUrl);
    }

  public void AssertSentEmailToVerify(string expectedEmail)
    {
        
        string xpath = string.Format("//span[contains(@class, 'text-[#000] font-[600]') and text()='{0}']", expectedEmail);

        IWebElement emailElement = Driver.FindElement(By.XPath(xpath));
        string displayedEmail = emailElement.Text.Trim();

        Assert.That(expectedEmail, Is.EqualTo(displayedEmail), ErrorMessageEmailMismatch);
    }
}