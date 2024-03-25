using NUnit.Framework;

namespace EcommerceLambdaProject.Pages.MyAccountPage;
public partial class MyAccountPages
{

    private string ErrorMessageUrl => "The URL is not correct";
    private string ErrorMessagePassword => "Your password hasn't been successfully updated";
    private string SuccessfullyPassowrdMessage => "Success: Your password has been successfully updated.";
    private string SuccessfullyAccountInformationUpdatedMessage => "Success: Your account has been successfully updated.";

    public void AssertAccountInformationIsSuccessfullyUpdated()
    {
        var message = $"{ErrorMessagePassword} \n Actual Result:{SuccessfullyAccountInformationUpdatedMessage} \n Expected Result:{SuccessfullyMessageChangePassword.Text}";
        CollectionAssert.AreEqual(SuccessfullyMessageChangePassword.Text, SuccessfullyAccountInformationUpdatedMessage, message);
    }

    public void AssertPasswordIsSuccessfullyChanged()
    {
        var message = $"{ErrorMessagePassword} \n Actual Result:{SuccessfullyPassowrdMessage} \n Expected Result:{SuccessfullyMessageChangePassword.Text}";
       CollectionAssert.AreEqual(SuccessfullyMessageChangePassword.Text, SuccessfullyPassowrdMessage, message);
    }

    public void AssertMyAccountUrlIsShown(string accountUrl)
    {
        var message = $"{ErrorMessageUrl} \n Actual URL:{accountUrl} \n Expected URL:{Url.ACCOUNT_PAGE}";
        CollectionAssert.AreEqual(accountUrl, Url.ACCOUNT_PAGE, message);
    }
}