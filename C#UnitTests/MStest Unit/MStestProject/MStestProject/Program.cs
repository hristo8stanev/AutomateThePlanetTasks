using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStestProject;
public class Program
{

public static void Main(string[] args)
    {

        Student firstStudent = new Student("Hristo");
        Student secondtudent = new Student("Bob");
        Student thirdtudent = new Student("Charlie");

        Course itCourse = new Course("Information Technology");
        itCourse.AddStudent(firstStudent);
        itCourse.AddStudent(secondtudent);
        itCourse.AddStudent(thirdtudent);

        School telerik = new School();
        telerik.AddCourse(itCourse);

        foreach(Course course in telerik.Courses)
        {
            Console.WriteLine($"- {course.Name}:");

            foreach (Student student in course.Students)
            {
                Console.WriteLine($" - {student.Name} (Unique Number: {student.UniqueNumber})");
            }
        }
    }
}
