namespace EcommerceLambdaProject.Pages;
public class CheckoutInformation
{
    public List<ProductDetails> Products { get; set; }
    public double FlatShippingRate { get { return 5.00; } }
    public double EcoTax {  get { return Products.Select(p => 2.0).Sum() + 2.0; } }
    public double SubTotal { get { return Products.Select(p => p.Total).Sum(); } }
    public double VatTax { get { return SubTotal * 0.2; } }
    public double Total { get { return FlatShippingRate + EcoTax + SubTotal + VatTax; } }
    public string Coupon { get; set; }
    public string GiftCertificate { get; set; }
    public bool isVatApplied { get; set; }
}
