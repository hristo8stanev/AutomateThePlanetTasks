﻿namespace EcommerceLambdaProject.Pages.ShoppingCartPage;
public partial class ShoppingCartPages
{
    
    public IComponent UpdateQuantityButton => Driver.FindComponent(By.XPath("//*[@class='table table-bordered']//td[@class='text-left']//div//button[1]"));
    public IComponent UpdateQuantityTextField => Driver.FindComponent(By.XPath("//*[contains(@type, 'text') and contains(@name, 'quantity')]"));
    public IComponent RemoveButton => Driver.FindComponent(By.XPath("//button[contains(@onclick, 'cart.remove')]"));
    public IComponent ProductNameElement(int id, string productName) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[.//a[contains(@href, 'product_id={id}') and normalize-space()='{productName}']]"));
    public IComponent ProductPriceElement(string price) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[@class='text-right' and contains(text(), '{price}')]"));
    public IComponent ProductElementInformation(string cell, int index) => Driver.FindComponent(By.XPath($"//*//tbody//tr//td[@class='{cell}']//following-sibling::td[{index}]"));
    public IComponent ProductQuantityInformation(string cell) => Driver.FindComponent(By.XPath($"//div[@id='content']//td[.//input[@class='{cell}']]//following-sibling::input"));
    public IComponent RemovedProduct(string value) => Driver.FindComponent(By.XPath($"//div[@id='content']//p[contains(text(), '{value}')]"));

}
