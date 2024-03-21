namespace EcommerceLambdaProject.Pages.ShoppingCartPage;
public partial class ShoppingCartPages
{

    public void AssertSuccessfullyShoppingCartUrl(string expectedUrl)
    {

        var message = $"{Url.CART_PAGE} \n Actual URL:{expectedUrl} \n Expected URL:{Url.CART_PAGE}";
        CollectionAssert.AreEqual(expectedUrl, Url.CART_PAGE, message);

    }

    public void AssertProductNameIsCorrect(string expectedProductName)
    {
        var ProductName = ProductNameElement.Text;
        var message = $"{"This product is not exist"} \n Actual Result:{ProductName} \n Expected Result:{expectedProductName}";
        CollectionAssert.AreEqual(expectedProductName, ProductName, message);
    }

    public void AssertShoppingCartIsEmpty()
    {
        var expectedEmptyCart = "Your shopping cart is empty!";
        var EmptyCart = EmptyShoppingCart.Text;
        var message = $"{"This product is not exist"} \n Actual Result:{EmptyCart} \n Expected Result:{expectedEmptyCart}";
        CollectionAssert.AreEqual(expectedEmptyCart, EmptyCart, message);


    }


}
