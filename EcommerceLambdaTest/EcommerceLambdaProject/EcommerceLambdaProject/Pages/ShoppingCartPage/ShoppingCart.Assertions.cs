namespace EcommerceLambdaProject.Pages;

public partial class ShoppingCartPage
{
    private const string ErrorMessageProduct = "This product is not exist";
    private const string ErrorMessageQuantity = "The expected and actual quantity of the product is not equal!";

    public void AssertProductName(ProductDetails expectedProductName, int indexName)
    {
        var message = $"{ErrorMessageProduct} \n Actual Result:{ProductNameElement(indexName, expectedProductName.Name).Text} \n Expected Result:{expectedProductName.Name}";
        Assert.That(ProductNameElement(indexName, expectedProductName.Name).Text, Is.EqualTo(expectedProductName.Name), message);
        Driver.WaitForAjax();
    }

    public void AssertProductInformation(ProductDetails expectedProductInfo, int indexModel)
    {
        var message = $"{ErrorMessageProduct} \n Actual Result:{ProductElementInformation("text-left", indexModel).Text} \n Expected Result:{expectedProductInfo.Model}";
        Assert.That(ProductElementInformation("text-left", indexModel).Text, Is.EqualTo(expectedProductInfo.Model), message);

        var messageQuantity = $"{ErrorMessageProduct} \n Actual Result:{ProductQuantityInformation("form-control").GetAttribute("value")} \n Expected Result:{expectedProductInfo.Quantity}";
        Assert.That(ProductQuantityInformation("form-control").GetAttribute("value"), Is.EqualTo(expectedProductInfo.Quantity), messageQuantity);

        var messagePrice = $"{ErrorMessageProduct} \n Actual Result:{ProductPriceElement(expectedProductInfo.UnitPrice).Text} \n Expected Result:{expectedProductInfo.UnitPrice}";
        Assert.That(ProductPriceElement(expectedProductInfo.UnitPrice).Text, Is.EqualTo(expectedProductInfo.UnitPrice), messagePrice);
        RemoveButton.Click();
        Driver.WaitForAjax();
    }

    public void AssertProductRemovedFromTheCart(string expectedProductInfo)
    {
        var errorMessageRemovedProduct = $"The product '{expectedProductInfo}' is still present in the Shopping Cart.";
        var expectedMessage = "Your shopping cart is empty!";
        var message = $"{errorMessageRemovedProduct} \n Actual Result:{RemovedProduct(expectedMessage).Text} \n Expected Result:{expectedMessage}";
        Assert.That(RemovedProduct(expectedMessage).Text.Contains(expectedMessage), message);
    }

    public void AssertSuccessfullyUpdatedQuantityOfProduct(string expectedQuantity)
    {
        var message = $"{ErrorMessageQuantity} \n Actual Result:{UpdateQuantityTextField.GetAttribute("value")} \n Expected Result:{expectedQuantity}";
        Assert.That(expectedQuantity, Is.EqualTo(UpdateQuantityTextField.GetAttribute("value")), message);
        RemoveButton.Click();
        Driver.WaitForAjax();
    }
}