namespace EcommerceLambdaProject.Pages.RegisterPage;
public partial class RegisterPages
{
    private string ErrorMessageLogoutButton => "Logout button is not displayed";
    private string SuccessfullyLogin => "Your Account Has Been Created!";
    private string ErrorMessageEmptyFirstName => "First Name must be between 1 and 32 characters!";
    private string ErrorMessageEmptyEmailAddress => "E-Mail Address does not appear to be valid!";
    private string ErrorMessageEmptyPassword => "Password must be between 4 and 20 characters!";

    public void AssertLogoutButtonIsDisplayed()
    {
       var isMapDisplayed = LogoutButton.Displayed;
       var message = $"{ErrorMessageLogoutButton} \n Actual Result:{!isMapDisplayed} \n Expected Result:{isMapDisplayed}";
       Assert.That((bool)isMapDisplayed, ErrorMessageLogoutButton, message);
    }

    public void AssertErrorMessageForErrorMessageFirstName()
    {
  
        var message = $"{SuccessfullyLogin} \n Actual Result:{ErrorMessageEmptyFistNameField.Text} \n Expected Result:{ErrorMessageEmptyFirstName}";
        CollectionAssert.AreEqual(ErrorMessageEmptyFistNameField.Text, ErrorMessageEmptyFirstName, message);
    }

    public void AssertErrorMessageForErrorMessageEmailAddress()
    {

        var message = $"{SuccessfullyLogin} \n Actual Result:{ErrorMessageEmptyEmailAddressField.Text} \n Expected Result:{ErrorMessageEmptyEmailAddress}";
        CollectionAssert.AreEqual(ErrorMessageEmptyEmailAddressField.Text, ErrorMessageEmptyEmailAddress, message);
    }

    public void AssertErrorMessageForErrorMessagePassword()
    {

        var message = $"{SuccessfullyLogin} \n Actual Result:{ErrorMessageEmptyPasswordField.Text} \n Expected Result:{ErrorMessageEmptyPassword}";
        CollectionAssert.AreEqual(ErrorMessageEmptyPasswordField.Text, ErrorMessageEmptyPassword, message);
    }
}