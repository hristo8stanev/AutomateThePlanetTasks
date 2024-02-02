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

        //METHOD SYNTAX  - TASK 2
          var workers = Worker.GetAllWorkers()
         .OrderByDescending(x => x.firstName)
               .ThenByDescending(y => y.lastName)
               .ToList();

        //LINQ query syntax = TASK 3
       //var workers = from worker in Worker.GetAllWorkers()
       //              orderby worker.FirstName descending, worker.LastName descending
       //              select worker;

        foreach (var worker in workers)
        {
            Console.WriteLine($"First name: {worker.firstName} Last name: {worker.lastName}");
        }
    }

    class Worker
    {
        public string firstName { get; set; }
        public int age { get; set; }
        public string lastName { get; set; }
        public static List<Worker> GetAllWorkers()
        {
            List<Worker> listWorkers = new List<Worker>
                {
                    new Worker() { firstName = "George", lastName = "John", age = 18 },
                    new Worker() { firstName = "Tah", lastName = "Michael", age = 54 },
                    new Worker() { firstName = "Paul", lastName = "Eddie", age = 33 },
                    new Worker() { firstName = "Peter", lastName = "Tah", age = 14 },
                    new Worker() { firstName = "Paul", lastName = "Joao", age = 8 },
                    new Worker() { firstName = "Eddie", lastName = "Peter", age = 12 },
                    new Worker() { firstName = "John", lastName = "George", age = 56 },
                    new Worker() { firstName = "Joao", lastName = "Shawn", age = 34 },
                    new Worker() { firstName = "Peter", lastName = "Paul", age = 58 }
                };

            return listWorkers;
        }
    }
}
