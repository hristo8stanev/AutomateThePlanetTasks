namespace EcommerceLambdaProject.Pages;

public partial class CheckoutPage
{
    public void AssertConfirmButtonDisplayed()
    {
        var message = $"{Constants.Constants.ErrorMessageLogoutButton} \n Actual Result:{!ConfirmOrderButton.Displayed} \n Expected Result:{ConfirmOrderButton.Displayed}";
        Assert.That(ConfirmOrderButton.Displayed, Is.True, Constants.Constants.ErrorMessageLogoutButton, message);
    }

    public void AssertSuccessfullyCheckoutOrder(string expectedMessage)
    {
        var message = $"{Constants.Constants.ErrorMessageLogoutButton} \n Actual Result:{SuccessfullyConfirmOrderText.Text} \n Expected Result:{expectedMessage}";
        Assert.That(SuccessfullyConfirmOrderText.Text, Is.EqualTo(expectedMessage), message);
    }

    public void AssertProductInformationCorrect(ProductDetails expectedProduct, int productId)
    {
        var nameMessage = $"{Constants.Constants.ErrorMessageProduct} \n Actual Result:{ProductNameElement(productId, expectedProduct.Name).Text} \n Expected Result:{expectedProduct.Name}";
        Assert.That(ProductNameElement(productId, expectedProduct.Name).Text, Is.EqualTo(expectedProduct.Name), nameMessage);

        var quantityMessage = $"{Constants.Constants.ErrorMessageProduct} \n Actual Result:{ProductQuantityElement(productId, expectedProduct.Name).GetAttribute("value")} \n Expected Result:{expectedProduct.Quantity}";
        Assert.That(ProductQuantityElement(productId, expectedProduct.Name).GetAttribute("value"), Is.EqualTo(expectedProduct.Quantity), quantityMessage);

        var unitPriceMessage = $"{Constants.Constants.ErrorMessageProduct} \n Actual Result:{ProductPriceElement("text-right", expectedProduct.UnitPrice).Text} \n Expected Result:{expectedProduct.UnitPrice}";
        Assert.That(ProductPriceElement("text-right", expectedProduct.UnitPrice).Text, Is.EqualTo(expectedProduct.UnitPrice), unitPriceMessage);

        var totalPriceMessage = $"{Constants.Constants.ErrorMessage} \n Actual Result:{ProductTotalPriceElement("text-right", expectedProduct.UnitPrice).Text} \n Expected Result:{expectedProduct.Total}";
        Assert.That(ProductTotalPriceElement("text-right", expectedProduct.UnitPrice).Text, Is.EqualTo(expectedProduct.Total.ToString("C")), totalPriceMessage);
    }

    public void AssertProductInformationConfirmOrder(ProductDetails expectedProductInfo)
    {
        var nameMessage = $"{Constants.Constants.ErrorMessageProduct} \n Actual Result:{ConfirmOrderProductName("text-left", expectedProductInfo.Name).Text} \n Expected Result:{expectedProductInfo.Name}";
        Assert.That(ConfirmOrderProductName("text-left", expectedProductInfo.Name).Text, Is.EqualTo(expectedProductInfo.Name), nameMessage);

        var modelMessage = $"{Constants.Constants.ErrorMessageProduct} \n Actual Result:{ConfirmOrderInformation("text-left", expectedProductInfo.Model).Text} \n Expected Result:{expectedProductInfo.Model}";
        Assert.That(ConfirmOrderProductName("text-left", expectedProductInfo.Model).Text, Is.EqualTo(expectedProductInfo.Model), modelMessage);

        var quantityMessage = $"{Constants.Constants.ErrorMessageProduct} \n Actual Result:{ConfirmOrderQuantityElement(expectedProductInfo.Model).Text} \n Expected Result:{expectedProductInfo.Quantity}";
        Assert.That(ConfirmOrderQuantityElement(expectedProductInfo.Model).Text, Is.EqualTo(expectedProductInfo.Quantity), quantityMessage);

        var priceMessage = $"{Constants.Constants.ErrorMessageProduct} \n Actual Result:{ConfirmOrderPriceElement(expectedProductInfo.Quantity).Text} \n Expected Result:{expectedProductInfo.UnitPrice}";
        Assert.That(ConfirmOrderPriceElement(expectedProductInfo.Quantity).Text, Is.EqualTo(expectedProductInfo.UnitPrice), priceMessage);
    }

    private void AssertProductSubTotalPrice(params CheckoutInformation[] expectedProduct)
    {
        Driver.WaitForAjax();
        SearchButton.Hover();
        UpdateButton.WrappedElement.Click();
        Assert.That(expectedProduct.Select(x => x.SubTotal).ToList().Sum().ToString("C"), Is.EqualTo(SubTotal.Text));
    }

    private void AssertProductTotalPrice(params CheckoutInformation[] checkoutInformation)
    {
        Driver.WaitForAjax();
        var billingDetails = new BillingInformation();

        foreach (var product in checkoutInformation)
        {

            if (billingDetails.Country == "United Kingdom")
            {
                var totalMessage = $"Expected Result: {checkoutInformation.Sum(p => p.Total).ToString("C")} \n Actual Result: {Total.Text}";
                Assert.That(checkoutInformation.Sum(p => p.Total).ToString("C"), Is.EqualTo(Total.Text), totalMessage);
            }
            else
            {
                var totalMessage = $"Expected Result: {checkoutInformation.Sum(p => p.SubTotal) + checkoutInformation.Sum(p => p.FlatShippingRate).ToString("C")} \n Actual Result: {Total.Text}";
                Assert.That((checkoutInformation.Sum(p => p.SubTotal) + checkoutInformation.Sum(p => p.FlatShippingRate)).ToString("C"), Is.EqualTo(Total.Text), totalMessage);
            }

        }
    }

    private void AssertEcoTax(params CheckoutInformation[] products)
    {
        var billingDetails = CustomerFactory.GenerateBillingAddress();

        if (billingDetails.Country == "United Kingdom")
        {
            var ecoTaxMessage = $"Expected Result: {EcoTaxElement.Text} \n Actual Result: {products.Select(p => p.EcoTax).Sum().ToString("C")}";
            Assert.That(products.Select(p => p.EcoTax).Sum().ToString("C"), Is.EqualTo(EcoTaxElement.Text), ecoTaxMessage);
        }
        else
        {

            return;
        }
    }

    public void AssertCheckoutInformation(CheckoutInformation checkoutInformation)
    {
        AssertProductSubTotalPrice(checkoutInformation);
        AssertEcoTax(checkoutInformation);
        AssertProductTotalPrice(checkoutInformation);
    }
}