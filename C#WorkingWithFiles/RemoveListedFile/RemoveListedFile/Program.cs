using System;
using System.IO;

class Program
{
    private const string successfullyMessage = "Words removed successfully!";

    public static void Main(string[] args)
    {

        string inputFile = @"C:\Users\UsernameT\testFile.txt";
        string outputFile = @"C:\Users\UsernameT\testFile1.txt";

        try
        {
            RemoveAllListedWords(inputFile, outputFile);
            Console.WriteLine(successfullyMessage);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);

        }
    }

    public static void RemoveAllListedWords(string inputFile, string outputFile)
    {

        List<string> removedWords = new List<string>();
        using (StreamReader readerA = new StreamReader(outputFile))
        {
            while (!readerA.EndOfStream)
            {
                string word = readerA.ReadLine();
                removedWords.Add(word);
            }
        }

        string content;
        using (StreamReader fileReader = new StreamReader(inputFile))
        {
            content = fileReader.ReadToEnd();
        }

        foreach(string word in removedWords)
        {
            content = content.Replace(word, String.Empty);
        }
        using (StreamWriter writer = new StreamWriter(inputFile))
        {
            writer.Write(content);
        }
    }
}