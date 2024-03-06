using ZipCodes.Pages.SearchPage;

namespace ZipCodes.Test.Core.BaseTest;
public class AdvanceSearchTests : BaseTest
{
    private string firstLetter => "H";

    [Test]
    public void AdvanceSearchCityNameZipCode()
    {
        _zipCodeMainPage.GoTo();
        _zipCodeMainPage.AdvanceSearch();
        _searchPage.ProceedToAdvanceSearch();
        _searchPage.AcceptCookies();
        _searchPage.AssertSearchPageIsShown(_driver.Url);
        _searchPage.SearchTownByName(firstLetter);
        _searchPage.AssertOAdvanceSearchedUrl(_driver.Url);
        _searchPage.IterateBetweenTheCities();
        CityDetails cityDetails = _searchPage.GetCityDetails();
        _searchPage.SaveScreenshot(cityDetails);
        _searchPage.GoBackToTable();

    }
}
