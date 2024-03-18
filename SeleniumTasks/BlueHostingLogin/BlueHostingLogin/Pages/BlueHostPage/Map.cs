using OpenQA.Selenium;

namespace BlueHostingLogin.Pages.BlueHostPage;
public partial class BlueHostMainPage
{
    public IWebElement WebmailLogin => WaitAndFindElement(By.XPath("//div[@id='mat-tab-label-0-1']"));
    public IWebElement EmailField => WaitAndFindElement(By.Id("emailId"));
    public IWebElement LoginButton => WaitAndFindElement(By.XPath("//button[@type='submit'][1]"));
    public IWebElement NextButton => WaitAndFindElement(By.XPath("//div//span[text()='Next']"));
    public IWebElement IncorrectMessageAfterLogin => WaitAndFindElement(By.XPath("//div[text()='Couldn’t find your Google Account']"));
    public IWebElement AcceptCookie => WaitAndFindElement(By.XPath("//button[@id='onetrust-accept-btn-handler']"));
    public IWebElement ErrorMessageIncorrectEmail => WaitAndFindElement(By.XPath("//div[text()='Couldn’t find your Google Account']"));
    
    public string emailAssert = "//*[@class='cursor-pointer font-[500] leading-[16px] text-[#333]']";
}