using System;
using System.Collections;
using System.Collections.Generic;
using HashTable;

namespace hashTableExercises;

 class Program
{
    static void Main(string[] args)
    {
        Hashtable<int, string> hashTable = new Hashtable<int, string>();
        hashTable.Add(1, "Ivan");
        hashTable.Add(2, "Petkan");
        hashTable.Add(3, "Dragan");
        hashTable.Add(4, "Gosho");
        hashTable.Add(5, "Pesho");
        hashTable.Remove(3);

        Console.WriteLine($"Value for key 1: {hashTable.Find(1)}");
        Console.WriteLine($"Value for key 2: {hashTable.Find(2)}");
        Console.WriteLine($"Value for key 3: {hashTable.Find(3)}");

    }
}