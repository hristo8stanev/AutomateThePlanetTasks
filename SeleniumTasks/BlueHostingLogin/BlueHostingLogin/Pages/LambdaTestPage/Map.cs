using OpenQA.Selenium;

namespace BlueHostingLogin.Pages.LambdaTestPage;
public partial class LambdaMainPage
{
    public IWebElement LambdaEmailField => WaitAndFindElement(By.Id("email"));
    public IWebElement LambdaPasswordField => WaitAndFindElement(By.Id("userpassword"));
    public IWebElement LambdaSubmitButton => WaitAndFindElement(By.XPath("//button[@type='submit']"));
    public IWebElement LambdaVerifyButton => WaitAndFindElement(By.XPath("//button[text()='Verify']"));
    public string VerifyEmail => "//*[@class='cursor-pointer font-[500] leading-[16px] text-[#333]']";
    public IWebElement EmailElement(string expectedEmail)
    {
     return WaitAndFindElement(By.XPath(string.Format("//span[contains(@class, 'text-[#000] font-[600]') and text()='{0}']", expectedEmail)));
    }
    public IWebElement GetEmailFromVerifyForm(string email)
    {
     return WaitAndFindElement(By.XPath("//span[contains(@class, 'text-[#000] font-[600]') and text()='{0}']"));
    }
}