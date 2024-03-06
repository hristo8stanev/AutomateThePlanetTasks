using PriceStockCompany.Tests.Core;

namespace PriceStockCompany.Tests.Tests;

public class StockPricesTests : BaseTest
{
    
    string compnanyName = "Google";
    
    [Test]
    public void CompanyHistoryStocksPricesTest()
    {

        _mainPage.GoTo();
        _mainPage.AcceptCookies();
        _mainPage.SearchCompany(compnanyName);
        _mainPage.ChooseFirstResultFromSearchButton();
        _mainPage.ProceedToTheHistoryPriceOftheStock();
        _mainPage.AssertHistoricalDataUrlIsShown(_driver.Url);
        _mainPage.AssertThePriceOfStockIsShown();
    }
}