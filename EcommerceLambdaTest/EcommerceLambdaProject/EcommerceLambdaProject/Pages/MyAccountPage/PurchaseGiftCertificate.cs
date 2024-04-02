namespace EcommerceLambdaProject.Pages;

public class PurchaseGiftCertificate
{
    public string RecipientName { get; set; }
    public string RecipientEmail { get; set; }
    public string YourName { get; set; }
    public string YourEmail { get; set; }
    public GiftCertificateType GiftCertificateType { get; set; }
    public string Amount { get; set; }
}