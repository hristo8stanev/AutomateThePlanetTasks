using System;
using System.Text;

namespace stringBuilderTask;
public static class Extensions
{
    private static string errorMessageInput => "Invalid Input";
    private static string errorMessageIndexLength => "Invalid index or length";

    static void Main()
    {
        StringBuilder text = new StringBuilder("My first extension method.");
        string result = text.Substring(3, 5);
        Console.WriteLine(result);
    }

    public static string Substring(this StringBuilder value, int index, int length)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value), errorMessageInput);
        }
        if (index < 0 || index >= value.Length || length < 0 || index + length > value.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index), errorMessageIndexLength);
        }

        StringBuilder result = new StringBuilder(length);
        for (int i = index; i < index + length; i++)
        {
            result.Append(value[i]);
        }

        return result.ToString();
    }
}

