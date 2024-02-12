using System;
using NUnitTestProject;

namespace NUnitTest;

public class Program
{
    public static void Main(string[] args)
    {

        Student firstStudent = new Student("Charlie");
        Student secondStudent = new Student("Michael");

        Course course = new Course("Biochemistry");
        course.AddStudent(firstStudent);
        course.AddStudent(secondStudent);

        School school = new School();
        school.AddCourse(course);

        foreach (Course courses in school.Courses)
        {
            Console.WriteLine($"- {course.Name}: ");

            foreach (Student student in courses.Students)
            {
                Console.WriteLine($"- {student.Name} (Unique Numbers: {student.UniqueNumber})");
            }
        }
    }
}