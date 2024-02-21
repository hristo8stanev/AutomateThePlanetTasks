using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;
using SeleniumWebdriverHelpers;
using OpenQA.Selenium.Interactions;

namespace PlayPianoProject;

public class PlayPiano
{

    private int NORMAL_PAUSE_BETWEEN_NOTES_MILLISECONDS = 300;
    private int LONG_PAUSE_BETWEEN_NOTES_MILLISECONDS = 500;
    public IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _driver = new ChromeDriver();    
        _driver.Manage().Window.Maximize();
      
    }

    [Test]
    public void PianoTest()
    {
        _driver.Navigate().GoToUrl("https://virtualpiano.net/?song-post-10686#dismissed%22)");
        _driver.Manage().Cookies.AddCookie(new Cookie("complianz_consent_status", "allow"));
        _driver.Navigate().Refresh();

        var webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("key_51")));
        webDriverWait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0"));

        var songPatternDiv = _driver.FindElement(By.Id("song-pattern"));
        var allPaternSpans = songPatternDiv.FindElements(By.TagName("span"));

        foreach (var span in allPaternSpans)
        {

            if (span.GetAttribute("class") == "pause")
            {
                Thread.Sleep(NORMAL_PAUSE_BETWEEN_NOTES_MILLISECONDS);
            }
            else
            {


                Actions actions = new Actions(_driver);
                foreach (char note in span.Text)
                {
                    actions = actions.KeyDown(note.ToString());
                }

                foreach (char note in span.Text)
                {
                    actions = actions.KeyUp(note.ToString());
                }

                actions.Perform();
            }
        }
    }

    [TearDown]
    public void Cleanup()
    {

        _driver.Dispose();
    }
}