using System;

class Worker
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }

    public static List<Worker> GetWorkers()
    {
        List<Worker> listWorkers = new List<Worker>
        {
                    new Worker() { FirstName = "George", LastName = "John", FullName = "George John", Age = 18 },
                    new Worker() { FirstName = "Tah", LastName = "Michael",FullName = "Tah Michael", Age = 54 },
                    new Worker() { FirstName = "Paul", LastName = "Eddie",FullName = "Paul Eddie", Age = 33 },
                    new Worker() { FirstName = "Peter", LastName = "Tah",FullName = "Peter Tah", Age = 14 },
                    new Worker() { FirstName = "Paul", LastName = "Joao",FullName = "Paul Joao", Age = 8 },
                    new Worker() { FirstName = "Eddie", LastName = "Peter",FullName = "Eddie Peter", Age = 12 },
                    new Worker() { FirstName = "John", LastName = "George",FullName = "John George", Age = 56 },
                    new Worker() { FirstName = "Joao", LastName = "Shawn",FullName = "Joao Shawn", Age = 34 },
                    new Worker() { FirstName = "Peter", LastName = "Paul",FullName = "Peter Paul", Age = 58 }
                };

        return listWorkers;
    }

    public void GetCharacteristics(bool value)
    {
        Console.WriteLine($"Worker Characteristics for {FullName}:");
        Console.WriteLine($"Age: {Age}");
    }
}