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
        
    }

    public void ProceedToGitHubLink()
    {
        MoveToElement(GitHubLink);
        GitHubLinkField.Click();
        
    }
}
