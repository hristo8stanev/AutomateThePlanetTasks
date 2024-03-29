using EcommerceLambdaProject.Pages.ProductPage;

namespace EcommerceLambdaProject.Pages.SearchPage;
public partial class SearchPages
{
    private string ErrorMessage => "The expected information are not correct";
    private string ExpectedMessageNonExistingProduct => "There is no product that matches the search criteria.";

    public void AssertTheProductNameAndPriceIsCorrect(ProductDetails expectedProduct, int index)
    {
        var nameMessage = $"{ErrorMessage} \n Actual Result:{GetProductName(index, expectedProduct.Name).Text} \n Expected Result:{expectedProduct.Name}";
        CollectionAssert.AreEqual(GetProductName(index, expectedProduct.Name).Text, expectedProduct.Name, nameMessage);

        var priceMessage = $"{ErrorMessage} \n Actual Result:{GetProductPrice.Text} \n Expected Result:{expectedProduct.UnitPrice}";
        CollectionAssert.AreEqual(GetProductPrice.Text, expectedProduct.UnitPrice, priceMessage);
    }

    public void AssertErrorMessageWhenNonExistingProductIsSearched()
    {

        var errorMessageNonExistingProduct = $"{ErrorMessage} \n Actual Result:{ErrorMessageNonExistingProduct(ExpectedMessageNonExistingProduct).Text} \n Expected Result:{ExpectedMessageNonExistingProduct}";
        CollectionAssert.AreEqual(ErrorMessageNonExistingProduct(ExpectedMessageNonExistingProduct).Text, ExpectedMessageNonExistingProduct, errorMessageNonExistingProduct);

    }

    public void AssertFirstElementIsVisible()
    {

        var message = $"{ErrorMessage} \n Actual Result:{!FirstProduct.Displayed} \n Expected Result:{FirstProduct.Displayed}";
        Assert.That((bool)FirstProduct.Displayed, ErrorMessage, message);

        Driver.WaitForAjax();
    }
    public void AssertDesktopIsVisible()
    {


        Driver.WaitForAjax();
        Desktop.Hover();
    }
}