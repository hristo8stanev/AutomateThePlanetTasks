using MStestProject;


namespace MStestUnitProject;
    [TestClass]
    public class MSUnitTets
    {
        [TestMethod]
        public void AddStudentToCourse_ShouldAddStudentToCourse()
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
    public void RemoveStudentFromCourse_ShouldRemoveStudentFromCourse()
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
    public void AddCourseToSchool_ShouldAddCourseToSchool()
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
    public void RemoveCourseFromSchool_ShouldRemoveCourseFromSchool()
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
    public void TryToAddStudentToFullCourse_ShouldNotAddStudentToCourse()
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
}