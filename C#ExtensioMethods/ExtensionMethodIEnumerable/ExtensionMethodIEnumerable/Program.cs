using System;
using System.Collections;

namespace IEnumerableExtension;

public class Program
{
    static void Main(string[] args)
    {

        List<int> num = new List<int>() { 5, 10, 15, 20, 25 };

        Console.WriteLine($"Sum: {num.Min()}");
        Console.WriteLine($"Min: {num.Max()}");
        Console.WriteLine($"Max: {num.Sum()}");
        Console.WriteLine($"Average: {num.Average()}");

    }
}