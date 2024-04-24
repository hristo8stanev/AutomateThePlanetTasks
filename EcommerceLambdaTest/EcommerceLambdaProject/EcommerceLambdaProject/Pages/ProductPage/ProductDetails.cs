﻿namespace EcommerceLambdaProject.Pages;

public class ProductDetails
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string CheckoutPrice { get; set; }
    public string UnitPrice { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public string Availability { get; set; }
    public string Weight { get; set; }
    public string Quantity { get; set; }
    public string Size { get; set; }
    public double FlatShippingRate { get; set; }
    public double EcoTax { get; set; }

    public bool VatTax = true;
    public double Total { get; set; }
}