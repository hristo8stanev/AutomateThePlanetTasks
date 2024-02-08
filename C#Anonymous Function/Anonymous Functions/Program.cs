using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous_Method;
class Program
{
    static void Main(string[] args)
    {
        Timer timer = new Timer();
        timer.Start(2, () => SayHello());

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    static void SayHello()
    {
        Console.WriteLine("Tic-Tac");
    }
}