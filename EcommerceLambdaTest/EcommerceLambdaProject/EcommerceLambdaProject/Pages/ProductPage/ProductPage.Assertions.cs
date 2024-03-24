namespace EcommerceLambdaProject.Pages.ProductPage;
public partial class ProductPages
{
    private const string ErrorMessagePrice = "The expected and actual result are not equal";

    public void AssertTheProductNameIsCorrect(ProductDetails expectedProduct)
    {
        var message = $"{ErrorMessagePrice} \n Actual Result:{GetCompareProduct("Product").Text} \n Expected Result:{expectedProduct.Name}";
        CollectionAssert.AreEqual(GetCompareProduct("Product").Text, expectedProduct.Name, message);
    }


    public void AssertProductIsAddedToWishlist(ProductDetails expectedProduct)
    {
         var message = $"{ErrorMessagePrice} \n Actual Result:{GetProduct("text-center").Text} \n Expected Result:{expectedProduct.Name}";
         CollectionAssert.AreEqual(GetProduct("text-center").Text, expectedProduct.Name, message);

         RemoveFromWishlist.Click();
    }
}
