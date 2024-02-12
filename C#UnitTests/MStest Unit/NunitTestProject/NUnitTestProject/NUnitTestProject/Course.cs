using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject;
public class Course
{
    private const string errorMessageCourseNameInput = "Invalid name, Please enter correct course name!";
    public string _name;
    private string errorMessageNumberOfStudentsInCourse = "Course members cannot be more than 30 persons";

    public HashSet<Student> Students { get; }

    public Course(string name)
    {
        Name = name;
        Students = new HashSet<Student>();
    }

    public virtual string Name
    {
        get
        {
            return this._name;
        }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length <= 0)
            {
                Console.WriteLine(errorMessageCourseNameInput);
            }
            this._name = value;
        }
    }

    public void AddStudent(Student student)
    {
        if (Students.Count >= 30)
        {
            Console.WriteLine(errorMessageNumberOfStudentsInCourse);
            return;
        }
        Students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        Students.Remove(student);
    }
}
