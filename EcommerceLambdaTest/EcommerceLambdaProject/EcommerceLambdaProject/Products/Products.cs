namespace EcommerceLambdaProject.Products;

public static class Products
{
    public static void NikonProduct(ProductDetails productDetails)
    {
        productDetails.Name = "Nikon D300";
        productDetails.Brand = "Nikon";
        productDetails.Weight = "0.00kg";
        productDetails.Id = 31;
        productDetails.Availability = "In Stock";
        productDetails.UnitPrice = "$80.00";
        productDetails.Model = "Product 4";
        productDetails.Quantity = "4";

  
        double parsedQuantity;
        bool isQuantityParsed = double.TryParse(productDetails.Quantity, out parsedQuantity);
        double parsedUnitPrice;
        bool isUnitPriceParsed = double.TryParse(productDetails.UnitPrice.Replace("$", ""), out parsedUnitPrice);
        productDetails.Total = parsedQuantity * parsedUnitPrice;
    }

    public static void IPodProduct(ProductDetails productDetails)
    {
        productDetails.Name = "iPod Touch";
        productDetails.Brand = "Apple";
        productDetails.Weight = "5.00kg";
        productDetails.Id = 32;
        productDetails.Availability = "In Stock";
        productDetails.UnitPrice = "$160.00";
        productDetails.Model = "Product 5";
        productDetails.Quantity = "2";

        double parsedQuantity;
        bool isQuantityParsed = double.TryParse(productDetails.Quantity, out parsedQuantity);
        double parsedUnitPrice;
        bool isUnitPriceParsed = double.TryParse(productDetails.UnitPrice.Replace("$", ""), out parsedUnitPrice);
        productDetails.Total = parsedQuantity * parsedUnitPrice;
    }

    public static void SonyProduct(ProductDetails productDetails)
    {
        productDetails.Name = "Sony VAIO";
        productDetails.Brand = "Sony";
        productDetails.Weight = "0.00kg";
        productDetails.Id = 46;
        productDetails.Availability = "In Stock";
        productDetails.UnitPrice = "$1,000.00";
        productDetails.Model = "Product 19";
        productDetails.Quantity = "3";

        double parsedQuantity;
        bool isQuantityParsed = double.TryParse(productDetails.Quantity, out parsedQuantity);
        double parsedUnitPrice;
        bool isUnitPriceParsed = double.TryParse(productDetails.UnitPrice.Replace("$", ""), out parsedUnitPrice);
        productDetails.Total = parsedQuantity * parsedUnitPrice;
    }

    public static void AppleProduct(ProductDetails productDetails)
    {
        productDetails.Name = "Apple Cinema 30";
        productDetails.Brand = "Apple";
        productDetails.Weight = "0.00kg";
        productDetails.Id = 42;
        productDetails.Availability = "In Stock";
        productDetails.UnitPrice = "$76.00";
        productDetails.Model = "Product 15";
        productDetails.Quantity = "6";
        productDetails.Size = "Size: Medium";

        double parsedQuantity;
        bool isQuantityParsed = double.TryParse(productDetails.Quantity, out parsedQuantity);
        double parsedUnitPrice;
        bool isUnitPriceParsed = double.TryParse(productDetails.UnitPrice.Replace("$", ""), out parsedUnitPrice);
        productDetails.Total = parsedQuantity * parsedUnitPrice;
    }

    public static void IPodShuffleProduct(ProductDetails productDetails)
    {
        productDetails.Name = "iPod Shuffle";
        productDetails.Brand = "HTC";
        productDetails.Weight = "0.00kg";
        productDetails.Id = 34;
        productDetails.Availability = "In Stock";
        productDetails.UnitPrice = "$150.00";
        productDetails.Model = "Product 7";
        productDetails.Quantity = "5";

        double parsedQuantity;
        bool isQuantityParsed = double.TryParse(productDetails.Quantity, out parsedQuantity);
        double parsedUnitPrice;
        bool isUnitPriceParsed = double.TryParse(productDetails.UnitPrice.Replace("$", ""), out parsedUnitPrice);
        productDetails.Total = parsedQuantity * parsedUnitPrice;
       
    }

    public static void BoschProduct(ProductDetails productDetails)
    {
        productDetails.Name = "Bosch";
        productDetails.Brand = "Bosch";
        productDetails.Weight = "0.00kg";
        productDetails.Id = 929;
        productDetails.Availability = "In Stock";
        productDetails.UnitPrice = "$2983.00";
        productDetails.Model = "Product 151";
        productDetails.Quantity = "16";

        double parsedQuantity;
        bool isQuantityParsed = double.TryParse(productDetails.Quantity, out parsedQuantity);
        double parsedUnitPrice;
        bool isUnitPriceParsed = double.TryParse(productDetails.UnitPrice.Replace("$", ""), out parsedUnitPrice);
        productDetails.Total = parsedQuantity * parsedUnitPrice;
    }
}