using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ZipCodes.Pages.BasePage;
using static System.Net.Mime.MediaTypeNames;

namespace ZipCodes.Pages.SearchPage;
public partial class SearchPage : WebPage
{

    public SearchPage(IWebDriver driver)
        : base(driver)
    {
    }
    protected override string Url => "https://www.zip-codes.com/search.asp";


    public void ProceedToAdvanceSearch()
    {
        AdvanceSearchButton.Click();

    }

    public void AcceptCookies()
    {
        AcceptCookie.Click();
    }

    public void AcceptGoogleCookies()
    {

      bool areVisible = false;
      Driver.Manage().Cookies.AllCookies.ToList().ForEach(cookie =>
        {
            areVisible = cookie.Value == "511=IGpRt4VwpN0zG2L97MKh5AF9vfTVmAKyZc4S85MnjZlIhjUugVEfJd6WkrCXHRov3DkqhORbTUP9dEzj2Oz97gTSLvw3VuF-4HbtPTEAt4G_AfmuSpEMtDtWqCEO6yQhORx4YaUHZdSqWJX4afiEO6EsJcuE4321IHKb3sZCbKHTxf-rzMsqi4vO";
        });

    //
    //   if (Driver.Manage().Cookies.AllCookies.Contains(Cookie))
    // {
    //     return;
    // }
    // 
    // Driver.Manage().Cookies.AddCookie(new Cookie("NID", "511=F6LJPC7ETQk1n93iu775PEkSoTQ8EzixEaGycs0ZGlbdAF4cLzjVEm7E9vW7Kmarn4nGDaON1PxGmcqlgZvDYTjgRT-a8abPAsvJaFSZeR62o5qgbgmAcbN4AwumrihW4m1bFghuxkoPqsHaAtB-VCV3lCwRlqxWXaJz8mQdEOOVZ2zNKrPOW0k_PtCJ89ccrw"));
    // Driver.Manage().Cookies.AddCookie(new Cookie("UULE", "a+cm9sZTogMQpwcm9kdWNlcjogMTIKdGltZXN0YW1wOiAxNzA4NjA3MDY1MTExMDAwCmxhdGxuZyB7CiAgbGF0aXR1ZGVfZTc6IDQyNjUwMDIwMwogIGxvbmdpdHVkZV9lNzogMjMzNzM2OTgzCn0KcmFkaXVzOiAyMzI5NzU4LjQ2MTMyNTgyMwpwcm92ZW5hbmNlOiA2Cg=="));
    // Driver.Manage().Cookies.AddCookie(new Cookie("SOCS", "CAISHAgBEhJnd3NfMjAyNDAyMTQtMF9SQzMaAmJnIAEaBgiA-tSuBg"));
    // Driver.Manage().Cookies.AddCookie(new Cookie("AEC", "CAISHAgBEhJnd3NfMjAyNDAyMTQtMF9SQzMaAmJnIAEaBgiA-tSuBg"));
    // Driver.Navigate().Refresh();

        if (areVisible )
        {
            return;
        }

        // SECOND METHOD
        var consentDiv = WebDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//*[@class='s1EFBf']")));
        MoveToElement(By.XPath("//*[@class='s1EFBf']"));
        Thread.Sleep(1000);
        Driver.FindElement(By.XPath("(//*[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc LQeN7 XWZjwc'])[2]")).Click();
    }
    public void SearchTownByName(string name)
    {
        CityField.SendKeys(name);
        searchField.Click();
    }
}