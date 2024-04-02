
using System;

namespace EcommerceLambdaProject.Pages.ProductPage;
public partial class ProductPages
{
    private const string ErrorMessage = "The expected information are not correct";

    public void AssertTheProductNameCorrect(ProductDetails expectedProduct, int index)
    {
       var nameMessage = $"{ErrorMessage} \n Actual Result:{ProductNameElement(index, expectedProduct.Name).Text} \n Expected Result:{expectedProduct.Name}";
       CollectionAssert.AreEqual(ProductNameElement(index, expectedProduct.Name).Text, expectedProduct.Name, nameMessage);
    }

    public void AssertTheProductIsAddedToComparePage(ProductDetails expectedProduct, int index)
    {
        var nameMessage = $"{ErrorMessage} \n Actual Result:{ProductNameElement(index, expectedProduct.Name).Text} \n Expected Result:{expectedProduct.Name}";
        CollectionAssert.AreEqual(ProductNameElement(index, expectedProduct.Name).Text, expectedProduct.Name, nameMessage);

        var messagePrice = $"{ErrorMessage} \n Actual Result:{ProductElementInformation(expectedProduct.UnitPrice).Text} \n Expected Result:{expectedProduct.UnitPrice}";
      CollectionAssert.AreEqual(ProductElementInformation(expectedProduct.UnitPrice).Text, expectedProduct.UnitPrice, messagePrice);
     
      var brandMessage = $"{ErrorMessage} \n Actual Result:{ProductElementInformation(expectedProduct.Brand).Text} \n Expected Result:{expectedProduct.Brand}";
      CollectionAssert.AreEqual(ProductElementInformation(expectedProduct.Brand).Text, expectedProduct.Brand, brandMessage);
      
      var AvailabiltiyMessage = $"{ErrorMessage} \n Actual Result:{ProductElementInformation(expectedProduct.Availability).Text} \n Expected Result:{expectedProduct.Availability}";
      CollectionAssert.AreEqual(ProductElementInformation(expectedProduct.Availability).Text, expectedProduct.Availability, AvailabiltiyMessage);
       
      var modelMessage = $"{ErrorMessage} \n Actual Result:{ProductElementInformation(expectedProduct.Model).Text} \n Expected Result:{expectedProduct.Model}";
      CollectionAssert.AreEqual(ProductElementInformation(expectedProduct.Model).Text, expectedProduct.Model, modelMessage);

      var weightMessage = $"{ErrorMessage} \n Actual Result:{ProductWeightElement(expectedProduct.Weight).Text} \n Expected Result:{expectedProduct.Weight}";
      CollectionAssert.AreEqual(ProductWeightElement(expectedProduct.Weight).Text, expectedProduct.Weight, weightMessage);

        RemoveFromComparelist(expectedProduct.Id).Click();
    }


   public void AssertProductIsAddedToWishlist(ProductDetails expectedProduct, int index)
   {
        var nameMessage = $"{ErrorMessage} \n Actual Result:{ProductNameElement(index, expectedProduct.Name).Text} \n Expected Result:{expectedProduct.Name}";
        CollectionAssert.AreEqual(ProductNameElement(index, expectedProduct.Name).Text, expectedProduct.Name, nameMessage);

        var modelMessage = $"{ErrorMessage} \n Actual Result:{ProductElementInformation(expectedProduct.Model).Text} \n Expected Result:{expectedProduct.Model}";
        CollectionAssert.AreEqual(ProductElementInformation(expectedProduct.Model).Text, expectedProduct.Model, modelMessage);

        var messageAvailability = $"{ErrorMessage} \n Actual Result:{ProductElementInformation(expectedProduct.Availability).Text} \n Expected Result:{expectedProduct.Availability}";
        CollectionAssert.AreEqual(ProductElementInformation(expectedProduct.Availability).Text, expectedProduct.Availability, messageAvailability);

        var messagePrice = $"{ErrorMessage} \n Actual Result:{ProductPriceWishlistElement(expectedProduct.UnitPrice).Text} \n Expected Result:{expectedProduct.UnitPrice}";
        CollectionAssert.AreEqual(ProductPriceWishlistElement(expectedProduct.UnitPrice).Text, expectedProduct.UnitPrice, messagePrice);
        
        RemoveFromWishlist.Click();
    }

    public void AssertSizeOftheProductIsCorrect(ProductDetails expectedProduct, int index)
    {
        var nameMessage = $"{ErrorMessage} \n Actual Result:{ProductSize(index).Text} \n Expected Result:{expectedProduct.Size}";
        CollectionAssert.AreEqual(ProductSize(index).Text, expectedProduct.Size, nameMessage);

        RemoveButton.Click();
    }
}
