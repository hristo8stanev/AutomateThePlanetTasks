using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace YourNamespace
{
    public class SeleniumTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [Test]
        public void VerifySeleniumDocumentationPageTitle()
        {
            
            driver.Navigate().GoToUrl("https://www.selenium.dev/documentation/en/getting_started");

            
     
        }

        [TearDown]
        public void Cleanup()
        {
          
            driver.Dispose();
        }
    }
}