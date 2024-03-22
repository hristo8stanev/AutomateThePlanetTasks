using System.Linq;

namespace EcommerceLambdaProject.Pages.ShoppingCartPage;
public partial class ShoppingCartPages
{
    private string ErrorMessageProduct => "This product is not exist";
   

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


    public void assertProductRemoveFromTheCart(string product)
    {
        var errorMessageRemovedProduct = $"The product '{product}' is still present in the Shopping Cart.";
        var expectedMessage = "Your shopping cart is empty!";

        var actualMessage = RemovedProduct(expectedMessage).Text;
        var message = $"{errorMessageRemovedProduct} \n Actual Result:{actualMessage} \n Expected Result:{expectedMessage}";
        Assert.That(actualMessage.Contains(expectedMessage), message);
    }
}