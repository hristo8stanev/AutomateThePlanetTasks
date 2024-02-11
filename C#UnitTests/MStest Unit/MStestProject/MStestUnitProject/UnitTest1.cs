using MStestProject;


namespace MStestUnitProject;
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        Student student = new Student(null);

        Assert.IsNotNull(student.Name);
        Assert.AreEqual("Hristo",student.Name);

    }
}