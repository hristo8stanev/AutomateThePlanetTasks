
using EcommerceLambdaProject.Pages.ProductPage;

namespace EcommerceLambdaProject.Pages.CheckoutPage;
public partial class CheckoutPages
{

    private string ErrorMessageProduct => "This product is not exist";
    public string ErrorMessageLogoutButton => "Your order hasn't been placed successfully";

    public void AssertSuccessfullyCheckoutUrl(string expectedUrl)
    {

        var message = $"{Url.SUCCESSFUL_ORDER_PAGE} \n Actual URL:{expectedUrl} \n Expected URL:{Url.SUCCESSFUL_ORDER_PAGE}";
        CollectionAssert.AreEqual(expectedUrl, Url.SUCCESSFUL_ORDER_PAGE, message);

    }

     public void AssertConfirmButtonIsDisplayed()
     {

         var isMapDisplayed = ConfirmOrderButton.Displayed;
         var message = $"{ErrorMessageLogoutButton} \n Actual Result:{!isMapDisplayed} \n Expected Result:{isMapDisplayed}";
         Assert.That((bool)isMapDisplayed, ErrorMessageLogoutButton, message);
     }



    public void AssertSuccessfullyCheckoutTheOrder(string expectedMessage)
    {
        
        var message = $"{ErrorMessageLogoutButton} \n Actual Result:{SuccessfullyConfirmOrderText.Text} \n Expected Result:{expectedMessage}";
        CollectionAssert.AreEqual(SuccessfullyConfirmOrderText.Text, expectedMessage, message);
    }

    public void AssertProductInformationIsCorrect(ProductDetails expectedProductInfo, int indexModel)
    {
        var message = $"{ErrorMessageProduct} \n Actual Result:{ProductModelCheckoutPage(indexModel).Text} \n Expected Result:{expectedProductInfo.Model}";
        CollectionAssert.AreEqual(ProductModelCheckoutPage(indexModel).Text, expectedProductInfo.Model, message);

        var messageQuantity = $"{ErrorMessageProduct} \n Actual Result:{ProductQuantityCheckoutPage("text-left").GetAttribute("value")} \n Expected Result:{expectedProductInfo.Quantity}";
        CollectionAssert.AreEqual(ProductQuantityCheckoutPage("text-left").GetAttribute("value"), expectedProductInfo.Quantity, messageQuantity);
       

    }
}
