using System.Reflection;
using MStestProject;

namespace MStestUnitProject;
    [TestClass]
    public class MSUnitTets
    {
    private  string courseName => "Biochemistry";

    [TestMethod]
        public void Try_AddStudentToCourse_When_CourseIsNotFull_ShouldAddStudentToCourse()
        {

        //ARRANGE
        var course = new Course(courseName);
        var student = new Student();

        //ACT 
        course.AddStudent(student);

        //ASSERT
        Assert.IsTrue(course.Students.Contains(student));
        Assert.IsNotNull(student.Name);
        
    }


    [TestMethod]
    public void Try_RemoveStudentFromCourse_When_StudentIsEnrolled_ShouldRemoveStudentFromCourse()
    {
        //ARRANGE
        var course = new Course(courseName);
        var student = new Student();
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
        var course = new Course(courseName);

        //ACT
        school.AddCourse(course);

        //ASSERT
        Assert.IsTrue(school.Courses.Contains(course));
        Assert.AreEqual(courseName, course.Name);
    }

    [TestMethod]
    public void Try_RemoveCourseFromSchool_When_CoursetIsAdded_ShouldRemoveCourseFromSchool()
    {
        //ARRANGE
        var school = new School();
        var course = new Course(courseName);
        school.AddCourse(course);

        //ACT
        school.RemoveCourse(course);

        //ASSERT
        Assert.IsFalse(school.Courses.Contains(course));
        Assert.IsTrue(school.Courses.Count() == 0);

    }

    [TestMethod]    
    public void Try_AddStudent_When_CourseIsFull_And_TriesToAddStudent_ShouldNotAddStudentToCourse()
    {

        //ARRANGE
        var course = new Course(courseName);
        for(int i = 0; i < 30; i++)
        {
            course.AddStudent(new Student());
        }
        var student = new Student();

        //ACT
        course.AddStudent(student);

        //ASSERT
        Assert.IsFalse(course.Students.Contains(student));

    }

    [TestMethod]
    public void Try_GenerateNumber_When_CreatedNewStudent_TriesToGenerateUniqueNumber_ShouldReturnUniqueNumber()
    {
        //ARRANGE
        var student = new Student();

        //ACT
        int uniqueNum = GetUniqueNumberGenerator(student);

        //ASSERT
        Assert.IsTrue(uniqueNum != 0 || uniqueNum > 0 );
    }

    [TestMethod]
    public void Try_GenerateName_When_CreatedNewStudent_TriesToGenerateRandomStudentName_ShouldReturnRandomStudentName()
    {
        //ARRANGE
        var student = new Student();

        //ACT
        var studentName = student.GenerateRandomName();


        //ASSERT
        Assert.IsNotNull(studentName);
        Assert.AreEqual(student.Name,(studentName));

    }

    private int GetUniqueNumberGenerator(Student student)
    {
        MethodInfo methodInfo = typeof(Student).GetMethod("GenerateRandomNumbers", BindingFlags.NonPublic | BindingFlags.Instance);
        return (int)methodInfo.Invoke(student, null);
    }
}