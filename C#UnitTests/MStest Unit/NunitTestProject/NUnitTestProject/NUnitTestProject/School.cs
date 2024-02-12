using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject;
public class School
{
    public List<Course> Courses;

    public School()
    {
        Courses = new List<Course>();
    }

    public void AddCourse(Course value)
    {
        Courses.Add(value);
    }
    public void RemoveCourse(Course value)
    {
        Courses.Add(value);
    }
}
