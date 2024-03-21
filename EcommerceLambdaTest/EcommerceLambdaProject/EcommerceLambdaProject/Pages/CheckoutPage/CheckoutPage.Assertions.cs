
namespace EcommerceLambdaProject.Pages.CheckoutPage;
public partial class CheckoutPages
{
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
}
