namespace EcommerceLambdaProject.Pages.ProductPage;
public partial class ProductPages
{
    private const string ErrorMessagePrice = "The expected information are not correct";

    public void AssertTheProductDetailsIsCorrect(ProductDetails expectedProduct, int index)
    {
        var nameMessage = $"{ErrorMessagePrice} \n Actual Result:{GetCompareProduct("Product",index).Text} \n Expected Result:{expectedProduct.Name}";
        CollectionAssert.AreEqual(GetCompareProduct("Product", index).Text, expectedProduct.Name, nameMessage);

        var priceMessage = $"{ErrorMessagePrice} \n Actual Result:{GetCompareProduct("Price", index).Text} \n Expected Result:{expectedProduct.Price}";
        CollectionAssert.AreEqual(GetCompareProduct("Price", index).Text, expectedProduct.Price, priceMessage);

        var brandMessage = $"{ErrorMessagePrice} \n Actual Result:{GetCompareProduct("Brand", index).Text} \n Expected Result:{expectedProduct.Brand}";
        CollectionAssert.AreEqual(GetCompareProduct("Brand", index).Text, expectedProduct.Brand, brandMessage);

        var AvailabiltiyMessage = $"{ErrorMessagePrice} \n Actual Result:{GetCompareProduct("Availability", index).Text} \n Expected Result:{expectedProduct.Availability}";
        CollectionAssert.AreEqual(GetCompareProduct("Availability", index).Text, expectedProduct.Availability, AvailabiltiyMessage);

        var weightMessage = $"{ErrorMessagePrice} \n Actual Result:{GetCompareProduct("Weight", index).Text} \n Expected Result:{expectedProduct.Weight}";
        CollectionAssert.AreEqual(GetCompareProduct("Weight", index).Text, expectedProduct.Weight, weightMessage);
      
       var modelMessage = $"{ErrorMessagePrice} \n Actual Result:{GetCompareProduct("Model", index).Text} \n Expected Result:{expectedProduct.Model}";
       CollectionAssert.AreEqual(GetCompareProduct("Model", index).Text, expectedProduct.Model, modelMessage);
    }

   public void AssertProductIsAddedToWishlist(ProductDetails expectedProduct, int indexName, int indexModel, int indexStock, int unitPrice)
   {
        var message = $"{ErrorMessagePrice} \n Actual Result:{GetProduct("text-center",indexName).Text} \n Expected Result:{expectedProduct.Name}";
        CollectionAssert.AreEqual(GetProduct("text-center", indexName).Text, expectedProduct.Name, message);

        var modelMessage = $"{ErrorMessagePrice} \n Actual Result:{GetProduct("text-center", indexModel).Text} \n Expected Result:{expectedProduct.Model}";
        CollectionAssert.AreEqual(GetProduct("text-center", indexModel).Text, expectedProduct.Model, modelMessage);
     
        var stockMessage = $"{ErrorMessagePrice} \n Actual Result:{GetProduct("text-center", indexStock).Text} \n Expected Result:{expectedProduct.Availability}";
        CollectionAssert.AreEqual(GetProduct("text-center", indexStock).Text, expectedProduct.Availability, stockMessage);

        var priceMessage = $"{ErrorMessagePrice} \n Actual Result:{GetProduct("text-center", unitPrice).Text} \n Expected Result:{expectedProduct.Price}";
        CollectionAssert.AreEqual(GetProduct("text-center", unitPrice).Text, expectedProduct.Price, priceMessage);
    
        RemoveFromWishlist.Click();
   }
}
