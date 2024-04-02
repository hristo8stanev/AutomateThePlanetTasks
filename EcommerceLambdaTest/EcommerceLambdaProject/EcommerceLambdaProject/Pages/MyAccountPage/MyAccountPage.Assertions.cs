namespace EcommerceLambdaProject.Pages;

public partial class MyAccountPage
{
    private const string ErrorMessageDate = "The expected Date are not correct";
    private const string ErrorMessagePassword = "Your password hasn't been successfully updated";
    private const string ErrorMessageAddress = "Your address hasn't been successfully added";
    private const string SuccessfullyPurchaseVaucherMessage = "Purchase a Gift Certificate";
    private const string SuccessfullyPassowrdMessage = "Success: Your password has been successfully updated.";
    private const string SuccessfullyAccountInformationUpdatedMessage = "Success: Your account has been successfully updated.";
    private const string SuccessfullyAddedNewAddressMessage = "Your address has been successfully added";

    public void AssertAccountInformationIsSuccessfullyUpdated()
    {
        var message = $"{ErrorMessagePassword} \n Actual Result:{SuccessfullyAccountInformationUpdatedMessage} \n Expected Result:{SuccessfullyMessage.Text}";
        Assert.That(SuccessfullyMessage.Text, Is.EqualTo(SuccessfullyAccountInformationUpdatedMessage), message);
    }

    public void AssertPasswordIsSuccessfullyChanged()
    {
        var message = $"{ErrorMessagePassword} \n Actual Result:{SuccessfullyPassowrdMessage} \n Expected Result:{SuccessfullyMessage.Text}";
        Assert.That(SuccessfullyMessage.Text, Is.EqualTo(SuccessfullyPassowrdMessage), message);
    }

    public void AssertSuccessfullyPurchaseGiftCertificate()
    {
        var message = $"{ErrorMessagePassword} \n Actual Result:{SuccessfullyPurchaseVaucherMessage} \n Expected Result:{SuccessfullyPurchaseCertificate.Text}";
        Assert.That(SuccessfullyPurchaseCertificate.Text, Is.EqualTo(SuccessfullyPurchaseVaucherMessage), message);
    }

    public void AssertSuccessfullyAddedNewAddress()
    {
        var message = $"{ErrorMessageAddress} \n Actual Result:{SuccessfullyAddedNewAddressMessage} \n Expected Result:{SuccessfullyMessage.Text}";
        Assert.That(SuccessfullyMessage.Text, Is.EqualTo(SuccessfullyAddedNewAddressMessage), message);
    }

    public void AssertCustomerNameIsCorrect(string expectedFullName)
    {
        var nameMessage = $"{ErrorMessageAddress} \n Actual Result:{CustomerElement(expectedFullName).Text} \n Expected Result:{expectedFullName}";
        Assert.That(CustomerElement(expectedFullName).Text, Is.EqualTo(expectedFullName), nameMessage);
    }

    public void AssertThePurchaseDateIsToday()
    {
        var currentDate = DateTime.Now.ToString("DD/MM/Livvyy");
        var dateMessage = $"{ErrorMessageDate} \n Actual Result:{DateTimeElement(DateTime.Now.ToString("dd/MM/yyyy")).Text} \n Expected Result:{currentDate}";
        Assert.That(DateTimeElement(DateTime.Now.ToString("DD/MM/Livvyy")).Text, Is.EqualTo(currentDate), dateMessage);
    }
}