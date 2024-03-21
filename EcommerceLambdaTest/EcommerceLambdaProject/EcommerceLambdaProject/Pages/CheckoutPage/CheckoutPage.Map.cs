
namespace EcommerceLambdaProject.Pages.CheckoutPage;
public partial class CheckoutPages
{

    public IComponent AgreeTerms => Driver.FindComponent(By.XPath("//*[@for='input-agree']"));
    public IComponent ContinueButton => Driver.WaitAndFindElementJS(By.Id("button-save"));
    public IComponent ConfirmOrderButton => Driver.FindComponent(By.Id("button-confirm"));
    public IComponent Total => Driver.FindComponent(By.XPath("//table/tbody/tr/td[text()='Total:']"));
    public IComponent SuccessfullyConfirmOrderText => Driver.WaitAndFindElementJS(By.XPath("//h1[@class='page-title my-3']"));


}