using BlueHostingLogin.Pages.BasePage;
using OpenQA.Selenium;

namespace BlueHostingLogin.Pages.BlueHostPage;
public partial class BlueHostMainPage : WebPage
{

    DateTime localDate = DateTime.Now;
    public BlueHostMainPage(IWebDriver driver)
        : base(driver)
    {
    }

    protected override string Url => "https://www.bluehost.com/my-account/login";
    public void ClickOnWemailLogin()
    {
        WebmailLogin.Click();

    }
    public void AcceptCookies()
    {
      //public Cookie(string name, string value, string domain, string path, DateTime? expiry, bool secure, bool isHttpOnly, string sameSite)
      // Driver.Manage().Cookies.AddCookie(new Cookie("OptanonConsent", "isGpcEnabled=0&datestamp=Wed+Feb+28+2024+11%3A30%3A16+GMT%2B0200+(Eastern+European+Standard+Time)&version=202312.1.0&browserGpcFlag=0&isIABGlobal=false&hosts=&consentId=9d08c90a-6197-4792-a2a9-d7802b8de748&interactionCount=1&landingPath=https%3A%2F%2Fwww.bluehost.com%2Fmy-account%2Flogin&groups=C0001%3A1%2CC0002%3A0%2CC0003%3A0%2CC0004%3A0"
      //     , ".bluehost.com", "/", localDate, true, false, "None"));
      // Driver.Navigate().Refresh();

       AcceptCookie.Click();
    }

    public void FillEmail(FillingInfo purchaseInfo)
    {
        EmailField.SendKeys(purchaseInfo.EmailAdress);
    }


    public void ProceedWithLogin()
    {
        LoginButton.Click();
        NextButton.Click();
    }
}
