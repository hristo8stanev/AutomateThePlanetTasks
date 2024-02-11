using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStestProject;
public class Course
{
    public string Name { get; }
    private string errorMessageCourse => "Course members cannot be more 30 persons";
    public HashSet<Student> Students { get; }
    public Course(string name)
    {
        Name = name;
        Students = new HashSet<Student>();
    }

    public void AddStudent(Student student)
    {
        if (Students.Count >= 30)
        {
           Console.WriteLine(errorMessageCourse);
            return;
        }
        Students.Add(student);
    }
    public void RemoveStudent(Student student)
    {
        Students.Remove(student);
    }

}
