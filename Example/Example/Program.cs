using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>() { 2, 3, 6, 13, 8, 10 };

            numbers.ForEach(numbers => Console.WriteLine(numbers));
        }
    }
}