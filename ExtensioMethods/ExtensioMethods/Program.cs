using System;


public class Anonymous
{
    static int Sum(int x, int y)
    {
        return x + y;
    }

    static public void Main(string[] args)
    {
        Func<int> getRandomNumber = () => new Random().Next(1,50);

      
        Console.WriteLine(getRandomNumber);

    }
}