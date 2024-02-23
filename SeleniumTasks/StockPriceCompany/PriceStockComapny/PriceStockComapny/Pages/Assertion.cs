using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PriceStockComapny.Pages;
public partial class InvestingPage
{
    private string errorMessageUrl => "The URL does not contain 'historical-data'";

    public void AssertHistoricDataUrlIsCorrect(string historicUrl)
    {
        Assert.That(historicUrl.Contains("historical-data"), Is.True, errorMessageUrl);
    }

    public void AssertPriceStockIsShown()
    {
        
        Assert.That(PriceExtract.Text, Is.Not.Null);
    }

}
