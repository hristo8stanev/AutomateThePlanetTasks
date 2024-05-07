namespace EcommerceLambdaProject.Pages;

public partial class LoginPage
{
    
    public void AssertLogoutButtonDisplayed()
    {
        var logoutMessage = $"{ErrorMessageLogoutButton} \n Actual Result:{!LogoutButton.Displayed} \n Expected Result:{LogoutButton.Displayed}";
        Assert.That(LogoutButton.Displayed, Is.True, ErrorMessageLogoutButton, logoutMessage);
        LogoutButton.Click();
    }

    public void AssertSuccessfullySentEmail()
    {
        var sentEmailMessage = $"{ErrorMessageConfirmationEmail} \n Actual Result:{!ConfirmationMessage.Displayed} \n Expected Result:{ConfirmationMessage.Displayed}";
        Assert.That(ConfirmationMessage.Displayed, Is.True, ExpectedMessageForConfirmationEmail, sentEmailMessage);
    }

    public void AssertErrorMessageWithWrongCredentials()
    {
        var wrongCredentialsMessage = $"{ErrorMessageConfirmationEmail} \n Actual Result:{!WarningMessage.Displayed} \n Expected Result:{WarningMessage.Displayed}";
        Assert.That(WarningMessage.Displayed, Is.True, ExpectedMessageWrongCredentials, wrongCredentialsMessage);
    }

    public void AssertWarningMessageInvalidEmail()
    {
        var invalidEmailMessage = $"{ErrorMessageConfirmationEmail} \n Actual Result:{!WarningMessage.Displayed} \n Expected Result:{WarningMessage.Displayed}";
        Assert.That(WarningMessage.Displayed, Is.True, ExpectedMessageForInvalidEmail, invalidEmailMessage);
    }

    public void AssertAccountSuccessfullyLogout()
    {
        var SuccessfullyLogoutMessage = $"{ErrorMessageConfirmationEmail} \n Actual Result:{!AccountLogout.Displayed} \n Expected Result:{AccountLogout.Displayed}";
        Assert.That(AccountLogout.Displayed, Is.True, ExpectedMessageAccountLogout, SuccessfullyLogoutMessage);
    }
}