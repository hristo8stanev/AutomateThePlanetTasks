using EcommerceLambdaProject.Pages.BasePage;

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

    public void AssertProductSubTotalPrice(params ProductDetails[] expectedProduct)
    {
        UpdateButton.WrappedElement.Click();
        var expectedSubTotal = expectedProduct.Select(x => x.Total).ToList().Sum();
        Assert.That(expectedSubTotal.ToString("C"), Is.EqualTo(SubTotal.Text));
    }

    public void AssertProductTotalPrice(params ProductDetails[] products)
    {

        var subTotalSum = products.Sum(p => p.Total);
        var flatShippingRate = 5.00;

        foreach (var product in products)
        {

            if (product.VatTax == true)
            {
                CalculateTax(products);
            }
            else
            {
                var expectedTotal = subTotalSum + flatShippingRate;
                var totalMessage = $"Expected Result: {expectedTotal.ToString("C")} \n Actual Result: {Total.Text}";
                Assert.That(expectedTotal.ToString("C"), Is.EqualTo(Total.Text));
            }

        }
    }


    public void CalculateTax(params ProductDetails[] products)
    {
        UpdateButton.WrappedElement.Click();
        var subTotalSum = products.Sum(p => p.Total);
        int totalQuantity = 0;

        foreach (var product in products)
        {
            int.TryParse(product.Quantity, out int quantity);
            totalQuantity += quantity;
        }

        var flatShippingRate = 5.00;
        var ecoTax = 4.00;
        int remainingQuantity = totalQuantity - 1;

        while (remainingQuantity > 0)
        {
            ecoTax += 2.00;
            remainingQuantity--;
        }

        var vat = Math.Ceiling(0.20 * subTotalSum + 1);
        var expectedTotal = subTotalSum + flatShippingRate + ecoTax + vat;

        var totalMessage = $"Expected Result: {expectedTotal.ToString("C")} \n Actual Result: {Total.Text}";
        Assert.That(expectedTotal.ToString("C"), Is.EqualTo(Total.Text));

    }
}