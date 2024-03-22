using System.Linq;

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

    public void AssertProductNameIsCorrect(string expectedProductName)
    {
        var ProductName = ProductNameElement.Text;
        var message = $"{ErrorMessageProduct} \n Actual Result:{ProductName} \n Expected Result:{expectedProductName}";
        CollectionAssert.AreEqual(expectedProductName, ProductName, message);
    }


    public void AssertProductRemoveFromTheCart(string product)
    {
        var errorMessageRemovedProduct = $"The product '{product}' is still present in the Shopping Cart.";
        var expectedMessage = "Your shopping cart is empty!";

        var actualMessage = RemovedProduct(expectedMessage).Text;
        var message = $"{errorMessageRemovedProduct} \n Actual Result:{actualMessage} \n Expected Result:{expectedMessage}";
        Assert.That(actualMessage.Contains(expectedMessage), message);
    }

    public void AssertSuccessfullyUpdatedQuantityOfProduct(string expectedQuantity)
    {

        var ProductQuantity = UpdateQuantityTextField.GetAttribute("value");
        var message = $"{ErrorMessageQuantity} \n Actual Result:{ProductQuantity} \n Expected Result:{expectedQuantity}";
        CollectionAssert.AreEqual(expectedQuantity, ProductQuantity, message);

    }
}