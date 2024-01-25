using System;
using Animal;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dog dog = new Dog("Bucky", 10, "Male");
            Console.WriteLine(dog);
            Kitten kitten = new Kitten("Jerry" ,12, "Female");
            Console.WriteLine(kitten);
            Tomcat tomcat = new Tomcat("Tom", 9, "Male");
            Console.WriteLine(tomcat);
        }
    }
}