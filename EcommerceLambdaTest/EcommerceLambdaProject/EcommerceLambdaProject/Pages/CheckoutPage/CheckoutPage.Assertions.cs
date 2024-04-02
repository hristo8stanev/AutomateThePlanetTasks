namespace EcommerceLambdaProject.Pages;

public partial class CheckoutPage
{
    private const string ErrorMessageProduct = "This product is not exist";
    private const string ErrorMessageLogoutButton = "Your order hasn't been placed successfully";

    public void AssertConfirmButtonIsDisplayed()
    {
        var message = $"{ErrorMessageLogoutButton} \n Actual Result:{!ConfirmOrderButton.Displayed} \n Expected Result:{ConfirmOrderButton.Displayed}";
        Assert.That(ConfirmOrderButton.Displayed, Is.True, ErrorMessageLogoutButton, message);
    }

    public void AssertSuccessfullyCheckoutTheOrder(string expectedMessage)
    {
        var message = $"{ErrorMessageLogoutButton} \n Actual Result:{SuccessfullyConfirmOrderText.Text} \n Expected Result:{expectedMessage}";
        Assert.That(SuccessfullyConfirmOrderText.Text, Is.EqualTo(expectedMessage), message);
    }

    public void AssertProductInfoIsCorrectCheckoutPage(ProductDetails expectedProduct, int productId)
    {
        var nameMessage = $"{ErrorMessageProduct} \n Actual Result:{ProductNameElementCheckoutPage(productId, expectedProduct.Name).Text} \n Expected Result:{expectedProduct.Name}";
        Assert.That(ProductNameElementCheckoutPage(productId, expectedProduct.Name).Text, Is.EqualTo(expectedProduct.Name), nameMessage);

        var quantityMessage = $"{ErrorMessageProduct} \n Actual Result:{ProductQuantityElementCheckout(productId, expectedProduct.Name).GetAttribute("value")} \n Expected Result:{expectedProduct.Quantity}";
        Assert.That(ProductQuantityElementCheckout(productId, expectedProduct.Name).GetAttribute("value"), Is.EqualTo(expectedProduct.Quantity), quantityMessage);

        var priceMessage = $"{ErrorMessageProduct} \n Actual Result:{ProductPriceElementCheckout("text-right", expectedProduct.UnitPrice).Text} \n Expected Result:{expectedProduct.UnitPrice}";
        Assert.That(ProductPriceElementCheckout("text-right", expectedProduct.UnitPrice).Text, Is.EqualTo(expectedProduct.UnitPrice), priceMessage);
    }

    public void AssertProductInfoConfirmOrderIsCorrect(ProductDetails expectedProductInfo)
    {
        var nameMessage = $"{ErrorMessageProduct} \n Actual Result:{ConfirmOrderProductName("text-left", expectedProductInfo.Name).Text} \n Expected Result:{expectedProductInfo.Name}";
        Assert.That(ConfirmOrderProductName("text-left", expectedProductInfo.Name).Text, Is.EqualTo(expectedProductInfo.Name), nameMessage);

        var modelMessage = $"{ErrorMessageProduct} \n Actual Result:{ConfirmOrderInformation("text-left", expectedProductInfo.Model).Text} \n Expected Result:{expectedProductInfo.Model}";
        Assert.That(ConfirmOrderProductName("text-left", expectedProductInfo.Model).Text, Is.EqualTo(expectedProductInfo.Model), modelMessage);

        var quantityMessage = $"{ErrorMessageProduct} \n Actual Result:{ConfirmOrderQuantityElement(expectedProductInfo.Model).Text} \n Expected Result:{expectedProductInfo.Quantity}";
        Assert.That(ConfirmOrderQuantityElement(expectedProductInfo.Model).Text, Is.EqualTo(expectedProductInfo.Quantity), quantityMessage);

        var priceMessage = $"{ErrorMessageProduct} \n Actual Result:{ConfirmOrderPriceElement(expectedProductInfo.Quantity).Text} \n Expected Result:{expectedProductInfo.UnitPrice}";
        Assert.That(ConfirmOrderPriceElement(expectedProductInfo.Quantity).Text, Is.EqualTo(expectedProductInfo.UnitPrice), priceMessage);
    }
}