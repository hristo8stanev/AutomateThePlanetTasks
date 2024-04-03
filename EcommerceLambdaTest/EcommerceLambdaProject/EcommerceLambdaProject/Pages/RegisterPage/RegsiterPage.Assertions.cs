namespace EcommerceLambdaProject.Pages;

public partial class RegisterPage
{
    public void AssertLogoutButtonIsDisplayed()
    {
        var message = $"{Constants.Constants.ErrorMessageLogoutButton} \n Actual Result:{!LogoutButton.Displayed} \n Expected Result:{LogoutButton.Displayed}";
        Assert.That(LogoutButton.Displayed, Is.True, Constants.Constants.ErrorMessageLogoutButton, message);
    }

    public void AssertErrorMessageForErrorMessageFirstName()
    {
        var message = $"{Constants.Constants.SuccessfullyLogin} \n Actual Result:{ErrorMessageEmptyFistNameField.Text} \n Expected Result:{Constants.Constants.ErrorMessageEmptyFirstName}";
        Assert.That(ErrorMessageEmptyFistNameField.Text, Is.EqualTo(Constants.Constants.ErrorMessageEmptyFirstName), message);
    }

    public void AssertErrorMessageForErrorMessageEmailAddress()
    {
        var message = $"{Constants.Constants.SuccessfullyLogin} \n Actual Result:{ErrorMessageEmptyEmailAddressField.Text} \n Expected Result:{Constants.Constants.ErrorMessageEmptyEmailAddress}";
        Assert.That(ErrorMessageEmptyEmailAddressField.Text, Is.EqualTo(Constants.Constants.ErrorMessageEmptyEmailAddress), message);
    }

    public void AssertErrorMessageForErrorMessagePassword()
    {
        var message = $"{Constants.Constants.SuccessfullyLogin} \n Actual Result:{ErrorMessageEmptyPasswordField.Text} \n Expected Result:{Constants.Constants.ErrorMessageEmptyPassword}";
        Assert.That(ErrorMessageEmptyPasswordField.Text, Is.EqualTo(Constants.Constants.ErrorMessageEmptyPassword), message);
    }
}