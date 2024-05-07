namespace EcommerceLambdaProject.Pages;

public partial class RegisterPage
{
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