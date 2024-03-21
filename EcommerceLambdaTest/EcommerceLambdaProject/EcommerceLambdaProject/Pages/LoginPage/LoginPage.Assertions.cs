namespace EcommerceLambdaProject.Pages.LoginPage;
public partial class LoginPages
{
    private string ErrorMessageUrl => "The URL is not correct";
    private string ErrorMessageLogoutButton => "Logout button is not displayed";
    public void AssertSuccessfullyLoginUrlIsShown(string distanceUrl)
    {

        var message = $"{ErrorMessageUrl} \n Actual URL:{distanceUrl} \n Expected URL:{Url.ACCOUNT_PAGE}";
        CollectionAssert.AreEqual(distanceUrl, Url.ACCOUNT_PAGE, message);

    }
    public void AssertLogoutButtonIsDisplayed()
    {
        var isMapDisplayed = LogoutButton.Displayed;
        var message = $"{ErrorMessageLogoutButton} \n Actual Result:{!isMapDisplayed} \n Expected Result:{isMapDisplayed}";
        Assert.That((bool)isMapDisplayed, ErrorMessageLogoutButton, message);
    }
}