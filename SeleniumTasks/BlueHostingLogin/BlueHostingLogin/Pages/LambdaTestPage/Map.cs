using OpenQA.Selenium;

namespace BlueHostingLogin.Pages.LambdaTestPage;
public partial class LambdaMainPage
{
    public IWebElement LambdaEmailField => WaitAndFindElement(By.Id("email"));
    public IWebElement LambdaPasswordField => WaitAndFindElement(By.Id("userpassword"));
    public IWebElement LambdaSubmitButton => WaitAndFindElement(By.XPath("//button[@type='submit']"));
    public IWebElement LambdaVerifyButton => WaitAndFindElement(By.XPath("//button[text()='Verify']"));
    public IWebElement EmailElement(string expectedEmail)
    {
     return MoveToElement(By.XPath(string.Format("//span[contains(@class, 'text-[#000] font-[600]') and text()='{0}']", expectedEmail)));
    }
    public IWebElement GetEmailFromVerifyForm(string email)
    {
     return WaitAndFindElement(By.XPath("//span[contains(@class, 'text-[#000] font-[600]') and text()='{0}']"));
    }
}
