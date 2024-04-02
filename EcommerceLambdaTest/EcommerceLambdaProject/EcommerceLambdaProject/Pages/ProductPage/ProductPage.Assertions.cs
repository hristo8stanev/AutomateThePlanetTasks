namespace EcommerceLambdaProject.Pages;

public partial class ProductPage
{
    private const string ErrorMessage = "The expected information are not correct";

    public void AssertTheProductNameCorrect(ProductDetails expectedProduct, int productId)
    {
        var nameMessage = $"{ErrorMessage} \n Actual Result:{ProductNameElement(productId, expectedProduct.Name).Text} \n Expected Result:{expectedProduct.Name}";
        Assert.That(ProductNameElement(productId, expectedProduct.Name).Text, Is.EqualTo(expectedProduct.Name), nameMessage);
    }

    public void AssertTheProductIsAddedToComparePage(ProductDetails expectedProduct, int productId)
    {
        var nameMessage = $"{ErrorMessage} \n Actual Result:{ProductNameElement(productId, expectedProduct.Name).Text} \n Expected Result:{expectedProduct.Name}";
        Assert.That(ProductNameElement(productId, expectedProduct.Name).Text, Is.EqualTo(expectedProduct.Name), nameMessage);

        var messagePrice = $"{ErrorMessage} \n Actual Result:{ProductElementInformation(expectedProduct.UnitPrice).Text} \n Expected Result:{expectedProduct.UnitPrice}";
        Assert.That(ProductElementInformation(expectedProduct.UnitPrice).Text, Is.EqualTo(expectedProduct.UnitPrice), messagePrice);

        var brandMessage = $"{ErrorMessage} \n Actual Result:{ProductElementInformation(expectedProduct.Brand).Text} \n Expected Result:{expectedProduct.Brand}";
        Assert.That(ProductElementInformation(expectedProduct.Brand).Text, Is.EqualTo(expectedProduct.Brand), brandMessage);

        var AvailabiltiyMessage = $"{ErrorMessage} \n Actual Result:{ProductElementInformation(expectedProduct.Availability).Text} \n Expected Result:{expectedProduct.Availability}";
        Assert.That(ProductElementInformation(expectedProduct.Availability).Text, Is.EqualTo(expectedProduct.Availability), AvailabiltiyMessage);

        var modelMessage = $"{ErrorMessage} \n Actual Result:{ProductElementInformation(expectedProduct.Model).Text} \n Expected Result:{expectedProduct.Model}";
        Assert.That(ProductElementInformation(expectedProduct.Model).Text, Is.EqualTo(expectedProduct.Model), modelMessage);

        var weightMessage = $"{ErrorMessage} \n Actual Result:{ProductWeightElement(expectedProduct.Weight).Text} \n Expected Result:{expectedProduct.Weight}";
        Assert.That(ProductWeightElement(expectedProduct.Weight).Text, Is.EqualTo(expectedProduct.Weight), weightMessage);
        RemoveFromComparelist(expectedProduct.Id).Click();
    }

    public void AssertProductIsAddedToWishlist(ProductDetails expectedProduct, int index)
    {
        var nameMessage = $"{ErrorMessage} \n Actual Result:{ProductNameElement(index, expectedProduct.Name).Text} \n Expected Result:{expectedProduct.Name}";
        Assert.That(ProductNameElement(index, expectedProduct.Name).Text, Is.EqualTo(expectedProduct.Name), nameMessage);

        var modelMessage = $"{ErrorMessage} \n Actual Result:{ProductElementInformation(expectedProduct.Model).Text} \n Expected Result:{expectedProduct.Model}";
        Assert.That(ProductElementInformation(expectedProduct.Model).Text, Is.EqualTo(expectedProduct.Model), modelMessage);

        var messageAvailability = $"{ErrorMessage} \n Actual Result:{ProductElementInformation(expectedProduct.Availability).Text} \n Expected Result:{expectedProduct.Availability}";
        Assert.That(ProductElementInformation(expectedProduct.Availability).Text, Is.EqualTo(expectedProduct.Availability), messageAvailability);

        var messagePrice = $"{ErrorMessage} \n Actual Result:{ProductPriceWishlistElement(expectedProduct.UnitPrice).Text} \n Expected Result:{expectedProduct.UnitPrice}";
        Assert.That(ProductPriceWishlistElement(expectedProduct.UnitPrice).Text, Is.EqualTo(expectedProduct.UnitPrice), messagePrice);
        RemoveFromWishlist.Click();
    }

    public void AssertSizeOftheProductIsCorrect(ProductDetails expectedProduct, int index)
    {
        var nameMessage = $"{ErrorMessage} \n Actual Result:{ProductSize(index).Text} \n Expected Result:{expectedProduct.Size}";
        Assert.That(ProductSize(index).Text, Is.EqualTo(expectedProduct.Size), nameMessage);
        RemoveButton.Click();
    }
}