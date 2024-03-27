using System;
using EcommerceLambdaProject.Pages.ProductPage;

namespace EcommerceLambdaProject.Pages.CheckoutPage;
public partial class CheckoutPages
{

    private string ErrorMessageProduct => "This product is not exist";
    public string ErrorMessageLogoutButton => "Your order hasn't been placed successfully";

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

    public void AssertProductNameIsCorrect(ProductDetails expectedProduct, int index)
    {
        var nameMessage = $"{ErrorMessageProduct} \n Actual Result:{ProductNameElement(index, expectedProduct.Name).Text} \n Expected Result:{expectedProduct.Name}";
        CollectionAssert.AreEqual(ProductNameElement(index, expectedProduct.Name).Text, expectedProduct.Name, nameMessage);

        Driver.WaitForAjax();
    }

    public void AssertProductInformationIsCorrect(ProductDetails expectedProductInfo, int indexModel)
    {
        var message = $"{ErrorMessageProduct} \n Actual Result:{ProductModelCheckoutPage(indexModel).Text} \n Expected Result:{expectedProductInfo.Model}";
        CollectionAssert.AreEqual(ProductModelCheckoutPage(indexModel).Text, expectedProductInfo.Model, message);

        var messageQuantity = $"{ErrorMessageProduct} \n Actual Result:{ProductQuantityCheckoutPage("text-left").GetAttribute("value")} \n Expected Result:{expectedProductInfo.Quantity}";
        CollectionAssert.AreEqual(ProductQuantityCheckoutPage("text-left").GetAttribute("value"), expectedProductInfo.Quantity, messageQuantity);
    }


    public void AssertProductInfoConfirmOrderIsCorrect(ProductDetails expectedProductInfo)
    {
        var nameMessage = $"{ErrorMessageProduct} \n Actual Result:{ConfirmOrderProductName("text-left", expectedProductInfo.Name).Text} \n Expected Result:{expectedProductInfo.Name}";
        CollectionAssert.AreEqual(ConfirmOrderProductName("text-left", expectedProductInfo.Name).Text, expectedProductInfo.Name, nameMessage);

        var modelMessage = $"{ErrorMessageProduct} \n Actual Result:{ConfirmOrderInformation("text-left", expectedProductInfo.Model).Text} \n Expected Result:{expectedProductInfo.Model}";
        CollectionAssert.AreEqual(ConfirmOrderProductName("text-left", expectedProductInfo.Model).Text, expectedProductInfo.Model, modelMessage);

      //  var quantityMessage = $"{ErrorMessageProduct} \n Actual Result:{ConfirmOrderProductName("text-right", expectedProductInfo.Quantity).Text} \n Expected Result:{expectedProductInfo.Quantity}";
      //  CollectionAssert.AreEqual(ConfirmOrderProductName("text-right", expectedProductInfo.Quantity).Text, expectedProductInfo.Quantity, quantityMessage);

    }
}