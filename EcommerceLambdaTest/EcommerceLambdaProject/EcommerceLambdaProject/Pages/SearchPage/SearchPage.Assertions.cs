namespace EcommerceLambdaProject.Pages;

public partial class SearchPage
{
    public void AssertTheProductNameAndPrice(ProductDetails expectedProduct)
    {
        var nameMessage = $"{ErrorMessage} \n Actual Result:{GetProductName(expectedProduct.Id, expectedProduct.Name).Text} \n Expected Result:{expectedProduct.Name}";
        Assert.That(GetProductName(expectedProduct.Id, expectedProduct.Name).Text, Is.EqualTo(expectedProduct.Name), nameMessage);

        var priceMessage = $"{ErrorMessage} \n Actual Result:{GetProductPrice.Text} \n Expected Result:{expectedProduct.UnitPrice}";
        Assert.That(GetProductPrice.Text, Is.EqualTo(expectedProduct.UnitPrice), priceMessage);
    }

    public void AssertErrorMessageWhenNonExistingProductIsSearched()
    {
        var errorMessageNonExistingProduct = $"{ErrorMessage} \n Actual Result:{ErrorMessageNonExistingProduct(ExpectedMessageNonExistingProduct).Text} \n Expected Result:{ExpectedMessageNonExistingProduct}";
        Assert.That(ErrorMessageNonExistingProduct(ExpectedMessageNonExistingProduct).Text, Is.EqualTo(ExpectedMessageNonExistingProduct), errorMessageNonExistingProduct);
    }
}