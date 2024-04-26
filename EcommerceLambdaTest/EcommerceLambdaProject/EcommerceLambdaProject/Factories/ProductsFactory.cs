﻿namespace EcommerceLambdaProject.Factories;

public static class ProductsFactory
{

    public static ProductDetails GenerateProduct(string name = null, int id = 0, string price = null, string model = null, string brand = null, string weight = null, string Availability = null, string size = null, string quantity = null)
    {
        var productDetails = new ProductDetails();

        productDetails.Name = name;
        productDetails.Brand = brand;
        productDetails.Weight = weight;
        productDetails.Id = id;
        productDetails.Availability = Availability;
        productDetails.UnitPrice = price;
        productDetails.Model = model;
        productDetails.Size = size;
        productDetails.Quantity = quantity;

        return productDetails;
    }



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
        var parsedQuantity = ParseQuantity(productDetails);
        var parsedUnitPrice = ParseUnitPrice(productDetails);
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
        var parsedQuantity = ParseQuantity(productDetails);
        var parsedUnitPrice = ParseUnitPrice(productDetails);
        productDetails.Total = parsedQuantity * parsedUnitPrice;
    }

    public static void iPodNano(ProductDetails productDetails)
    {
        productDetails.Name = "iPod Nano";
        productDetails.Brand = "Apple";
        productDetails.Weight = "0.00kg";
        productDetails.Id = 36;
        productDetails.Availability = "In Stock";
        productDetails.UnitPrice = "$100.00";
        productDetails.Model = "Product 9";
        productDetails.Quantity = "3";
        double parsedQuantity = ParseQuantity(productDetails);
        double parsedUnitPrice = ParseUnitPrice(productDetails);
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
        var parsedQuantity = ParseQuantity(productDetails);
        var parsedUnitPrice = ParseUnitPrice(productDetails);
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
        var parsedQuantity = ParseQuantity(productDetails);
        var parsedUnitPrice = ParseUnitPrice(productDetails);
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
        var parsedQuantity = ParseQuantity(productDetails);
        var parsedUnitPrice = ParseUnitPrice(productDetails);
        productDetails.Total = parsedQuantity * parsedUnitPrice;
    }

    private static double ParseUnitPrice(ProductDetails productDetails)
    {
        double parsedUnitPrice;
        bool isUnitPriceParsed = double.TryParse(productDetails.UnitPrice.Replace("$", ""), out parsedUnitPrice);
        return parsedUnitPrice;
    }

    private static double ParseQuantity(ProductDetails productDetails)
    {
        double parsedQuantity;
        bool isQuantityParsed = double.TryParse(productDetails.Quantity, out parsedQuantity);
        return parsedQuantity;
    }
}