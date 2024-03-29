﻿using System;
using System.IO;
using System.Text.RegularExpressions;


public class Program
{
    private const string successfullyRemoved = "Words starting with 'test' removed successfully!";
    private const string notFoundMessage = "File not found!";

    static void Main(string[] args)
    {

         var file = @"C:\Users\UsernameT\testFile1.txt";

        if (File.Exists(file))
        {
            try
            {
                string content;
                using (StreamReader reader = new StreamReader(file))
                {
                    content = reader.ReadToEnd();
                }

                var regexPattern = @"\best[A-Za-z0-9]*\b";
                var result = Regex.Replace(content, regexPattern, "");
                using (StreamWriter writer = new StreamWriter(file))

                {
                    writer.Write(result);
                }

                Console.WriteLine(successfullyRemoved);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        else
        {

            Console.WriteLine(notFoundMessage);
        }
    }
}