﻿using System;
using System.Reflection;


class Program
{

    public static void Main(string[] args)
    {

        Worker worker = new Worker();
        var workerType = worker.GetType();

        var fullNameProperty = workerType.GetProperty("FullName", typeof(string));

        if (fullNameProperty != null)
        {
            fullNameProperty.SetValue(worker, "Ivan Draganov");
        }

        var getCharacteristicsMethod = workerType.GetMethod("GetCharacteristics"); 

        if (getCharacteristicsMethod != null)
        {

            var result = getCharacteristicsMethod.Invoke(worker, new object[] { false });
            Console.WriteLine($"Method result: {result}");
        }
    }
}