namespace EcommerceLambdaProject.Pages;

public partial class ShoppingCartPage
{
    public void AssertProductName(ProductDetails expectedProductName, int productName)
    {
        var messageName = $"{Constants.Constants.ErrorMessageProduct} \n Actual Result:{ProductNameElement(productName, expectedProductName.Name).Text} \n Expected Result:{expectedProductName.Name}";
        Assert.That(ProductNameElement(productName, expectedProductName.Name).Text, Is.EqualTo(expectedProductName.Name), messageName);
        Driver.WaitForAjax();
    }

    public void AssertProductInformation(ProductDetails expectedProductInfo)
    {
        var messageModel = $"{Constants.Constants.ErrorMessageProduct} \n Actual Result:{ProductModel(expectedProductInfo.Model).Text} \n Expected Result:{expectedProductInfo.Model}";
        Assert.That(ProductModel(expectedProductInfo.Model).Text, Is.EqualTo(expectedProductInfo.Model), messageModel);

        var messageQuantity = $"{Constants.Constants.ErrorMessageProduct} \n Actual Result:{ProductQuantity("form-control").GetAttribute("value")} \n Expected Result:{expectedProductInfo.Quantity}";
        Assert.That(ProductQuantity("form-control").GetAttribute("value"), Is.EqualTo(expectedProductInfo.Quantity), messageQuantity);

        var messagePrice = $"{Constants.Constants.ErrorMessageProduct} \n Actual Result:{ProductPriceElement(expectedProductInfo.UnitPrice).Text} \n Expected Result:{expectedProductInfo.UnitPrice}";
        Assert.That(ProductPriceElement(expectedProductInfo.UnitPrice).Text, Is.EqualTo(expectedProductInfo.UnitPrice), messagePrice);

        var totalPriceMessage = $"{Constants.Constants.ErrorMessage} \n Actual Result:{ProductTotalPriceElement(expectedProductInfo.Total.ToString()).Text} \n Expected Result:{expectedProductInfo.Total}";
        Assert.That(ProductTotalPriceElement(expectedProductInfo.Total.ToString()).Text, Is.EqualTo(expectedProductInfo.Total.ToString("C")), totalPriceMessage);

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