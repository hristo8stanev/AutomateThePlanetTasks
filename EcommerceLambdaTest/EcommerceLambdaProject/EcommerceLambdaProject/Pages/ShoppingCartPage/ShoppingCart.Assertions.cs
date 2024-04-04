namespace EcommerceLambdaProject.Pages;

public partial class ShoppingCartPage
{
    public void AssertProductName(ProductDetails expectedProductName, int productName)
    {
        var message = $"{Constants.Constants.ErrorMessageProduct} \n Actual Result:{ProductNameElement(productName, expectedProductName.Name).Text} \n Expected Result:{expectedProductName.Name}";
        Assert.That(ProductNameElement(productName, expectedProductName.Name).Text, Is.EqualTo(expectedProductName.Name), message);
        Driver.WaitForAjax();
    }

    public void AssertProductInformation(ProductDetails expectedProductInfo, int modelId)
    {
        var message = $"{Constants.Constants.ErrorMessageProduct} \n Actual Result:{ProductElementInformation("text-left", modelId).Text} \n Expected Result:{expectedProductInfo.Model}";
        Assert.That(ProductElementInformation("text-left", modelId).Text, Is.EqualTo(expectedProductInfo.Model), message);

        var messageQuantity = $"{Constants.Constants.ErrorMessageProduct} \n Actual Result:{ProductQuantity("form-control").GetAttribute("value")} \n Expected Result:{expectedProductInfo.Quantity}";
        Assert.That(ProductQuantity("form-control").GetAttribute("value"), Is.EqualTo(expectedProductInfo.Quantity), messageQuantity);

        var messagePrice = $"{Constants.Constants.ErrorMessageProduct} \n Actual Result:{ProductPriceElement(expectedProductInfo.UnitPrice).Text} \n Expected Result:{expectedProductInfo.UnitPrice}";
        Assert.That(ProductPriceElement(expectedProductInfo.UnitPrice).Text, Is.EqualTo(expectedProductInfo.UnitPrice), messagePrice);
        RemoveButton.Click();
        Driver.WaitForAjax();
    }

    public void AssertProductRemoved(string expectedProductInfo)
    {
        var errorMessageRemovedProduct = $"The product '{expectedProductInfo}' is still present in the Shopping Cart.";
        var expectedMessage = "Your shopping cart is empty!";
        var message = $"{errorMessageRemovedProduct} \n Actual Result:{RemovedProduct(expectedMessage).Text} \n Expected Result:{expectedMessage}";
        Assert.That(RemovedProduct(expectedMessage).Text.Contains(expectedMessage), message);
    }

    public void AssertSuccessfullyUpdatedQuantity(string expectedQuantity)
    {
        var message = $"{Constants.Constants.ErrorMessageProduct} \n Actual Result:{UpdateQuantityField.GetAttribute("value")} \n Expected Result:{expectedQuantity}";
        Assert.That(expectedQuantity, Is.EqualTo(UpdateQuantityField.GetAttribute("value")), message);
        RemoveButton.Click();
        Driver.WaitForAjax();
    }
}