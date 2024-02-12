using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject;
public class Student
{
    private static readonly string[] firstNames = { "John", "Paul", "Ringo", "George" };
    private const string errorMessageNameValueInput = "Name cannot be null or empty. Please insert correct name";
    private static readonly Random random = new Random();
    private static readonly HashSet<int> uniqueNumbers = new HashSet<int>();

    public string _name;
    public int UniqueNumber { get; }

    public Student(string name)
    {
        Name = name;
        UniqueNumber = GenerateRandomNumbers();
    }

    public virtual string Name
    {
        get { return this._name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(errorMessageNameValueInput);
            }

            this._name = value;
        }
    }

    private int GenerateRandomNumbers()
    {
        int uniqueNum = random.Next(10000, 99999);
        return uniqueNum;
    }
    public string GeneraRandomName()
    {
        var random = new Random();
        string firstName = firstNames[random.Next(0, firstNames.Length)];
        return $"{firstName}";
    }
}
