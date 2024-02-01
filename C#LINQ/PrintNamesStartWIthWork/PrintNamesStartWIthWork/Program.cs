﻿using System;
using System.Reflection;


namespace Work;
class Program
{

    static void Main(string[] args)
    {
        var assembly = Assembly.GetExecutingAssembly();
        //Console.WriteLine("Assembly Name: " + assembly.GetName().Name);

        foreach (var type in assembly.GetTypes())
        {
            if (type.Namespace != null && type.Namespace.StartsWith("Work"))
            {
                Console.WriteLine($"Type name: {type.FullName}");
            }
            else
            {
                Console.WriteLine("Namespace start with 'Work' doesn't exist!");
            }
        }
    }
}