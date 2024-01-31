﻿using System;
using System.Net.Cache;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;


namespace Linq;
class Program
{
    static void Main(string[] args)
    {
        var workers = Worker.GetAllWorkers()
           .OrderBy(x => x.FirstName)
                            .ThenBy(y => y.LastName)
                            .ToList();


        foreach(var worker in workers)
        {

            Console.WriteLine($"First name: {worker.FirstName} Last name: {worker.LastName}");
        }
    }

    class Worker
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string LastName { get; set; }

        public static List<Worker> GetAllWorkers()
        {
            List<Worker> listWorkers = new List<Worker>();
            {
                new Worker() { FirstName = "George", LastName = "John", Age = 18 };
                new Worker() { FirstName = "Tah", LastName = "Michael", Age = 54 };
                new Worker() { FirstName = "Paul", LastName = "Eddie", Age = 33 };
                new Worker() { FirstName = "Peter", LastName = "Tah", Age = 14 };
                new Worker() { FirstName = "Paul", LastName = "Joao", Age = 8 };
                new Worker() { FirstName = "Eddie", LastName = "Peter", Age = 12 };
                new Worker() { FirstName = "John", LastName = "George", Age = 56 };
                new Worker() { FirstName = "Joao", LastName = "Shawn", Age = 34 };
                new Worker() { FirstName = "Peter", LastName = "Paul", Age = 58 };
            };
            return listWorkers;
        }
    }
}