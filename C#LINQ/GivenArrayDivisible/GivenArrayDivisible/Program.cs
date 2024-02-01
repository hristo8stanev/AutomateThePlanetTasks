using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
       var numbers = new List<int>(){ 21, 42, 63, 14, 28, 35, 56, 77, 84, 91 };

        //LINQ Method Syntax
        var divisible = numbers.Where(num => num % 3 == 0 && num % 7 == 0);

        //LINQ Query Syntax
        // var divislbe = from number in numbers 
                          //where number % 7 && number % 3 == 0
                          //select number;

        foreach (var num in divisible)
        {
            Console.WriteLine(num);
        }
    }
}