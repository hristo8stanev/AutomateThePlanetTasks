using System;
using System.IO;

public class Program
{
    static void Main(string[] args)
    {
        //how do i made my path relative?
        string inputFile = @"C:\Users\UsernameT\testFile.txt";
        string outputFile = @"C:\Users\UsernameT\testFile1.txt";
        CompareTwoTextFiles(inputFile, outputFile);
    }

    public static void CompareTwoTextFiles(string inputFile, string outputFile)
    {
        int sameLineCount = 0;
        int differentLineCount = 0;

        using (StreamReader readerA = new StreamReader(inputFile))
        using (StreamReader readerB = new StreamReader(inputFile))
        {
            int lineNumber = 1;

            while (!readerA.EndOfStream && !readerB.EndOfStream)
            {
                string lineA = readerA.ReadLine();
                string lineB = readerB.ReadLine();

                if (lineA == lineB)
                {
                    sameLineCount++;
                }
                else
                {
                    differentLineCount++;
                }

                Console.WriteLine($"{lineNumber++},Line A: {lineA}, Line B: {lineB}");
            }
        }
        Console.WriteLine($"Number of same lines: {sameLineCount}");
        Console.WriteLine($"Number of different lines: {differentLineCount}");
    }
}