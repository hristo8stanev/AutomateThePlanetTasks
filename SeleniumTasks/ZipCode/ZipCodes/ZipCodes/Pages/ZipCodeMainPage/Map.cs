using OpenQA.Selenium;

namespace ZipCodes.Pages.ZipCodeMainPage;
public partial class ZipCodeMainPage
{

    public IWebElement ProceedToSearchButton => WaitAndFindElement(By.XPath("//a[contains(@title, 'FREE ZIP Code Search')]"));
    
    

}

