using System;
using _02.Book_Shop;

namespace Books;
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Aster Alex", "Thief", 13.99);
            Console.WriteLine(book);
            GoldenEditionBook goldenBook = new GoldenEditionBook("Stephen King","Fairy Tale",49.99);
            Console.WriteLine(goldenBook);
        }
    }