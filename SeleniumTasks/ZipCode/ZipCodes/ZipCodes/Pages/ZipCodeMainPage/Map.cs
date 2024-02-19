using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ZipCodes.Pages.ZipCodeMainPage;
public partial class ZipCodeMainPage
{

    public IWebElement ProceedToSearchButton => WaitAndFindElement(By.XPath("//a[contains(@title, 'FREE ZIP Code Search')]"));
    
    

}

