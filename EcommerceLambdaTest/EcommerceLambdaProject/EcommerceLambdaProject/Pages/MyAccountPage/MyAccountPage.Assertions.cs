namespace EcommerceLambdaProject.Pages;

public partial class MyAccountPage
{
   
    public void AssertAccountInformationIsSuccessfullyUpdated()
    {
        var successfullyUpdatedAccountInfoMessage = $"{ErrorMessagePassword} \n Actual Result:{SuccessfullyAccountInformationUpdatedMessage} \n Expected Result:{SuccessfullyMessage.Text}";
        Assert.That(SuccessfullyMessage.Text, Is.EqualTo(SuccessfullyAccountInformationUpdatedMessage), successfullyUpdatedAccountInfoMessage);
    }

    public void AssertPasswordSuccessfullyChanged()
    {
        var successfullyChangePasswordMessage = $"{ErrorMessagePassword} \n Actual Result:{SuccessfullyPasswordMessage} \n Expected Result:{SuccessfullyMessage.Text.Trim()}";
        Assert.That(SuccessfullyMessage.Text.Trim(), Is.EqualTo(SuccessfullyPasswordMessage), successfullyChangePasswordMessage);
    }

    public void AssertSuccessfullyPurchaseGiftCertificate()
    {
        var successfullyPurchaseGiftCertificateMessage = $"{ErrorMessagePassword}  \n Actual Result: {SuccessfullyPurchaseVoucherMessage} \n Expected Result:{SuccessfullyPurchaseCertificate.Text}";
        Assert.That(SuccessfullyPurchaseCertificate.Text, Is.EqualTo(SuccessfullyPurchaseVoucherMessage), successfullyPurchaseGiftCertificateMessage);
    }

    public void AssertSuccessfullyAddedNewAddress()
    {
        var successfullyAddedNewAddressMessage = $"{ErrorMessageAddress}  \n Actual Result: {SuccessfullyAddedNewAddressMessage} \n Expected Result:{SuccessfullyMessage.Text.Trim()}";
        Assert.That(SuccessfullyMessage.Text.Trim(), Is.EqualTo(SuccessfullyAddedNewAddressMessage), successfullyAddedNewAddressMessage);
    }

    public void AssertCustomerNameCorrect(PersonalInformation user)
    {
        var expectedFullName = user.FirstName + " " + user.LastName;
        var customerNameMessage = $"{ErrorMessageAddress} \n Actual Result:{CustomerElement(expectedFullName).Text} \n Expected Result:{expectedFullName}";
        Assert.That(CustomerElement(expectedFullName).Text, Is.EqualTo(expectedFullName), customerNameMessage);
    }

    public void AssertThePurchaseDateToday()
    {
        var currentDate = DateTime.Now.ToString("dd/MM/yyyy");
        var dateMessage = $"{ErrorMessageDate} \n Actual Result:{DateTimeElement(DateTime.Now.ToString("dd/MM/yyyy")).Text} \n Expected Result:{currentDate}";
        Assert.That(DateTimeElement(DateTime.Now.ToString("dd/MM/yyyy")).Text, Is.EqualTo(currentDate), dateMessage);
    }

    public void AssertGiftCertificateAddedToShoppingCart(PurchaseGiftCertificate purchaseGiftCertificate)
    {
        var actualResult = GiftPriceNameElement(purchaseGiftCertificate.Amount, purchaseGiftCertificate.RecipientName).Text;
        var nameMessage = $"{ErrorMessageAddress} \n Actual Result: {actualResult} \n Expected Result: ${purchaseGiftCertificate.Amount}.00 Gift Certificate for {purchaseGiftCertificate.RecipientName}";
        Assert.That(GiftPriceNameElement(purchaseGiftCertificate.Amount, purchaseGiftCertificate.RecipientName).Text, Is.EqualTo($"${purchaseGiftCertificate.Amount}.00 Gift Certificate for {purchaseGiftCertificate.RecipientName}"), nameMessage);
    }

    public void AssertGiftCertificateRemoved(PurchaseGiftCertificate giftName)
    {
        var errorMessageRemovedProduct = $"The gift for'{giftName.RecipientName}' is still present in the Shopping Cart.";
        var expectedMessage = "Your shopping cart is empty!";
        var giftCertificateMessage = $"{errorMessageRemovedProduct} \n Actual Result:{RemovedProduct(expectedMessage).Text} \n Expected Result:{expectedMessage}";
        Assert.That(RemovedProduct(expectedMessage).Text.Contains(expectedMessage), giftCertificateMessage);
    }

    public void AssertProductReturnsMessage(string expectedMessage)
    {
        var returnProductMessage = $"{ErrorMessageReturns} \n Actual Result:{ProductReturnsMessage} \n Expected Result:{SuccessfullyProductReturn(expectedMessage).Text}";
        Assert.That(SuccessfullyProductReturn(expectedMessage).Text, Is.EqualTo(ProductReturnsMessage), returnProductMessage);
    }
}