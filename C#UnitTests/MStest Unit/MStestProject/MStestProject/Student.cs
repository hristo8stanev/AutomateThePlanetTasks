using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStestProject;
public class Student
{
    private string invalidInputMessage => "Invalid input";
    private static readonly Random random = new Random();
    private static readonly HashSet<int> uniqueNumbers = new HashSet<int>();

    public string _name;
    public int UniqueNumber { get; }

    public Student(string name)
    {
        Name = name;
        UniqueNumber = GenerateUniqueNumberStudent();
    }

    public virtual string Name
    {
        get{return this._name;

        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(invalidInputMessage);
            }

            this._name = value;
        }
    }

    private int GenerateUniqueNumberStudent()
    {
        int uniqeNum = random.Next(10000, 999999);

        return uniqeNum;
    }
}
