namespace EcommerceLambdaProject.Pages.RegisterPage;
public partial class RegisterPages
{
    private string ErrorMessageUrl => "The URL is not correct";
    private string ErrorMessageLogoutButton => "Logout button is not displayed";

    public void AssertSuccessfullyRegisterUrlIsShown(string distanceUrl)
    {

        var message = $"{ErrorMessageUrl} \n Actual URL:{distanceUrl} \n Expected URL:{Url.SUCCESSFUL_REGISTRATION_PAGE}";
        CollectionAssert.AreEqual(distanceUrl, Url.SUCCESSFUL_REGISTRATION_PAGE, message);

    }

    public void AssertLogoutButtonIsDisplayed()
    {
       var isMapDisplayed = LogoutButton.Displayed;
       var message = $"{ErrorMessageLogoutButton} \n Actual Result:{!isMapDisplayed} \n Expected Result:{isMapDisplayed}";
       Assert.That((bool)isMapDisplayed, ErrorMessageLogoutButton, message);
    }
}