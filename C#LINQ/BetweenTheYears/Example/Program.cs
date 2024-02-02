using System;
using System.Net.Cache;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace Linq;
class Program
{
    static void Main(string[] args)
    {
        var workers = new List<Worker>
        {
           new Worker() { FirstName = "George", LastName = "John", Age = 18 },
           new Worker() { FirstName = "Tah", LastName = "Michael", Age = 22 },
           new Worker() { FirstName = "Paul", LastName = "Eddie", Age = 33 },
           new Worker() { FirstName = "Peter", LastName = "Tah", Age = 14 },
           new Worker() { FirstName = "Paul", LastName = "Joao", Age = 8 },
           new Worker() { FirstName = "Eddie", LastName = "Peter", Age = 12 },
           new Worker() { FirstName = "John", LastName = "George", Age = 56 },
           new Worker() { FirstName = "Joao", LastName = "Shawn", Age = 34 },
           new Worker() { FirstName = "Peter", LastName = "Paul", Age = 23 }
        };

        var ageBetween = workers.Where(worker => worker.Age >= 18 && worker.Age <= 24)
            .Select(worker => new { worker.FirstName, worker.LastName });

        foreach (var worker in ageBetween)
        {
            Console.WriteLine($"First name: {worker.FirstName} Last name: {worker.LastName}");
        }
    }

    class Worker
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string LastName { get; set; }
    }
}