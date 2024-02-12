using System.Reflection;
using MStestProject;

namespace MStestUnitProject;
    [TestClass]
    public class MSUnitTets
    {
        [TestMethod]
        public void Try_AddStudentToCourse_When_CourseIsNotFull_ShouldAddStudentToCourse()
        {

        //ARRANGE
        var course = new Course("Information Technology");
        var student = new Student("Hristo");

        //ACT 
        course.AddStudent(student);

        //ASSERT
        Assert.IsTrue(course.Students.Contains(student));
        Assert.IsNotNull(student.Name);
        Assert.AreEqual("Hristo",student.Name);

    }
    [TestMethod]
    public void Try_RemoveStudentFromCourse_When_StudentIsEnrolled_ShouldRemoveStudentFromCourse()
    {
        //ARRANGE
        var course = new Course("Mathematics");
        var student = new Student("George");
        course.AddStudent(student);

        //ACT
        course.RemoveStudent(student);

        //ASSERT
   
        Assert.IsFalse(course.Students.Contains(student));
    }

    [TestMethod]
    public void Try_AddCourseToSchool_When_CourseIsNotAdded_ShouldAddCourseToSchool()
    {
        //ARRANGE
        var school = new School();
        var course = new Course("Sport");

        //ACT
        school.AddCourse(course);

        //ASSERT
        Assert.IsTrue(school.Courses.Contains(course));
        Assert.AreEqual("Sport", course.Name);
    }

    [TestMethod]
    public void Try_RemoveCourseFromSchool_When_CoursetIsAdded_ShouldRemoveCourseFromSchool()
    {
        //ARRANGE
        var school = new School();
        var course = new Course("Biochemistry");
        school.AddCourse(course);

        //ACT
        school.RemoveCourse(course);

        //ASSERT
        Assert.IsFalse(school.Courses.Contains(course));
    }

    [TestMethod]
    public void Try_AddStudent_When_CourseIsFull_And_TriesToAddStudent_ShouldNotAddStudentToCourse()
    {

        //ARRANGE
        var course = new Course("Quality Assurance");
        for(int i = 0; i < 30; i++)
        {
            course.AddStudent(new Student($"Student{i}"));
        }
        var student = new Student("Ivan");

        //ACT
        course.AddStudent(student);

        //ASSERT
        Assert.IsFalse(course.Students.Contains(student));
    }

    [TestMethod]
    public void Try_GenerateNumber_When_CreatedNewStudent_TriesToGenerateUniqueNumber_ShouldReturnUniqueNumber()
    {
        //ARRANGE
        var student = new Student("Alisson");

        //ACT
        int uniqueNum = GetUniqueNumberGenerator(student);

        //ASSERT
        Assert.IsTrue(uniqueNum != 0 || uniqueNum > 0 );
    }

    private int GetUniqueNumberGenerator(Student student)
    {
        MethodInfo methodInfo = typeof(Student).GetMethod("GenerateUniqueNumberStudent", BindingFlags.NonPublic | BindingFlags.Instance);
        return (int)methodInfo.Invoke(student, null);
    }
}