using System;

class Worker
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public int age { get; set; }

    public static List<Worker> GetWorkers()
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


