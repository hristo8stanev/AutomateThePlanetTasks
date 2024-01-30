using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddLines;
public class OddLines
{
    static void Main(string[] args)
    {
        var fi = new FileInfo(@"C:\Users\UsernameT\oddLines.txt");
        using var fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
        using var sw = new StreamWriter(fs);
        sw.WriteLine("Welcome");
        sw.WriteLine("To");
        sw.WriteLine("My");
        sw.WriteLine("First");
        sw.WriteLine("Text File");

        string readText = File.ReadAllText(@"C:\Users\UsernameT\oddLines.txt");
        Console.WriteLine(readText);

        foreach (var line in readText)
        {
            if (line % 2 == 1)
            {
                Console.WriteLine(line);
            }
        }
    }
}


