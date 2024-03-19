namespace BlueHostingLogin.Pages.BlueHostPage;
public partial class BlueHostMainPage
{
    public void AssertVerifyButtonIsDisplayed()
    {
        bool isDisplayed = IncorrectMessageAfterLogin.Displayed;

        Assert.That(isDisplayed);
    }
}
