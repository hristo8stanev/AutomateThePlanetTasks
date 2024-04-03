namespace EcommerceLambdaProject.Pages;

public partial class SearchPage
{
    public void AssertTheProductNameAndPriceIsCorrect(ProductDetails expectedProduct, int productId)
    {
        var nameMessage = $"{Constants.Constants.ErrorMessage} \n Actual Result:{GetProductName(productId, expectedProduct.Name).Text} \n Expected Result:{expectedProduct.Name}";
        Assert.That(GetProductName(productId, expectedProduct.Name).Text, Is.EqualTo(expectedProduct.Name), nameMessage);

        var priceMessage = $"{Constants.Constants.ErrorMessage} \n Actual Result:{GetProductPrice.Text} \n Expected Result:{expectedProduct.UnitPrice}";
        Assert.That(GetProductPrice.Text, Is.EqualTo(expectedProduct.UnitPrice), priceMessage);
    }

    public void AssertErrorMessageWhenNonExistingProductIsSearched()
    {
        var errorMessageNonExistingProduct = $"{Constants.Constants.ErrorMessage} \n Actual Result:{ErrorMessageNonExistingProduct(Constants.Constants.ExpectedMessageNonExistingProduct).Text} \n Expected Result:{Constants.Constants.ExpectedMessageNonExistingProduct}";
        Assert.That(ErrorMessageNonExistingProduct(Constants.Constants.ExpectedMessageNonExistingProduct).Text, Is.EqualTo(Constants.Constants.ExpectedMessageNonExistingProduct), errorMessageNonExistingProduct);
    }
}