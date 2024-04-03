namespace EcommerceLambdaProject.Pages;

public partial class MyAccountPage
{
   
    public void AssertAccountInformationIsSuccessfullyUpdated()
    {
        var message = $"{Constants.Constants.ErrorMessagePassword} \n Actual Result:{Constants.Constants.SuccessfullyAccountInformationUpdatedMessage} \n Expected Result:{SuccessfullyMessage.Text}";
        Assert.That(SuccessfullyMessage.Text, Is.EqualTo(Constants.Constants.SuccessfullyAccountInformationUpdatedMessage), message);
    }

    public void AssertPasswordSuccessfullyChanged()
    {
        var message = $"{Constants.Constants.ErrorMessagePassword} \n Actual Result:{Constants.Constants.SuccessfullyPasswordMessage} \n Expected Result:{SuccessfullyMessage.Text.Trim()}";
        Assert.That(SuccessfullyMessage.Text.Trim(), Is.EqualTo(Constants.Constants.SuccessfullyPasswordMessage), message);
    }

    public void AssertSuccessfullyPurchaseGiftCertificate()
    {
        var message = $"{Constants.Constants.ErrorMessagePassword} \n Actual Result:{Constants.Constants.SuccessfullyPurchaseVoucherMessage} \n Expected Result:{SuccessfullyPurchaseCertificate.Text}";
        Assert.That(SuccessfullyPurchaseCertificate.Text, Is.EqualTo(Constants.Constants.SuccessfullyPurchaseVoucherMessage), message);
    }

    public void AssertSuccessfullyAddedNewAddress()
    {
        var message = $"{Constants.Constants.ErrorMessageAddress} \n Actual Result:{Constants.Constants.SuccessfullyAddedNewAddressMessage} \n Expected Result:{SuccessfullyMessage.Text.Trim()}";
        Assert.That(SuccessfullyMessage.Text.Trim(), Is.EqualTo(Constants.Constants.SuccessfullyAddedNewAddressMessage), message);
    }

    public void AssertCustomerNameCorrect(string expectedFullName)
    {
        var nameMessage = $"{Constants.Constants.ErrorMessageAddress} \n Actual Result:{CustomerElement(expectedFullName).Text} \n Expected Result:{expectedFullName}";
        Assert.That(CustomerElement(expectedFullName).Text, Is.EqualTo(expectedFullName), nameMessage);
    }

    public void AssertThePurchaseDateToday()
    {
        var currentDate = DateTime.Now.ToString("dd/MM/yyyy");
        var dateMessage = $"{Constants.Constants.ErrorMessageDate} \n Actual Result:{DateTimeElement(DateTime.Now.ToString("dd/MM/yyyy")).Text} \n Expected Result:{currentDate}";
        Assert.That(DateTimeElement(DateTime.Now.ToString("dd/MM/yyyy")).Text, Is.EqualTo(currentDate), dateMessage);
    }
}