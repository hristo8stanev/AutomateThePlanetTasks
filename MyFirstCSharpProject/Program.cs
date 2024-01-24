using System;

namespace OnlineStore;
class Program
{
    static void Main()
    {
        Welcome();
        PurchaseItems();
    }
    static void Welcome()
    {
        Console.WriteLine("Welcome to the store! Here are the items that you can buy: ");
        Console.WriteLine("Books");
        Console.WriteLine("Clothes");
        Console.WriteLine("Shoes");
        Console.WriteLine("Computers");
        Console.WriteLine("What would you like to buy? ");
    }
    static void PurchaseItems() 
    {
        var items = Console.ReadLine();
        switch (items)
        {
            case "Books":
                var book = new Books();
                book.Author = "Leo Tolstoy";
                book.Title = "War and Peace";
                book.Price = 9.19;
                Console.WriteLine($"You purchase a {book.Title} by {book.Author} for {book.Price}$ .");
                break;
            case "Clothes":
                var clothes = new Clothes();
                clothes.Colour = "Red";
                clothes.Title = "Nike Jordan";
                clothes.Size = "Medium-Size";
                clothes.Price = 39.99;
                Console.WriteLine($"You purchase a {clothes.Title} {clothes.Size} {clothes.Colour} colour for {clothes.Price}$ .");
                break;
            case "Shoes":
                var shoes = new Shoes();
                shoes.Colour = "Black";
                shoes.Numbers = 43;
                shoes.Title = "Sneakers";
                shoes.Price = 99.99;
                Console.WriteLine($"You purchase a {shoes.Colour} {shoes.Title} {shoes.Numbers} for {shoes.Price}$ .");
                break;
            case "Computers":
                var computer = new Computers();
                computer.Colour = "White";
                computer.Type = "Laptop";
                computer.Title = "MacBook Air";
                computer.Price = 2999.99;
                Console.WriteLine($"You purchase a {computer.Colour} {computer.Title} {computer.Type} for {computer.Price}$ .");
                break;
            default:
                break;

        }
    }

    class BaseItem
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Colour { get; set; }
    }


    class Books : BaseItem 
    {

        public string Author { get; set; }
    }

    class Clothes : BaseItem 
    {
        public string Size { get; set; }
    }

    class Shoes : BaseItem
    {
        public int Numbers { get; set; }

    }
    class Computers : BaseItem
    {
        public string Type { get; set; }
    }
}