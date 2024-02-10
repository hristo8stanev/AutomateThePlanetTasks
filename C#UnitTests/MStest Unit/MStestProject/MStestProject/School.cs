using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStestProject;
    public class School
    {
    public List<Course> Courses = new List<Course>();

    public School()
    {
        Courses = new List<Course>();
    }

    public void AddCourse(Course value)
    {
        Courses.Add(value);
    }
}
