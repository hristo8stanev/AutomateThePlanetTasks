using System;
using System.IO;


public class Program
{
    static void Main(string[] args)
    {

        string inputFile = @"C:\Users\UsernameT\testFile.txt";
        string outputFile = @"C:\Users\UsernameT\testFile1.txt";

     //   InsertLineNumbersToFile(inputFile, outputFile);
        CompareTwoTextFiles(inputFile, outputFile);
    }


   // public static void InsertLineNumbersToFile(string inputFile, string outputFile)
   // {
   //     using (StreamReader reader = new StreamReader(inputFile))
   //     using (StreamWriter writer = new StreamWriter(outputFile))
   //     {
   //         int lineNumber = 1;
   //
   //         while (!reader.EndOfStream)
   //         {
   //             string line = reader.ReadLine();
   //             string lineWithNumber = $"{lineNumber++}. {line}";
   //             writer.WriteLine(lineWithNumber);
   //
   //         }
   //     }
   // }
    public static void CompareTwoTextFiles(string inputFile, string outputFile)
    {
        using (StreamReader reader = new StreamReader(inputFile))
        using (StreamWriter writer = new StreamWriter(outputFile))
        {

            int lineNumber = 1;
            
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                var listA = File.ReadAllLines(inputFile);
                var listExceptAB = File.ReadAllLines(outputFile)
                .Except(listA);
                string equalsLine = $"{lineNumber++}. {line}";
                writer.WriteLine(equalsLine);

            }
        }
    }
}