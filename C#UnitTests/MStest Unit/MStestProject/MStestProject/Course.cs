using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStestProject;
public class Course
{
    private string errorMessageCourse => "Course members cannot be more 30 persons";
    public HashSet<Student> Students { get; }
    public Course()
    {
        Students = new HashSet<Student>();
    }

    public void AddStudent(Student student)
    {
        if (Students.Count >= 30)
        {
            throw new ArgumentOutOfRangeException(nameof(Students), errorMessageCourse);
        }
        Students.Add(student);
    }
    public void RemoveStudent(Student student)
    {
        Students.Remove(student);
    }

}
