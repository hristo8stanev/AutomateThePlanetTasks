namespace stringBuilderTask;

public static class Extensions
{
    private static string ErrorMessageInput => "Invalid Input";
    private static string errorMessageIndexLength => "Invalid index or length";


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
            throw new ArgumentOutOfRangeException(nameof(value), ErrorMessageInput);
        }
        if (index < 0 || index >= value.Length || length < 0 || index + length > value.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(value), errorMessageIndexLength);
        }

        return value.Substring(index, length);
    }
}
