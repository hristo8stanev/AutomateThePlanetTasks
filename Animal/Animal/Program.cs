using System;
using Animal;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dog dog = new Dog("Bucky",10, "Male");
            Console.WriteLine(dog);
        }
    }
}