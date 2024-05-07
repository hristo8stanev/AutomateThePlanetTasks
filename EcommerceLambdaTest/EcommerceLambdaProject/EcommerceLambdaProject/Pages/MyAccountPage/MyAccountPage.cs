namespace EcommerceLambdaProject.Pages;

public partial class MyAccountPage : WebPage
{
    public MyAccountPage(IDriver driver)
        : base(driver)
    {
    }

    public override string Url => ACCOUNT_PAGE;

    public void SelectGiftType(GiftCertificateType giftCertificateType)
    {
        switch (giftCertificateType)
        {
            case GiftCertificateType.General:
                GeneralCertificate.Click();
                break;

            case GiftCertificateType.Birthday:
                BirthdayCertificate.Click();
                break;

            case GiftCertificateType.Christmas:
                ChristmasCertificate.Click();
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(giftCertificateType), giftCertificateType, "Unsupported gift certificate type");
        }
    }

    public void SelectReasonType(ReasonType reasonType)
    {
        switch (reasonType)
        {
            case ReasonType.DeadOnArrival:
                ReturnReasonInput(1).Click();
                break;

            case ReasonType.FaultyPleaseSupplyDetails:
                ReturnReasonInput(2).Click();
                break;

            case ReasonType.OrderError:
                ReturnReasonInput(3).Click();
                break;

            case ReasonType.OtherPleaseSupplyDetails:
                ReturnReasonInput(4).Click();
                break;

            case ReasonType.ReceivedWrongItem:
                ReturnReasonInput(5).Click();
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(reasonType), reasonType, "Unsupported gift certificate type");
        }
    }

    public void SelectIsProductOpened(ProductOpened productOpened)
    {
        switch (productOpened)
        {
            case ProductOpened.Yes:
                ProductOpenedInput(1).Click();
                break;

            case ProductOpened.No:
                ProductOpenedInput(0).Click();
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(productOpened), productOpened, "Unsupported gift certificate type");
        }
    }

    public void ProceedToAddressBookSection()
    {
        AddressBookButton.Click();
        NewAddressButton.Click();
        Driver.WaitForAjax();
    }
    public void ProceedToMyVoucherSection()
    {
        MyAccountMenuSection.Hover();
        MyVoucherButton.Click();
        Driver.WaitForAjax();
    }

    public void ProceedToOrderHistorySection()
    {
        MyAccountMenuSection.Click();
        MyOrderHistoryButton.Click();
        Driver.WaitForAjax();
    }

    public void ProceedToReturnOrderSection()
    {
        MyAccountMenuSection.Hover();
        ReturnOrderButton.Click();
        Driver.WaitForAjax();
    }

    public void RemoveProductFromCart()
    {
        Driver.WaitForAjax();
        RemoveButton.Click();
    }

    public void AddNewAddress(BillingInformation billingInformation)
    {
        FirstNameInput.TypeText(billingInformation.FirstName);
        LastNameInput.TypeText(billingInformation.LastName);
        CompanyInput.TypeText(billingInformation.Company);
        AddressInput1.TypeText(billingInformation.Address1);
        AddressInput2.TypeText(billingInformation.Address2);
        CityInput.TypeText(billingInformation.City);
        PostCodeInput.TypeText(billingInformation.PostCode);
        Country(billingInformation.Country).Click();
        Driver.WaitForAjax();
        Region(billingInformation.Region).Click();
        ContinueButton.Click();
    }

    public void ChangeMyAccountInformation(PersonalInformation user)
    {
        EditMyAccountButton.Click();
        FirstNameInput.TypeText(user.FirstName);
        LastNameInput.TypeText(user.LastName);
        EmailAddressNameInput.TypeText(EmailAddress);
        TelephoneInput.TypeText(user.Telephone);
        ContinueButton.Click();
    }

    public void ChangeMyPassword()
    {
        ChangeMyPasswordButton.Click();
        PasswordInput.TypeText(Password);
        ConfirmPasswordInput.TypeText(Password);
        ContinueButton.Click();
    }

    public void PurchaseGiftCertificate(PurchaseGiftCertificate gift)
    {
        RecipientNameInput.TypeText(gift.RecipientName);
        RecipientEmailInput.TypeText(gift.RecipientEmail);
        YourNameInput.TypeText(gift.YourName);
        YourEmailInput.TypeText(gift.YourEmail);
        SelectGiftType(GiftCertificateType.Birthday);
        AmountCertificateInput.TypeText(gift.Amount);
        AgreeGiftCertificate.Click();
        ContinueButton.Click();
    }

    public void FillReturnProductForm(ProductDetails product)
    {
        SelectReasonType(ReasonType.DeadOnArrival);
        OrderIdInput.TypeText(product.Id.ToString());
        OrderDateInput.TypeText(DateTime.Now.ToString("dd/MM/yyyy"));
        ProductNameInput.TypeText(product.Name);
        ProductCodeInput.TypeText(product.Model);
        ProductQuantityInput.TypeText(product.Quantity);
        SelectIsProductOpened(ProductOpened.Yes);
        SubmitButton.Click();
    }
}