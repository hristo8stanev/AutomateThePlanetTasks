using System;
using System.Text;


class Program
{

    static void Main(String[] args)
    {

        string inputFile = @"C:\Users\UsernameT\words.txt";
        string outputFile = @"C:\Users\UsernameT\test.txt";

        string line;
        var list = new List<string>();
        var fileStream = new FileStream(@"C:\Users\UsernameT\words.txt", FileMode.Open, FileAccess.Read);

        var streamReader = new StreamReader(fileStream, Encoding.UTF8);
        while ((line = streamReader.ReadLine()) != null)


            if (File.Exists(inputFile))
        {

        }


    }
}