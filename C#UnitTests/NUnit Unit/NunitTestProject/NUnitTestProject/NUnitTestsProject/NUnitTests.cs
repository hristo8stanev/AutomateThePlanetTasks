using System.Reflection;
using NUnitTestProject;

namespace NUnitTestsProject;

public class Tests
{
    private string courseName => "Information Technology";

    [SetUp]
    public void Init()
    {
        //try to initialez all classes
        //Generate random Name

    }

    [Test]
    public void Try_AddStudentToCourse_When_CourseIsNotFull_ShouldAddStudentToCourse()
    {
        //ARRANGE
        var course = new Course(courseName);
        var student = new Student();

        //ACT 
        course.AddStudent(student);

        //ASSERT
        Assert.That(course.Students, Has.Member(student));

    }

    [Test]
    public void Try_RemoveStudenfromCourse_When_StudentIsNotEnrolled_ShouldRemoveStudentFromCourse()
    {
        //ARRAGNE
        var course = new Course(courseName);
        var student = new Student();
        course.AddStudent(student);

        //ACT
        course.RemoveStudent(student);

        //ASSERT
        Assert.That(course.Students, Does.Not.Contain(student));
    }

    [Test]
    public void Try_AddCourseToSchool_When_CourseIsNotAdded_ShouldAddCourseToSchool()
    {
        //ARRANGE
        var school = new School();
        var course = new Course(courseName);

        //ACT
        school.AddCourse(course);

        //ASSERT
        Assert.That(school.Courses, Has.Member(course));

    }

    [Test]
    public void Try_RemoveCourseFromSchool_When_CourseIsAdded_ShouldRemoveCourseFromSchool()
    {
        //ARRANGE
        var school = new School();
        var course = new Course(courseName);
        school.AddCourse(course);

        //ACT
        school.RemoveCourse(course);

        //ASSERT
        Assert.That(school.Courses.Contains(course), Is.False);
    }

    [Test]
    public void Try_AddStudent_When_CourseIsFull_And_TriesToAddStudent_ShouldNotAddStudentToCourse()
    {
        //ARRANGE
        var course = new Course(courseName);

        for (int i = 0; i< 30; i++)
        {
            course.AddStudent(new Student());
        }
        var student = new Student();

        //ACT
        course.AddStudent(student);

        //ASSERT
        Assert.That(course.Students.Contains(student), Is.False);

    }

    [Test]
    public void Try_GenerateNumber_When_CreatedNewStudent_TriesToGenerateUniqueNumber_ShouldReturnUniqueNumber()
    {
        //ARRANGE
        var student = new Student();

        //ACT
        int uniqueNum = GenerateRandomNumbers(student);

        //ASSERT
        Assert.That(uniqueNum, Is.GreaterThan(0));

    }
    [Test]
    public void Try_GenerateName_When_CreatedNewStudent_TriesToGenerateRandomStudentName_ShouldReturnRandomStudentName()
    {
        //ARRANGE
        var student = new Student();

        //ACT
        var studentName = student.GenerateRandomName();


        //ASSERT
        Assert.That(studentName, Is.Not.Null.And.Not.Empty);
        Assert.That(student.Name, Is.EqualTo(studentName));

    }

    private int GenerateRandomNumbers(Student student)
    {
        MethodInfo methodInfo = typeof(Student).GetMethod("GenerateRandomNumbers", BindingFlags.NonPublic | BindingFlags.Instance);
        return (int)methodInfo.Invoke(student, null);
    }

    private string GetGenerateRandomName(Student student)
    {
        MethodInfo methodInfo = typeof(Student).GetMethod("GenerateRandomName", BindingFlags.NonPublic | BindingFlags.Instance);
        return (string)methodInfo.Invoke(student, null);
    }
}