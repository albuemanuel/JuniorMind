using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalogue
{
    [TestClass]
    public class CatalogueTests
    {
        [TestMethod]
        public void AverageGradePerSub()
        {
            Subject math = new Subject("math", new double[] { 1, 3, 5.5, 7 });

            Assert.AreEqual(4.125, math.GetAvg());
        }

        [TestMethod]
        public void AverageOverallGradesPerStudent()
        {
            Subject math = new Subject("math", new double[] { 1, 3, 5.5, 7 });
            Subject english = new Subject("english", new double[] { 2, 5, 4, 3, 6 });
            Subject physics = new Subject("physics", new double[] { 7, 4, 1, 2, 5, 10, 3 });

            Student student = new Student("Marian", new Subject[] { math, english, physics });

            Assert.AreEqual(4.232142857142857, student.GetOverallAvg());
        }

        [TestMethod]
        public void ComparedStudents()
        {
            Subject course1 = new Subject("math", new double[] { 1, 3, 5.5, 7 });
            Subject course2 = new Subject("english", new double[] { 2, 5, 4, 3, 6 });
            Subject course3 = new Subject("physics", new double[] { 7, 4, 1, 2, 5, 10, 3 });
            Subject course4 = new Subject("logicDesign", new double[] { 1, 3, 5.5, 7 });
            Subject course5 = new Subject("french", new double[] { 2, 5, 4, 3, 6 });
            Subject course6 = new Subject("biochemistry", new double[] { 7, 4, 1, 2, 5, 10, 10 });

            Student student = new Student("Marian", new Subject[] { course1, course2, course3 });

            Student studentTwo = new Student("Maria", new Subject[] { course4, course5, course6 });

            Assert.IsFalse(student.IsFirstSecondOrEqual(studentTwo, Student.Comparer.Grades));
            Assert.IsTrue(studentTwo.IsFirstSecondOrEqual(student, Student.Comparer.Grades));

            Assert.IsTrue(student.IsFirstSecondOrEqual(studentTwo, Student.Comparer.Name));
        }

        [TestMethod]
        public void SwapedStudentsInCatalogue()
        {
            Student student = new Student("Maria");
            Student student2 = new Student("Ionel");

            Catalogue catalogue = new Catalogue(new Student[] { student, student2});
            Catalogue expected = new Catalogue(new Student[] { student2, student });

            catalogue.Swap(0, 1);

            Assert.AreEqual(expected.ToString(), catalogue.ToString());

        }

        [TestMethod]
        public void AlphabeticallyOrderedStudents()
        {
            Subject course1 = new Subject("math", new double[] { 1, 3, 5.5, 7 });
            Subject course2 = new Subject("english", new double[] { 2, 5, 4, 3, 6 });
            Subject course3 = new Subject("physics", new double[] { 7, 4, 1, 2, 5, 10, 3 });
            Subject course4 = new Subject("logicDesign", new double[] { 1, 3, 5.5, 7 });
            Subject course5 = new Subject("french", new double[] { 2, 5, 4, 3, 6 });
            Subject course6 = new Subject("biochemistry", new double[] { 7, 4, 1, 2, 5, 10, 10 });
            Subject course7 = new Subject("informationTheory", new double[] { 2, 4, 6, 8, 10, 3, 1, 5 });
            Subject course8 = new Subject("norwegian", new double[] { 5, 3, 6, 7, 8, 2, 1 });
            Subject course9 = new Subject("electricalEngineering", new double[] { 5, 4, 6, 9, 7, 8, 10, 4 });

            Student student = new Student("Marian", new Subject[] { course1, course2, course3 });
            Student studentTwo = new Student("Stefana", new Subject[] { course4, course5, course6 });
            Student studentThree = new Student("Cristina", new Subject[] { course7, course8, course9 });

            Catalogue catalogue = new Catalogue(new Student[] { student, studentTwo, studentThree });
            Catalogue expected = new Catalogue(new Student[] { studentThree, student, studentTwo });

            catalogue.OrderStudentsAlphabetically();

            Assert.AreEqual(expected.ToString(), catalogue.ToString());
        }


    }
}
