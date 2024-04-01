namespace EcommerceLambdaProject.Pages.MyAccountPage;
public partial class MyAccountPages
{
    private string ErrorMessageDate => "The expected Date are not correct";
    private string ErrorMessageUrl => "The URL is not correct";
    private string ErrorMessagePassword => "Your password hasn't been successfully updated";
    private string ErrorMessageAddress => "Your address hasn't been successfully added";
    private string SuccessfullyPurchaseVaucherMessage => "Purchase a Gift Certificate";
    private string SuccessfullyPassowrdMessage => "Success: Your password has been successfully updated.";
    private string SuccessfullyAccountInformationUpdatedMessage => "Success: Your account has been successfully updated.";
    private string SuccessfullyAddedNewAddressMessage => "Your address has been successfully added";

    public void AssertAccountInformationIsSuccessfullyUpdated()
    {
        var message = $"{ErrorMessagePassword} \n Actual Result:{SuccessfullyAccountInformationUpdatedMessage} \n Expected Result:{SuccessfullyMessage.Text}";
        CollectionAssert.AreEqual(SuccessfullyMessage.Text, SuccessfullyAccountInformationUpdatedMessage, message);
    }

    public void AssertPasswordIsSuccessfullyChanged()
    {
        var message = $"{ErrorMessagePassword} \n Actual Result:{SuccessfullyPassowrdMessage} \n Expected Result:{SuccessfullyMessage.Text}";
       CollectionAssert.AreEqual(SuccessfullyMessage.Text, SuccessfullyPassowrdMessage, message);
    }

    public void AssertSuccessfullyPurchaseGiftCertificate()
    {
        var message = $"{ErrorMessagePassword} \n Actual Result:{SuccessfullyPurchaseVaucherMessage} \n Expected Result:{SuccessfullyPurchaseCertificate.Text}";
        CollectionAssert.AreEqual(SuccessfullyPurchaseCertificate.Text, SuccessfullyPurchaseVaucherMessage, message);
    }


    public void AssertSuccessfullyGoToAddNewAddressUrl(string expectedUrl)
    {
        var message = $"{ErrorMessageUrl} \n Actual URL:{expectedUrl} \n Expected URL:{Url.NEW_ADDRESS_PAGE}";
        CollectionAssert.AreEqual(expectedUrl, Url.NEW_ADDRESS_PAGE, message);
    }

    public void AssertSuccessfullyAddedNewAddres()
    {
        var message = $"{ErrorMessageAddress} \n Actual Result:{SuccessfullyAddedNewAddressMessage} \n Expected Result:{SuccessfullyMessage.Text}";
        CollectionAssert.AreEqual(SuccessfullyMessage.Text, SuccessfullyAddedNewAddressMessage, message);
    }

    public void AssertCustomerNameIsCorrect(string expectedFullname )
    {
        var nameMessage = $"{ErrorMessageAddress} \n Actual Result:{CustomerElement(expectedFullname).Text} \n Expected Result:{expectedFullname}";
        CollectionAssert.AreEqual(CustomerElement(expectedFullname).Text, expectedFullname, nameMessage);

    }

    public void AssertThePurchaseDateIsToday()
    {
        var currentDate = DateTime.Now.ToString("dd/MM/yyyy");
        var dateMessage = $"{ErrorMessageDate} \n Actual Result:{DateTimeElement(DateTime.Now.ToString("dd/MM/yyyy")).Text} \n Expected Result:{currentDate}";
        CollectionAssert.AreEquivalent(DateTimeElement(DateTime.Now.ToString("dd/MM/yyyy")).Text, currentDate, dateMessage);
    }
}