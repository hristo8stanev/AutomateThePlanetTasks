using FirstSeleniumProject.Tests.Core.BaseTest;


namespace FirstSeleniumProject.Tests.SeleniumSiteProjectTests;
public class SeleniumTests : BaseTest
{
  
    [Test]
    public void SeleniumDocumentationComponentGridFieldClicknOnGitHubRepoLink()
    {
        _mainPage.GoTo();
        _mainPage.ProceedToComponents();
        _mainPage.AssertComponentsDocumentationPageIsShown(_driver.Url);
        _mainPage.ProceedToGitHubLink();
        _mainPage.AssertGitHubLinkIsShown(_driver.Url);
    }
}