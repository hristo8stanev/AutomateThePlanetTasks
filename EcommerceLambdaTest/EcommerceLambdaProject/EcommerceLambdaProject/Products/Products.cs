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
        productDetails.FlatShippingRate = 5.00;
        productDetails.EcoTax = 4.00;


        double parsedQuantity;
        bool isQuantityParsed = double.TryParse(productDetails.Quantity, out parsedQuantity);
        double parsedUnitPrice;
        bool isUnitPriceParsed = double.TryParse(productDetails.UnitPrice.Replace("$", ""), out parsedUnitPrice);
        productDetails.Total = parsedQuantity * parsedUnitPrice;
    }

    public static void SamsungSyncMaster(ProductDetails productDetails)
    {
        productDetails.Name = "Samsung SyncMaster 941BW";
        productDetails.Brand = "Canon";
        productDetails.Weight = "5.00kg";
        productDetails.Id = 33;
        productDetails.Availability = "In Stock";
        productDetails.UnitPrice = "$200.00";
        productDetails.Model = "Product 6";
        productDetails.Quantity = "2";
        productDetails.FlatShippingRate = 5.00;
        productDetails.EcoTax = 4.00;

        double parsedQuantity;
        bool isQuantityParsed = double.TryParse(productDetails.Quantity, out parsedQuantity);
        double parsedUnitPrice;
        bool isUnitPriceParsed = double.TryParse(productDetails.UnitPrice.Replace("$", ""), out parsedUnitPrice);
        productDetails.Total = parsedQuantity * parsedUnitPrice;
    }

    public static void iPodNano(ProductDetails productDetails)
    {
        productDetails.Name = "iPod Nano";
        productDetails.Brand = "Apple";
        productDetails.Weight = "0.00kg";
        productDetails.Id = 36;
        productDetails.Availability = "In Stock";
        productDetails.UnitPrice = "$122.00";
        productDetails.Model = "Product 9";
        productDetails.Quantity = "3";
        productDetails.FlatShippingRate = 5.00;
        productDetails.EcoTax = 4.00;

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
        productDetails.FlatShippingRate = 5.00;
        productDetails.EcoTax = 4.00;

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
        productDetails.UnitPrice = "$182.00";
        productDetails.Model = "Product 7";
        productDetails.Quantity = "5";
        productDetails.FlatShippingRate = 5.00;
        productDetails.EcoTax = 4.00;

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
        productDetails.FlatShippingRate = 5.00;
        productDetails.EcoTax = 4.00;

        double parsedQuantity;
        bool isQuantityParsed = double.TryParse(productDetails.Quantity, out parsedQuantity);
        double parsedUnitPrice;
        bool isUnitPriceParsed = double.TryParse(productDetails.UnitPrice.Replace("$", ""), out parsedUnitPrice);
        productDetails.Total = parsedQuantity * parsedUnitPrice;
    }
}