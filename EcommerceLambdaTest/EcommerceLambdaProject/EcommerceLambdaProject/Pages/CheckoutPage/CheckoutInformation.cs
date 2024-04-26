namespace EcommerceLambdaProject.Pages;
public class CheckoutInformation
{
    public List<ProductDetails> Products { get; set; }
    public double FlatShippingRate { get { return 5.00; } }
    public double SubTotal { get { return Products.Select(p => p.Total).Sum(); } }
    public double EcoTax
    {
        get
        {
            int totalQuantity = 0;

            foreach (var product in Products)
            {
                int.TryParse(product.Quantity, out int quantity);

                totalQuantity += quantity;
            }

            var ecoTax = 4.00;
            var remainingQuantity = totalQuantity - 1;

            while (remainingQuantity > 0)
            {
                ecoTax += 2.00;
                remainingQuantity--;
            }
            return ecoTax;
        }
    }
    public double VatTax { get { return Math.Ceiling(SubTotal * 0.20 + 1); } }
    public double Total { get { return FlatShippingRate + SubTotal + VatTax + EcoTax; } }
    public string Coupon { get; set; }
    public string GiftCertificate { get; set; }
    public bool isVatApplied { get; set; }
}
