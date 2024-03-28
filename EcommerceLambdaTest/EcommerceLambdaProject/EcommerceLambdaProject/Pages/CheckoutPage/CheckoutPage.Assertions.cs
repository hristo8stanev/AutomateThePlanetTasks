using System;
using EcommerceLambdaProject.Pages.ProductPage;

namespace EcommerceLambdaProject.Pages.CheckoutPage;
public partial class CheckoutPages
{
    private string ErrorMessageProduct => "This product is not exist";
    private string ErrorMessageLogoutButton => "Your order hasn't been placed successfully";

    public void AssertConfirmButtonIsDisplayed()
    {
        var message = $"{ErrorMessageLogoutButton} \n Actual Result:{!ConfirmOrderButton.Displayed} \n Expected Result:{ConfirmOrderButton.Displayed}";
        Assert.That((bool)ConfirmOrderButton.Displayed, ErrorMessageLogoutButton, message);
    }

    public void AssertSuccessfullyCheckoutTheOrder(string expectedMessage)
    {
        var message = $"{ErrorMessageLogoutButton} \n Actual Result:{SuccessfullyConfirmOrderText.Text} \n Expected Result:{expectedMessage}";
        CollectionAssert.AreEqual(SuccessfullyConfirmOrderText.Text, expectedMessage, message);
    }

   public void AssertProductInfoIsCorrectCheckoutPage(ProductDetails expectedProduct, int index)
    {
        var nameMessage = $"{ErrorMessageProduct} \n Actual Result:{ProductNameElementCheckoutPage(index,expectedProduct.Name).Text} \n Expected Result:{expectedProduct.Name}";
        CollectionAssert.AreEqual(ProductNameElementCheckoutPage(index, expectedProduct.Name).Text, expectedProduct.Name, nameMessage);

       var quantityMessage = $"{ErrorMessageProduct} \n Actual Result:{ProductQuantityElementCheckout(index, expectedProduct.Name).GetAttribute("value")} \n Expected Result:{expectedProduct.Quantity}";
       CollectionAssert.AreEqual(ProductQuantityElementCheckout(index, expectedProduct.Name).GetAttribute("value"), expectedProduct.Quantity, quantityMessage);

        var priceMessage = $"{ErrorMessageProduct} \n Actual Result:{ProductPriceElementCheckout("text-right",expectedProduct.UnitPrice).Text} \n Expected Result:{expectedProduct.UnitPrice}";
        CollectionAssert.AreEqual(ProductPriceElementCheckout("text-right", expectedProduct.UnitPrice).Text, expectedProduct.UnitPrice, priceMessage);

    }

    public void AssertProductInfoConfirmOrderIsCorrect(ProductDetails expectedProductInfo)
    {
        var nameMessage = $"{ErrorMessageProduct} \n Actual Result:{ConfirmOrderProductName("text-left", expectedProductInfo.Name).Text} \n Expected Result:{expectedProductInfo.Name}";
        CollectionAssert.AreEqual(ConfirmOrderProductName("text-left", expectedProductInfo.Name).Text, expectedProductInfo.Name, nameMessage);

        var modelMessage = $"{ErrorMessageProduct} \n Actual Result:{ConfirmOrderInformation("text-left", expectedProductInfo.Model).Text} \n Expected Result:{expectedProductInfo.Model}";
        CollectionAssert.AreEqual(ConfirmOrderProductName("text-left", expectedProductInfo.Model).Text, expectedProductInfo.Model, modelMessage);

        var quantityMessage = $"{ErrorMessageProduct} \n Actual Result:{ConfirmOrderQuantityElement(expectedProductInfo.Model).Text} \n Expected Result:{expectedProductInfo.Quantity}";
        CollectionAssert.AreEqual(ConfirmOrderQuantityElement(expectedProductInfo.Model).Text, expectedProductInfo.Quantity, quantityMessage);

        var priceMessage = $"{ErrorMessageProduct} \n Actual Result:{ConfirmOrderPriceElement(expectedProductInfo.Quantity).Text} \n Expected Result:{expectedProductInfo.UnitPrice}";
        CollectionAssert.AreEqual(ConfirmOrderPriceElement(expectedProductInfo.Quantity).Text, expectedProductInfo.UnitPrice, priceMessage);
    }
}