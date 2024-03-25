using EcommerceLambdaProject.Pages.RegisterPage;

namespace EcommerceLambdaProject.Pages.MyAccountPage;
public partial class MyAccountPages : WebPage
{
    public MyAccountPages(IDriver driver) : base(driver)
    {
    }

    public void GoToEditMyAccount()
    {
        EditMyAccountButton.Click();
    }


    public void ChangeMyAccountInfrmation(PersonalInformation user)
    {
      
        FirstNameInput.TypeText(user.FirstName);
        LastaNameInput.TypeText(user.LastName);
        EmailAddressNameInput.TypeText("alabala@gmail.com");
        TelephoneInput.TypeText(user.Telephone);
        ContinueButton.Click();
    }

    public void ChangeMyPassword()
    {
        ChangeMyPasswordButton.Click();
        PasswordField.TypeText("tester");
        ConfirmPasswordField.TypeText("tester");
        ContinueButton.Click();

    }

    public void PuchaseGiftCertificate(PurchaseGiftCertificate gift)
    {
        RecipientName.TypeText(gift.RecipientName);
        RecipientEmail.TypeText(gift.RecipientEmail);
        YourName.TypeText(gift.YourName);
        YourEmail.TypeText(gift.YourEmail);
        BirthdayCertificate.Click();
        AmountCertificate.TypeText(gift.Amount);
        AgreeGiftCertificate.Click();
        ContinueButton.Click();
    }

}