using OpenQA.Selenium;
using SeleniumSiteProject.Pages.BasePage;

namespace FirstSeleniumProject.Pages.GettingStartedPage;
public partial class MainPage : WebPage
{
  
    public MainPage(IWebDriver driver)
        : base(driver)
    {
    }

    protected override string Url => "https://www.selenium.dev/documentation/en/getting_started";

    public void ProceedToComponents()
    {
        
        SeleniumOverviewField.Click();
        SeleniumComponentsField.Click();
        WaitForAjax();
    }

    public void ProceedToGitHubLink()
    {
           MoveToElement(By.XPath("//*[@href='https://github.com/SeleniumHQ/seleniumhq.github.io/commit/6b87463b63700d38146e82130776bf4d832bf82d']"));
           GitHubLinkField.Click();
    }
}
