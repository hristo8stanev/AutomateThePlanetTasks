using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace stringBuilderTask;
public static class Extensions
{
    private static string errorMessageInput => "Invalid Input";
    private static string errorMessageIndexLength => "Invalid index or length";

    static void Main()
    {
        StringBuilder sb = new StringBuilder("My first extension method.");
        var result = sb.stringBuider(0,2);
        Console.WriteLine(result);
    }

    public static StringBuilder stringBuider(this StringBuilder stringBuider, int index, int length)
    {
        if (stringBuider == null)
        {
            throw new ArgumentNullException(nameof(stringBuider), errorMessageInput);
        }
        if (index < 0 || index >= stringBuider.Length || length < 0 || index + length > stringBuider.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index), errorMessageIndexLength);
        }

        var StringBuider = new StringBuilder(length);

        for(var i = 0; i<index + length; i++)
        {
            StringBuider.Append(stringBuider[i]);
        }

        return StringBuider;
    }
}