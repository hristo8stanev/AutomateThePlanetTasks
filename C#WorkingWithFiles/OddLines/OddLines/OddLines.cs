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
        using (var sw = new StreamWriter(fs))
        {
            sw.WriteLine("Welcome");
            sw.WriteLine("To");
            sw.WriteLine("My");
            sw.WriteLine("First");
            sw.WriteLine("Text File");
        }
        using (var sr = new StreamReader(fi.OpenRead()))
        {
            int lineNumber = 1;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                if (lineNumber % 2 == 1)
                {
                    Console.WriteLine(line);
                }

                lineNumber++;
            }
        }
    }
}
    


