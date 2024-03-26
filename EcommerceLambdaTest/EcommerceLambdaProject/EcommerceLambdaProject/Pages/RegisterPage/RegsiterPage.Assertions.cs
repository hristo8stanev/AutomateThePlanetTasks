namespace EcommerceLambdaProject.Pages.RegisterPage;
public partial class RegisterPages
{
    private string ErrorMessageLogoutButton => "Logout button is not displayed";

    public void AssertLogoutButtonIsDisplayed()
    {
       var isMapDisplayed = LogoutButton.Displayed;
       var message = $"{ErrorMessageLogoutButton} \n Actual Result:{!isMapDisplayed} \n Expected Result:{isMapDisplayed}";
       Assert.That((bool)isMapDisplayed, ErrorMessageLogoutButton, message);
    }
}