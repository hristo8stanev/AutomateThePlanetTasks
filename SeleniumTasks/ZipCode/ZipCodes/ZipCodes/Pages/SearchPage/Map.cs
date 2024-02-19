using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ZipCodes.Pages.SearchPage;
public partial class SearchPage
{

    public IWebElement AdvanceSearchButton => WaitAndFindElement(By.XPath("//h3[@id='ui-id-7']"));
    public IWebElement searchField => WaitAndFindElement(By.XPath("(//input[@name='Submit' and @value='Find ZIP Codes'])[2]"));
    public IWebElement acceptCookie => WaitAndFindElement(By.XPath("//button[@class='fc-button fc-cta-consent fc-primary-button']"));
    public IWebElement ZipCodeField => WaitAndFindElement(By.XPath("//*[contains(text(),'Standard')][1]"));
    public IWebElement CityField => WaitAndFindElement(By.XPath("//input[@name='fld-city' and @aria-label ='City' and @placeholder='City' and  @class='form-control']"));
    public IWebElement StateField => WaitAndFindElement(By.XPath("//h3[@id='ui-id-7']"));
    public IWebElement CountryField => WaitAndFindElement(By.XPath("//h3[@id='ui-id-7']"));
    public IWebElement AreaCode => WaitAndFindElement(By.XPath("//h3[@id='ui-id-7']"));

    public IWebElement tableCityColumn => WaitAndFindElement(By.XPath("//table[@id='tblZIP']//th[contains(text(), 'City')]"));

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public IWebElement FirstCity => WaitAndFindElement(By.XPath("//table[@id='tblZIP']//tr[1]//td[2]//a"));
    public IWebElement FieldCity => WaitAndFindElement(By.XPath("//table[@class='striped']//td[2])[2]"));
    public IWebElement FieldState => WaitAndFindElement(By.XPath("(//input[@name='fld-state2'])[1]"));
    public IWebElement PersonalZipCodeField => WaitAndFindElement(By.XPath("(//table[@id='tblZIP']//td[1])[1]"));
    public IWebElement LongtitudeLatitudeCountry => WaitAndFindElement(By.XPath("(//table[@class='striped']//td[2])[9]"));
   

}
