using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace stringBuilderTask;

public static class Extensions
{
    private const string errorMessageInput = "Invalid Input";
    private const string errorMessageIndexLength = "Invalid index or length";

    static void Main()
    {
        string text = "My first extension method.";
        string result = text.MySubstring(1, 5);
        Console.WriteLine(result);
    }
    public static string MySubstring(this string value, int index, int length)
    {

        if (value == null)
        {
            throw new ArgumentOutOfRangeException(nameof(value), errorMessageInput);
        }
        if (index < 0 || index >= value.Length || length < 0 || index + length > value.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(value),errorMessageIndexLength);
        }
      
        return value.Substring(index, length);
    }
}