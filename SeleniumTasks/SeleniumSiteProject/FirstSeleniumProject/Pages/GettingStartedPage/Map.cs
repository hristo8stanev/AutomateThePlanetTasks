using OpenQA.Selenium;

namespace FirstSeleniumProject.Pages.GettingStartedPage;
public partial class MainPage
{
    
    public IWebElement SeleniumOverviewField => WaitAndFindElement(By.XPath("//a[@title='Selenium Overview']"));
    public IWebElement SeleniumComponentsField => WaitAndFindElement(By.XPath("//a[@title='Selenium components']"));
    public string GitHubLink => "//a[@href='https://github.com/SeleniumHQ/seleniumhq.github.io/commit/6b87463b63700d38146e82130776bf4d832bf82d']";
    public IWebElement GitHubLinkField => WaitAndFindElement(By.XPath("//a[@href='https://github.com/SeleniumHQ/seleniumhq.github.io/commit/6b87463b63700d38146e82130776bf4d832bf82d']"));
}
