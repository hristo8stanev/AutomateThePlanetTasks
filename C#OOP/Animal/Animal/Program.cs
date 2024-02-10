using System;
using Animal;

namespace Program;
    public class Program
    {
        public static void Main(string[] args)
        {
        var animal = new Animals("Lion", 5, Animals.Genders.Female);

        Dog dog = new Dog("Bucky", 10, Animals.Genders.Male);
            Console.WriteLine(dog);
        Kitten kitten = new Kitten("Jerry", 12, Animals.Genders.Female);
            Console.WriteLine(kitten);
        Tomcat tomcat = new Tomcat("Tom", 9, Animals.Genders.Male);
            Console.WriteLine(tomcat);
    }
}