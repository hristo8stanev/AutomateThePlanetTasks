using System.Linq;
using EcommerceLambdaProject.Pages.ProductPage;

namespace EcommerceLambdaProject.Pages.ShoppingCartPage;
public partial class ShoppingCartPages
{
    private string ErrorMessageProduct => "This product is not exist";
    private string ErrorMessageQuantity => "The expected and actual quantity of the product is not equal!";

    public void AssertSuccessfullyShoppingCartUrl(string expectedUrl)
    {

        var message = $"{Url.CART_PAGE} \n Actual URL:{expectedUrl} \n Expected URL:{Url.CART_PAGE}";
        CollectionAssert.AreEqual(expectedUrl, Url.CART_PAGE, message);
    }

    public void AssertProductNameIsCorrect(ProductDetails expectedProductName, int indexName)
    {
        var message = $"{ErrorMessageProduct} \n Actual Result:{ProductNameElement(indexName,expectedProductName.Name).Text} \n Expected Result:{expectedProductName.Name}";
        CollectionAssert.AreEqual(ProductNameElement(indexName, expectedProductName.Name).Text, expectedProductName.Name, message);

        Driver.WaitForAjax();

    }
    public void AssertProductInformationIsCorrect(ProductDetails expectedProductInfo, int indexModel, int indexQuantity, int indexUnitPrice)
    {

       var message = $"{ErrorMessageProduct} \n Actual Result:{ProductElementInformation("text-left", indexModel).Text} \n Expected Result:{expectedProductInfo.Model}";
       CollectionAssert.AreEqual(ProductElementInformation("text-left", indexModel).Text, expectedProductInfo.Model, message);

        var messageQuantity = $"{ErrorMessageProduct} \n Actual Result:{ProductQuantityInformation("text-left").GetAttribute("value")} \n Expected Result:{expectedProductInfo.Quantity}";
        CollectionAssert.AreEqual(ProductQuantityInformation("text-left").GetAttribute("value"), expectedProductInfo.Quantity, messageQuantity);

        var messagePrice = $"{ErrorMessageProduct} \n Actual Result:{ProductElementInformation("text-left", indexUnitPrice).Text} \n Expected Result:{expectedProductInfo.UnitPrice}";
        CollectionAssert.AreEqual(ProductElementInformation("text-left", indexUnitPrice).Text, expectedProductInfo.UnitPrice, messagePrice);

        
        RemoveButton.Click();
        Driver.WaitForAjax();
    }


    
    public void AssertProductRemoveFromTheCart(string expectedProductInfo)
    {
        var errorMessageRemovedProduct = $"The product '{expectedProductInfo}' is still present in the Shopping Cart.";
        var expectedMessage = "Your shopping cart is empty!";

        var message = $"{errorMessageRemovedProduct} \n Actual Result:{RemovedProduct(expectedMessage).Text} \n Expected Result:{expectedMessage}";
        Assert.That(RemovedProduct(expectedMessage).Text.Contains(expectedMessage), message);

    }

    public void AssertSuccessfullyUpdatedQuantityOfProduct(string expectedQuantity)
    {
        var message = $"{ErrorMessageQuantity} \n Actual Result:{UpdateQuantityTextField.GetAttribute("value")} \n Expected Result:{expectedQuantity}";
        CollectionAssert.AreEqual(expectedQuantity, UpdateQuantityTextField.GetAttribute("value"), message);

        RemoveButton.Click();
        Driver.WaitForAjax();

    }
}