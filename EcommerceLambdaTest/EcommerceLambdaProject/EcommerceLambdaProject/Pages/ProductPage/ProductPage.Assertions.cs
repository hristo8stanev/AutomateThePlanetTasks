namespace EcommerceLambdaProject.Pages.ProductPage;
public partial class ProductPages
{

    public void AssertTheProductNameIsCorrect(ProductDetails expectedProduct)
    {
        var message = $"{"Ss"} \n Actual Result:{GetCompareProduct("Product").Text} \n Expected Result:{expectedProduct.Price}";
        CollectionAssert.AreEqual(GetCompareProduct("Product").Text, expectedProduct.Price, message);
    }
}
