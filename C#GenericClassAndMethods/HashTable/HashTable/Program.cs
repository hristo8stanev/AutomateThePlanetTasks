using System.Collections;
using HashTable;

namespace hashTableExercises;

class Program
{
    static void Main(string[] args)
    {
        Hashtable oddNumbersMap = new Hashtable();

        // Populate the hashmap with odd numbers from 0 to 50
        for (int i = 1; i <= 50; i += 2)
        {
            oddNumbersMap[i] = i;
        }

        // Print all odd numbers with their key values
        Console.WriteLine("Odd numbers from 0 to 50 with their key values:");


        foreach (DictionaryEntry entry in oddNumbersMap)
        {
            int key = (int)entry.Key;
            int oddNumber = (int)entry.Value;
            Console.WriteLine($"Key: {key}, Odd number: {oddNumber}");
        }
    }
}