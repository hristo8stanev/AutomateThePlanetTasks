using System;
using System.Collections;
using System.Diagnostics.Metrics;

namespace GenericClassAndMethods;
class Program
{
    static void Main(string[] args)
    {
         List<double> numbers = new List<double>()
         { 10.4, 3, 4, 30.2, -10, 34, 2, 3, 3, 10.4, -10, 5, 5, -10, 6, 7, 7, 34, 4};

        Dictionary<double, int> occurancies = CountOccurencies(numbers);

        foreach (var num in occurancies)
        {

            Console.WriteLine($"{num.Key} -> {num.Value} times ");
        }

    }

   static Dictionary<double, int> CountOccurencies(List<double> numbers)
   {
        Dictionary<double, int> occurrances = new Dictionary<double, int>();

        foreach (var  number in numbers)
        {

            if (occurrances.ContainsKey(number))
            {
                occurrances[number]++;
            }
            else
            {
                occurrances.Add(number, 1);
            }
            
        }
        return occurrances;
   }
}   