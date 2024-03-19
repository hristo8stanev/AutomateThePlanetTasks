using OpenQA.Selenium;

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
       Assert.That(expectedEmail, Is.EqualTo(EmailElement(expectedEmail).Text.Trim()), ErrorMessageEmailMismatch);
   }
}