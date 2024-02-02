using System;
using System.Collections;
using System.Reflection.Metadata;
using System.Configuration;

public class Anonymous
{
    public static void Main()
    {

        //IN PROGRESS

        Timer timer = new Timer(0, 5, TimerCallBack);
        timer.Start();
        
        Console.ReadLine();

    }
    private static void TimerCallBack()
    {

        Console.WriteLine("Timer callback executed!");
    }
}