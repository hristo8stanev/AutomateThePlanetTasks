namespace EcommerceLambdaProject.Pages;

public partial class RegisterPage
{
    private const string ErrorMessageLogoutButton = "Logout button is not displayed";
    private const string SuccessfullyLogin = "Your Account Has Been Created!";
    private const string ErrorMessageEmptyFirstName = "First Name must be between 1 and 32 characters!";
    private const string ErrorMessageEmptyEmailAddress = "E-Mail Address does not appear to be valid!";
    private const string ErrorMessageEmptyPassword = "Password must be between 4 and 20 characters!";

    public void AssertLogoutButtonIsDisplayed()
    {
        var message = $"{ErrorMessageLogoutButton} \n Actual Result:{!LogoutButton.Displayed} \n Expected Result:{LogoutButton.Displayed}";
        Assert.That(LogoutButton.Displayed, Is.True, ErrorMessageLogoutButton, message);
    }

    public void AssertErrorMessageForErrorMessageFirstName()
    {
        var message = $"{SuccessfullyLogin} \n Actual Result:{ErrorMessageEmptyFistNameField.Text} \n Expected Result:{ErrorMessageEmptyFirstName}";
        Assert.That(ErrorMessageEmptyFistNameField.Text, Is.EqualTo(ErrorMessageEmptyFirstName), message);
    }

    public void AssertErrorMessageForErrorMessageEmailAddress()
    {
        var message = $"{SuccessfullyLogin} \n Actual Result:{ErrorMessageEmptyEmailAddressField.Text} \n Expected Result:{ErrorMessageEmptyEmailAddress}";
        Assert.That(ErrorMessageEmptyEmailAddressField.Text, Is.EqualTo(ErrorMessageEmptyEmailAddress), message);
    }

    public void AssertErrorMessageForErrorMessagePassword()
    {
        var message = $"{SuccessfullyLogin} \n Actual Result:{ErrorMessageEmptyPasswordField.Text} \n Expected Result:{ErrorMessageEmptyPassword}";
        Assert.That(ErrorMessageEmptyPasswordField.Text, Is.EqualTo(ErrorMessageEmptyPassword), message);
    }
}