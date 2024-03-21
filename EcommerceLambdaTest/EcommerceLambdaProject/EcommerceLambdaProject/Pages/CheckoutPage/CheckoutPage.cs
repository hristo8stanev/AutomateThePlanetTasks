
namespace EcommerceLambdaProject.Pages.CheckoutPage;
public partial class CheckoutPages : WebPage
{
    public CheckoutPages(IDriver driver) : base(driver)
    {
    }

    public void ProceedToCheckout()
    {
        AgreeTerms.Click();
        ContinueButton.Click();
        ConfirmOrderButton.Hover();
    }

    public void ConfirmOrder()
    {
      
        ConfirmOrderButton.Click();
    }
}
