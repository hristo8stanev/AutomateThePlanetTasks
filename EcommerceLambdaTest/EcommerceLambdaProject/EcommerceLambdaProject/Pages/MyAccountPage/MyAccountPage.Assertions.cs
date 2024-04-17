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

    public void AssertGiftCertificateAddedToShoppingCart(PurchaseGiftCertificate purchaseGiftCertificate)
    {
        var actualResult = GiftPriceNameElement(purchaseGiftCertificate.Amount, purchaseGiftCertificate.RecipientName).Text;
        var nameMessage = $"{Constants.Constants.ErrorMessageAddress} \n Actual Result: {actualResult} \n Expected Result: ${purchaseGiftCertificate.Amount}.00 Gift Certificate for {purchaseGiftCertificate.RecipientName}";
        Assert.That(GiftPriceNameElement(purchaseGiftCertificate.Amount, purchaseGiftCertificate.RecipientName).Text, Is.EqualTo($"${purchaseGiftCertificate.Amount}.00 Gift Certificate for {purchaseGiftCertificate.RecipientName}"), nameMessage);
    }

    public void AssertGiftCertificateRemoved(PurchaseGiftCertificate giftName)
    {
        var errorMessageRemovedProduct = $"The gift for'{giftName.RecipientName}' is still present in the Shopping Cart.";
        var expectedMessage = "Your shopping cart is empty!";
        var message = $"{errorMessageRemovedProduct} \n Actual Result:{RemovedProduct(expectedMessage).Text} \n Expected Result:{expectedMessage}";
        Assert.That(RemovedProduct(expectedMessage).Text.Contains(expectedMessage), message);
    }

    public void AssertProductReturnsMessage(string expectedMessage)
    {
        var message = $"{Constants.Constants.ErrorMessageReturns} \n Actual Result:{Constants.Constants.ProductReturnsMessage} \n Expected Result:{SuccessfullyProductReturn(expectedMessage).Text}";
        Assert.That(SuccessfullyProductReturn(expectedMessage).Text, Is.EqualTo(Constants.Constants.ProductReturnsMessage), message);
    }
}