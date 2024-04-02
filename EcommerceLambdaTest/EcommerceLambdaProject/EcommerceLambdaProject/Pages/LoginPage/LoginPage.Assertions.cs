namespace EcommerceLambdaProject.Pages;

public partial class LoginPage
{
    private string ErrorMessageLogoutButton => "Logout button is not displayed";
    private string ExpectedMessageForConfirmationEmail => " An email with a confirmation link has been sent your email address.";
    private string ExpectedMessageForInvalidEmail => " Warning: The E-Mail Address was not found in our records, please try again!";
    private string ErrorMessageConfirmationEmail => "Your email address is not correct";
    private string ExpectedMessageAccountLogout => "Account Logout";
    private string ExpectedMessageWrongCredentials => "Warning: No match for E-Mail Address and/or Password.";

    public void AssertLogoutButtonIsDisplayed()
    {
        var message = $"{ErrorMessageLogoutButton} \n Actual Result:{!LogoutButton.Displayed} \n Expected Result:{LogoutButton.Displayed}";
        Assert.That(LogoutButton.Displayed, Is.True, ErrorMessageLogoutButton, message);
        LogoutButton.Click();
    }

    public void AssertSuccessfullySentEmail()
    {
        var message = $"{ErrorMessageConfirmationEmail} \n Actual Result:{!ConfirmationMessage.Displayed} \n Expected Result:{ConfirmationMessage.Displayed}";
        Assert.That(ConfirmationMessage.Displayed, Is.True, ExpectedMessageForConfirmationEmail, message);
    }

    public void AssertErrorMessageWithWrongCredentials()
    {
        var message = $"{ErrorMessageConfirmationEmail} \n Actual Result:{!WarningMessage.Displayed} \n Expected Result:{WarningMessage.Displayed}";
        Assert.That(WarningMessage.Displayed, Is.True, ExpectedMessageWrongCredentials, message);
    }

    public void AssertWarningMessageInvalidEmail()
    {
        var message = $"{ErrorMessageConfirmationEmail} \n Actual Result:{!WarningMessage.Displayed} \n Expected Result:{WarningMessage.Displayed}";
        Assert.That(WarningMessage.Displayed, Is.True, ExpectedMessageForInvalidEmail, message);
    }

    public void AssertAccountSuccessfullyLogout()
    {
        var message = $"{ErrorMessageConfirmationEmail} \n Actual Result:{!AccountLogout.Displayed} \n Expected Result:{AccountLogout.Displayed}";
        Assert.That(AccountLogout.Displayed, Is.True, ExpectedMessageAccountLogout, message);
    }
}