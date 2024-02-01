using System;
using System.IO;

public class InsertLineNumbers
{
    static void Main()
    {
        string inputFile = @"C:\Users\UsernameT\testFile1.txt";
        string outputFile = @"C:\Users\UsernameT\testFile.txt";


        InsertLineNumbersToFile(inputFile, outputFile);
    }

    public static void InsertLineNumbersToFile(string inputFile, string outputFile)
    {
        using (StreamReader reader = new StreamReader(inputFile))
        using (StreamWriter writer = new StreamWriter(outputFile))
        {

            int lineNumber = 1;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string lineWithNumber = $"{lineNumber++}. {line}";
                writer.WriteLine(lineWithNumber);
            }
        }
    }
}