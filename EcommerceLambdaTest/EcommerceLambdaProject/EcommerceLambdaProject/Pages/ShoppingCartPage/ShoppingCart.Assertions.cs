namespace EcommerceLambdaProject.Pages;

public partial class ShoppingCartPage
{
    public void AssertProductName(ProductDetails expectedProduct)
    {
        var messageName = $"{ErrorMessageProduct} \n Actual Result:{ProductNameElement(expectedProduct.Id, expectedProduct.Name).Text} \n Expected Result:{expectedProduct.Name}";
        Assert.That(ProductNameElement(expectedProduct.Id, expectedProduct.Name).Text, Is.EqualTo(expectedProduct.Name), messageName);
        Driver.WaitForAjax();
    }

    public void AssertProductInformation(ProductDetails expectedProductInfo)
    {
        var messageModel = $"{ErrorMessageProduct} \n Actual Result:{ProductModel(expectedProductInfo.Model).Text} \n Expected Result:{expectedProductInfo.Model}";
        Assert.That(ProductModel(expectedProductInfo.Model).Text, Is.EqualTo(expectedProductInfo.Model), messageModel);

        var messageQuantity = $"{ErrorMessageProduct} \n Actual Result:{ProductQuantity("form-control").GetAttribute("value")} \n Expected Result:{expectedProductInfo.Quantity}";
        Assert.That(ProductQuantity("form-control").GetAttribute("value"), Is.EqualTo(expectedProductInfo.Quantity), messageQuantity);

        var messagePrice = $"{ErrorMessageProduct} \n Actual Result:{ProductPriceElement(expectedProductInfo.UnitPrice).Text} \n Expected Result:{expectedProductInfo.UnitPrice}";
        Assert.That(ProductPriceElement(expectedProductInfo.UnitPrice).Text, Is.EqualTo(expectedProductInfo.UnitPrice), messagePrice);

        var totalPriceMessage = $"{ErrorMessage} \n Actual Result:{ProductTotalPriceElement(expectedProductInfo.Total.ToString()).Text} \n Expected Result:{expectedProductInfo.Total}";
        Assert.That(ProductTotalPriceElement(expectedProductInfo.Total.ToString()).Text, Is.EqualTo(expectedProductInfo.Total.ToString("C")), totalPriceMessage);

        RemoveButton.Click();
        Driver.WaitForAjax();
    }

    public void AssertProductRemoved()
    {
        var expectedProductInfo = new ProductDetails();
        var errorMessageRemovedProduct = $"The product '{expectedProductInfo.Name}' is still present in the Shopping Cart.";
        var expectedMessage = "Your shopping cart is empty!";
        var message = $"{errorMessageRemovedProduct} \n Actual Result:{RemovedProduct(expectedMessage).Text} \n Expected Result:{expectedMessage}";
        Assert.That(RemovedProduct(expectedMessage).Text.Contains(expectedMessage), message);
    }

    public void AssertSuccessfullyUpdatedQuantity(string expectedQuantity)
    {
        var message = $"{ErrorMessageProduct} \n Actual Result:{UpdateQuantityField.GetAttribute("value")} \n Expected Result:{expectedQuantity}";
        Assert.That(expectedQuantity, Is.EqualTo(UpdateQuantityField.GetAttribute("value")), message);
        RemoveButton.Click();
        Driver.WaitForAjax();
    }
}