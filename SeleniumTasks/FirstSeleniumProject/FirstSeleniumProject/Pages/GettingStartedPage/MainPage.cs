using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using static System.Net.WebRequestMethods;

namespace FirstSeleniumProject.Pages.GettingStartedPage;
public partial class MainPage : WebPage
{
  
    public MainPage(IWebDriver driver)
        : base(driver)
    {
    }

    protected override string Url => "https://www.selenium.dev/documentation/en/getting_started";


    public void ClickOnComponentsField()
    {
        
        SeleniumOverviewField.Click();
        SeleniumComponentsField.Click();

        
    }

    public void CliclOnGitHubRepoLink()
    {
           MoveToElement(By.XPath("//a[@href='https://github.com/SeleniumHQ/seleniumhq.github.io/commit/6b87463b63700d38146e82130776bf4d832bf82d']"));
           GitHubLinkField.Click();

    }
}
