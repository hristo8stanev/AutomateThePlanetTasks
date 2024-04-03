namespace EcommerceLambdaProject.Pages;

public partial class ProductPage
{
    public void AssertTheProductNameCorrect(ProductDetails expectedProduct, int productId)
    {
        var nameMessage = $"{Constants.Constants.ErrorMessage} \n Actual Result:{ProductNameElement(productId, expectedProduct.Name).Text} \n Expected Result:{expectedProduct.Name}";
        Assert.That(ProductNameElement(productId, expectedProduct.Name).Text, Is.EqualTo(expectedProduct.Name), nameMessage);
    }

    public void AssertTheProductIsAddedToComparePage(ProductDetails expectedProduct, int productId)
    {
        var nameMessage = $"{Constants.Constants.ErrorMessage} \n Actual Result:{ProductNameElement(productId, expectedProduct.Name).Text} \n Expected Result:{expectedProduct.Name}";
        Assert.That(ProductNameElement(productId, expectedProduct.Name).Text, Is.EqualTo(expectedProduct.Name), nameMessage);

        var messagePrice = $"{Constants.Constants.ErrorMessage} \n Actual Result:{ProductElementInformation(expectedProduct.UnitPrice).Text} \n Expected Result:{expectedProduct.UnitPrice}";
        Assert.That(ProductElementInformation(expectedProduct.UnitPrice).Text, Is.EqualTo(expectedProduct.UnitPrice), messagePrice);

        var brandMessage = $"{Constants.Constants.ErrorMessage} \n Actual Result:{ProductElementInformation(expectedProduct.Brand).Text} \n Expected Result:{expectedProduct.Brand}";
        Assert.That(ProductElementInformation(expectedProduct.Brand).Text, Is.EqualTo(expectedProduct.Brand), brandMessage);

        var AvailabiltiyMessage = $"{Constants.Constants.ErrorMessage} \n Actual Result:{ProductElementInformation(expectedProduct.Availability).Text} \n Expected Result:{expectedProduct.Availability}";
        Assert.That(ProductElementInformation(expectedProduct.Availability).Text, Is.EqualTo(expectedProduct.Availability), AvailabiltiyMessage);

        var modelMessage = $"{Constants.Constants.ErrorMessage} \n Actual Result:{ProductElementInformation(expectedProduct.Model).Text} \n Expected Result:{expectedProduct.Model}";
        Assert.That(ProductElementInformation(expectedProduct.Model).Text, Is.EqualTo(expectedProduct.Model), modelMessage);

        var weightMessage = $"{Constants.Constants.ErrorMessage} \n Actual Result:{ProductWeightElement(expectedProduct.Weight).Text} \n Expected Result:{expectedProduct.Weight}";
        Assert.That(ProductWeightElement(expectedProduct.Weight).Text, Is.EqualTo(expectedProduct.Weight), weightMessage);
        RemoveFromComparelist(expectedProduct.Id).Click();
    }

    public void AssertProductIsAddedToWishlist(ProductDetails expectedProduct, int productId)
    {
        var nameMessage = $"{Constants.Constants.ErrorMessage} \n Actual Result:{ProductNameElement(productId, expectedProduct.Name).Text} \n Expected Result:{expectedProduct.Name}";
        Assert.That(ProductNameElement(productId, expectedProduct.Name).Text, Is.EqualTo(expectedProduct.Name), nameMessage);

        var modelMessage = $"{Constants.Constants.ErrorMessage} \n Actual Result:{ProductElementInformation(expectedProduct.Model).Text} \n Expected Result:{expectedProduct.Model}";
        Assert.That(ProductElementInformation(expectedProduct.Model).Text, Is.EqualTo(expectedProduct.Model), modelMessage);

        var messageAvailability = $"{Constants.Constants.ErrorMessage} \n Actual Result:{ProductElementInformation(expectedProduct.Availability).Text} \n Expected Result:{expectedProduct.Availability}";
        Assert.That(ProductElementInformation(expectedProduct.Availability).Text, Is.EqualTo(expectedProduct.Availability), messageAvailability);

        var messagePrice = $"{Constants.Constants.ErrorMessage} \n Actual Result:{ProductPriceWishlistElement(expectedProduct.UnitPrice).Text} \n Expected Result:{expectedProduct.UnitPrice}";
        Assert.That(ProductPriceWishlistElement(expectedProduct.UnitPrice).Text, Is.EqualTo(expectedProduct.UnitPrice), messagePrice);
        RemoveFromWishlist.Click();
    }

    public void AssertSizeProductIsCorrect(ProductDetails expectedProduct, int productId)
    {
        var nameMessage = $"{Constants.Constants.ErrorMessage} \n Actual Result:{ProductSize(productId).Text} \n Expected Result:{expectedProduct.Size}";
        Assert.That(ProductSize(productId).Text, Is.EqualTo(expectedProduct.Size), nameMessage);
        RemoveButton.Click();
    }
}