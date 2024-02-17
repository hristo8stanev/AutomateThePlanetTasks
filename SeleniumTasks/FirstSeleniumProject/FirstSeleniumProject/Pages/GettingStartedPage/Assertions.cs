using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSeleniumProject.Pages.GettingStartedPage;
public partial class MainPage
{
    private  string ErrorMessageIncorrectUrl => "Your URL is not correct";

    public void AssertComponentsDocumentationPageIsShown(string currentUrl)
    {
        
        Assert.That(currentUrl, Is.EqualTo("https://www.selenium.dev/documentation/overview/components/"), ErrorMessageIncorrectUrl);
    }

    public void AssertGitHubLinkIsShown(string githubUrl)
    {
        Assert.That(githubUrl, Is.EqualTo("https://github.com/SeleniumHQ/seleniumhq.github.io/commit/6b87463b63700d38146e82130776bf4d832bf82d"), ErrorMessageIncorrectUrl);
    }

}
