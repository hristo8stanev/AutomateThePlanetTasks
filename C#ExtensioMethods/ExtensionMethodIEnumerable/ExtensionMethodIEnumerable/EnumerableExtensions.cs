using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodIEnumerable;
    public static class EnumerableExtensions
{
    private const string collectionErrorMessage = "The Collection contains no elements.";

    public static T Sum<T>(this IEnumerable<T> value)
    {
        CheckIfEmptyValue(value);
        dynamic sum = 0;
        foreach(var item in value)
        {
            sum += item;
        }
        return sum;

    }
    public static T Min<T>(this IEnumerable<T> value)
    {
        CheckIfEmptyValue(value);
        return value.Min();
    }

    public static T Max<T>(this IEnumerable<T> value)
    {
        CheckIfEmptyValue(value);
        return value.Max();
    }
    public static double  Average<T>(this IEnumerable<T> value)
    {
        CheckIfEmptyValue(value);
        dynamic sum = 0;
        var count = 0;

        foreach (var item in value)
        {
            sum += item;
            count++;
        }

        return (double)sum / count;
    }

    public static void CheckIfEmptyValue<T>(IEnumerable<T> value)
    {
        if (!value.Any())
        {
            throw new ArgumentException(collectionErrorMessage);
        }
    }
}