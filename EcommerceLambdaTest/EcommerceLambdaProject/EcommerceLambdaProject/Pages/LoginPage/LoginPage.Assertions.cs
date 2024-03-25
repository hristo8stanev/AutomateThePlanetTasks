namespace EcommerceLambdaProject.Pages.LoginPage;
public partial class LoginPages
{
    private string ErrorMessageUrl => "The URL is not correct";
    private string ErrorMessageLogoutButton => "Logout button is not displayed";
    private string ExpectedMessageForConfirmationEmail => " An email with a confirmation link has been sent your email address.";
    private string ExpectedMessageForInvalidEmail => " Warning: The E-Mail Address was not found in our records, please try again!";
    private string ErrorMessageConfirmationEmail => "Your email address is not correct";
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
    public void AssertSuccessfullyForgottenPasswordUrlIsShown(string distanceUrl)
    {

        var message = $"{ErrorMessageUrl} \n Actual URL:{distanceUrl} \n Expected URL:{Url.FORGOTTEN_PASSWORD_PAGE}";
        CollectionAssert.AreEqual(distanceUrl, Url.FORGOTTEN_PASSWORD_PAGE, message);
    }

    public void AssertSuccessfullySentEmail()
    {
        
        var message = $"{ErrorMessageConfirmationEmail} \n Actual Result:{!ConfirmationSentEmailMessage.Displayed} \n Expected Result:{ConfirmationSentEmailMessage.Displayed}";
        Assert.That((bool)ConfirmationSentEmailMessage.Displayed, ExpectedMessageForConfirmationEmail, message);
    }

    public void AssertWarningMessageInvalidEmail()
    {

        var message = $"{ErrorMessageConfirmationEmail} \n Actual Result:{!WarningEmailMessage.Displayed} \n Expected Result:{WarningEmailMessage.Displayed}";
        Assert.That((bool)WarningEmailMessage.Displayed, ExpectedMessageForInvalidEmail, message);
    }

    public void AssertLoginUrlIsShown(string distanceUrl)
    {

        var message = $"{ErrorMessageUrl} \n Actual URL:{distanceUrl} \n Expected URL:{Url.LOGIN_PAGE}";
        CollectionAssert.AreEqual(distanceUrl, Url.LOGIN_PAGE, message);

    }

}