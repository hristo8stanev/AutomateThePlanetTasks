namespace EcommerceLambdaProject.Pages;

public partial class SearchPage
{
    private string ErrorMessage => "The expected information are not correct";
    private string ExpectedMessageNonExistingProduct => "There is no product that matches the search criteria.";

    public void AssertTheProductNameAndPriceIsCorrect(ProductDetails expectedProduct, int productId)
    {
        var nameMessage = $"{ErrorMessage} \n Actual Result:{GetProductName(productId, expectedProduct.Name).Text} \n Expected Result:{expectedProduct.Name}";
        Assert.That(GetProductName(productId, expectedProduct.Name).Text, Is.EqualTo(expectedProduct.Name), nameMessage);

        var priceMessage = $"{ErrorMessage} \n Actual Result:{GetProductPrice.Text} \n Expected Result:{expectedProduct.UnitPrice}";
        Assert.That(GetProductPrice.Text, Is.EqualTo(expectedProduct.UnitPrice), priceMessage);
    }

    public void AssertErrorMessageWhenNonExistingProductIsSearched()
    {
        var errorMessageNonExistingProduct = $"{ErrorMessage} \n Actual Result:{ErrorMessageNonExistingProduct(ExpectedMessageNonExistingProduct).Text} \n Expected Result:{ExpectedMessageNonExistingProduct}";
        Assert.That(ErrorMessageNonExistingProduct(ExpectedMessageNonExistingProduct).Text, Is.EqualTo(ExpectedMessageNonExistingProduct), errorMessageNonExistingProduct);
    }
}