namespace EcommerceLambdaProject.Factories;

public static class CheckoutInformationFactory
{
    public static CheckoutInformation Build(params ProductDetails[] products)
    {
        var checkoutInformation = new CheckoutInformation();
        checkoutInformation.Products = products.ToList();
        checkoutInformation.isVatApplied = true;

        return checkoutInformation;
    }

    public static CheckoutInformation BuildWithCoupon(params ProductDetails[] products)
    {
        var checkoutInformation = Build(products);
        checkoutInformation.Coupon = "birthday";

        return checkoutInformation;
    }
    public static CheckoutInformation BuildWithGiftCertificate(params ProductDetails[] products)
    {
        var checkoutInformation = Build(products);
        checkoutInformation.GiftCertificate = "giftCertificate";

        return checkoutInformation;
    }
}