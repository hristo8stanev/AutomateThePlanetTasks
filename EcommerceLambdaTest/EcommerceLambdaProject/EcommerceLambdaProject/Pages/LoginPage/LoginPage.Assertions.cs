namespace EcommerceLambdaProject.Pages;

public partial class LoginPage
{
    
    public void AssertLogoutButtonIsDisplayed()
    {
        var message = $"{Constants.Constants.ErrorMessageLogoutButton} \n Actual Result:{!LogoutButton.Displayed} \n Expected Result:{LogoutButton.Displayed}";
        Assert.That(LogoutButton.Displayed, Is.True, Constants.Constants.ErrorMessageLogoutButton, message);
        LogoutButton.Click();
    }

    public void AssertSuccessfullySentEmail()
    {
        var message = $"{Constants.Constants.ErrorMessageConfirmationEmail} \n Actual Result:{!ConfirmationMessage.Displayed} \n Expected Result:{ConfirmationMessage.Displayed}";
        Assert.That(ConfirmationMessage.Displayed, Is.True, Constants.Constants.ExpectedMessageForConfirmationEmail, message);
    }

    public void AssertErrorMessageWithWrongCredentials()
    {
        var message = $"{Constants.Constants.ErrorMessageConfirmationEmail} \n Actual Result:{!WarningMessage.Displayed} \n Expected Result:{WarningMessage.Displayed}";
        Assert.That(WarningMessage.Displayed, Is.True, Constants.Constants.ExpectedMessageWrongCredentials, message);
    }

    public void AssertWarningMessageInvalidEmail()
    {
        var message = $"{Constants.Constants.ErrorMessageConfirmationEmail} \n Actual Result:{!WarningMessage.Displayed} \n Expected Result:{WarningMessage.Displayed}";
        Assert.That(WarningMessage.Displayed, Is.True, Constants.Constants.ExpectedMessageForInvalidEmail, message);
    }

    public void AssertAccountSuccessfullyLogout()
    {
        var message = $"{Constants.Constants.ErrorMessageConfirmationEmail} \n Actual Result:{!AccountLogout.Displayed} \n Expected Result:{AccountLogout.Displayed}";
        Assert.That(AccountLogout.Displayed, Is.True, Constants.Constants.ExpectedMessageAccountLogout, message);
    }
}