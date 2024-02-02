using System;

class Worker
{

    public string firstName { get; set; }
    public string lastName { get; set; }
    public string fullName { get; set; }
    public int age { get; set; }

    public static List<Worker> GetWorkers()
    {
        List<Worker> listWorkers = new List<Worker>
        {
                    new Worker() { firstName = "George", lastName = "John", fullName = "George John", age = 18 },
                    new Worker() { firstName = "Tah", lastName = "Michael",fullName = "Tah Michael", age = 54 },
                    new Worker() { firstName = "Paul", lastName = "Eddie",fullName = "Paul Eddie", age = 33 },
                    new Worker() { firstName = "Peter", lastName = "Tah",fullName = "Peter Tah", age = 14 },
                    new Worker() { firstName = "Paul", lastName = "Joao",fullName = "Paul Joao", age = 8 },
                    new Worker() { firstName = "Eddie", lastName = "Peter",fullName = "Eddie Peter", age = 12 },
                    new Worker() { firstName = "John", lastName = "George",fullName = "John George", age = 56 },
                    new Worker() { firstName = "Joao", lastName = "Shawn",fullName = "Joao Shawn", age = 34 },
                    new Worker() { firstName = "Peter", lastName = "Paul",fullName = "Peter Paul", age = 58 }
                };

        return listWorkers;
    }

    public static void GetCharacteristics()
    {
        //in progress
    }
}