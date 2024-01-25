using System;
using System.Diagnostics.CodeAnalysis;

namespace StoringData
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("John",55);
            Person person2 = new Person("Nicki",25);
            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine($"Are person1 and person2 the same? {person1.Equals(person2)}");
            Child child = new Child("Tom", 12);
            Console.WriteLine(child);
            Console.WriteLine($"Comparison result: {person1.CompareTo(person2)}");
        }
    }
}