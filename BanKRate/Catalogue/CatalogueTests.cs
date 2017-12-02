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
            Subject math = new Subject("math", new double[] { 2,2,2,2,2});
            Subject english = new Subject("english", new double[] { 4,4,4,4,4,4,4 });
            Subject physics = new Subject("physics", new double[] { 6,6,6,6,6,6,6,6 });

            Student student = new Student("Marian", new Subject[] { math, english, physics });

            Assert.AreEqual(4, student.GetOverallAvg());
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

        [TestMethod]
        public void OrderedStudentsByOverallAverageGrades()
        {
            Subject course1 = new Subject("math", new double[] { 1, 3, 5.5, 7 });
            Subject course2 = new Subject("english", new double[] { 2, 5, 4, 3, 6 });
            Subject course3 = new Subject("physics", new double[] { 7, 4, 1, 2, 5 });
            Subject course4 = new Subject("logicDesign", new double[] { 2,2,2,2,2});
            Subject course5 = new Subject("french", new double[] { 2,2,2,2 });
            Subject course6 = new Subject("biochemistry", new double[] { 2,2,2,2,2 });
            Subject course7 = new Subject("informationTheory", new double[] { 3,3,3,3,3,3 });
            Subject course8 = new Subject("norwegian", new double[] { 3,3,3,3,3,3});
            Subject course9 = new Subject("electricalEngineering", new double[] { 3,3,3,3,3,3,3});

            Student student = new Student("Marian", new Subject[] { course1, course2, course3 });
            Student studentTwo = new Student("Stefana", new Subject[] { course4, course5, course6 });
            Student studentThree = new Student("Cristina", new Subject[] { course7, course8, course9 });

            Catalogue catalogue = new Catalogue(new Student[] { student, studentTwo, studentThree });
            Catalogue expected = new Catalogue(new Student[] { student, studentThree, studentTwo });

            catalogue.OrderStudentsByOverallAvg();

            Assert.AreEqual(expected.ToString(), catalogue.ToString());
        }

        [TestMethod]
        public void IsOrderedByAverage()
        {
            Subject course1 = new Subject("math", new double[] { 1, 3, 5.5, 7 });
            Subject course2 = new Subject("english", new double[] { 2, 5, 4, 3, 6 });
            Subject course3 = new Subject("physics", new double[] { 7, 4, 1, 2, 5 });
            Subject course4 = new Subject("logicDesign", new double[] { 2, 2, 2, 2, 2 });
            Subject course5 = new Subject("french", new double[] { 2, 2, 2, 2 });
            Subject course6 = new Subject("biochemistry", new double[] { 2, 2, 2, 2, 2 });
            Subject course7 = new Subject("informationTheory", new double[] { 3, 3, 3, 3, 3, 3 });
            Subject course8 = new Subject("norwegian", new double[] { 3, 3, 3, 3, 3, 3 });
            Subject course9 = new Subject("electricalEngineering", new double[] { 3, 3, 3, 3, 3, 3, 3 });

            Student student = new Student("Marian", new Subject[] { course1, course2, course3 });
            Student studentTwo = new Student("Stefana", new Subject[] { course4, course5, course6 });
            Student studentThree = new Student("Cristina", new Subject[] { course7, course8, course9 });

            Catalogue catalogue = new Catalogue(new Student[] { student, studentTwo, studentThree });

            Assert.IsFalse(catalogue.IsOrderedByAvg());

            catalogue.OrderStudentsByOverallAvg();

            Assert.IsTrue(catalogue.IsOrderedByAvg());
        }

        [TestMethod]
        public void BinarySearch()
        {
            Subject course1 = new Subject("math", new double[] { 4,4,4,4,4 });
            Subject course2 = new Subject("english", new double[] { 4,4,4,4,4,4 });
            Subject course3 = new Subject("physics", new double[] {4,4,4,4,4,4 });
            Subject course4 = new Subject("logicDesign", new double[] { 2, 2, 2, 2, 2 });
            Subject course5 = new Subject("french", new double[] { 2, 2, 2, 2 });
            Subject course6 = new Subject("biochemistry", new double[] { 2, 2, 2, 2, 2 });
            Subject course7 = new Subject("informationTheory", new double[] { 2, 2, 2, 2, 2 });
            Subject course8 = new Subject("norwegian", new double[] { 2, 2, 2, 2, 2 });
            Subject course9 = new Subject("electricalEngineering", new double[] { 2, 2, 2, 2, 2 });

            Student student = new Student("Marian", new Subject[] { course1, course2, course3 });
            Student studentTwo = new Student("Stefana", new Subject[] { course4, course5, course6 });
            Student studentThree = new Student("Cristina", new Subject[] { course7, course8, course9 });

            Catalogue catalogue = new Catalogue(new Student[] { student, studentTwo, studentThree });

            catalogue.OrderStudentsByOverallAvg();

            Assert.AreEqual(-1, catalogue.BinarySearch(3, 0, 2));
            Assert.AreEqual(1, catalogue.BinarySearch(2, 0, 2));
            Assert.AreEqual(0, catalogue.BinarySearch(4, 0, 2));

        }

        [TestMethod]
        public void StudentsWithSpecAvg()
        {
            Subject course1 = new Subject("math", new double[] { 1, 3, 5.5, 7 });
            Subject course2 = new Subject("english", new double[] { 2, 5, 4, 3, 6 });
            Subject course3 = new Subject("physics", new double[] { 7, 4, 1, 2, 5 });
            Subject course4 = new Subject("logicDesign", new double[] { 2, 2, 2, 2, 2 });
            Subject course5 = new Subject("french", new double[] { 2, 2, 2, 2 });
            Subject course6 = new Subject("biochemistry", new double[] { 2, 2, 2, 2, 2 });
            Subject course7 = new Subject("informationTheory", new double[] { 2, 2, 2, 2, 2 });
            Subject course8 = new Subject("norwegian", new double[] { 2, 2, 2, 2, 2 });
            Subject course9 = new Subject("electricalEngineering", new double[] { 2, 2, 2, 2, 2 });

            Student student = new Student("Marian", new Subject[] { course1, course2, course3 });
            Student studentTwo = new Student("Stefana", new Subject[] { course4, course5, course6 });
            Student studentThree = new Student("Cristina", new Subject[] { course7, course8, course9 });

            Catalogue catalogue = new Catalogue(new Student[] { student, studentTwo, studentThree });

            CollectionAssert.AreEqual(new Student[] { student }, catalogue.GetStudentsWithSpecAvg(3.975));
            CollectionAssert.AreEqual(new Student[] { studentTwo, studentThree }, catalogue.GetStudentsWithSpecAvg(2));

            catalogue.OrderStudentsByOverallAvg();

            CollectionAssert.AreEqual(new Student[] { student }, catalogue.GetStudentsWithSpecAvg(3.975));
            CollectionAssert.AreEqual(new Student[] { studentTwo, studentThree }, catalogue.GetStudentsWithSpecAvg(2));
        }

        [TestMethod]
        public void NoOfSpecificGrades()
        {
            Subject course1 = new Subject("math", new double[] { 1, 3, 5.5, 7 });
            Subject course2 = new Subject("english", new double[] { 2, 5, 4, 3, 6 });
            Subject course3 = new Subject("physics", new double[] { 7, 4, 1, 2, 5 });
            Subject course4 = new Subject("logicDesign", new double[] { 2, 2, 2, 2, 2 });
            Subject course5 = new Subject("french", new double[] { 2, 2, 2, 2 });
            Subject course6 = new Subject("biochemistry", new double[] { 2, 2, 2, 2, 2 });
            Subject course7 = new Subject("informationTheory", new double[] { 2, 2, 2, 2, 2 });
            Subject course8 = new Subject("norwegian", new double[] { 2, 2, 2, 2, 2 });
            Subject course9 = new Subject("electricalEngineering", new double[] { 2, 2, 2, 2, 2 });

            Student student = new Student("Marian", new Subject[] { course1, course2, course3 });
            Student studentTwo = new Student("Stefana", new Subject[] { course4, course5, course6 });
            Student studentThree = new Student("Cristina", new Subject[] { course7, course8, course9 });


            Assert.AreEqual(1, student.GetNoOfSpecGrade(6));
            
        }

        [TestMethod]
        public void HighestNoOfSpecificGrade()
        {
            Subject course1 = new Subject("math", new double[] { 1, 3, 5, 7 });
            Subject course2 = new Subject("english", new double[] { 2, 5, 4, 3, 6 });
            Subject course3 = new Subject("physics", new double[] { 7, 4, 1, 2, 5 });
            Subject course4 = new Subject("logicDesign", new double[] { 2, 2, 2, 2, 2 });
            Subject course5 = new Subject("french", new double[] { 2, 2, 2, 2 });
            Subject course6 = new Subject("biochemistry", new double[] { 2, 2, 2, 2, 2 });
            Subject course7 = new Subject("informationTheory", new double[] { 3, 2, 2, 2, 2 });
            Subject course8 = new Subject("norwegian", new double[] { 3,3,3,3,3,3 });
            Subject course9 = new Subject("electricalEngineering", new double[] { 2, 2, 2, 2, 2 });

            Student student = new Student("Marian", new Subject[] { course1, course2, course3 });
            Student studentTwo = new Student("Stefana", new Subject[] { course4, course5, course6 });
            Student studentThree = new Student("Cristina", new Subject[] { course7, course8, course9 });

            Catalogue catalogue = new Catalogue(new Student[] { student, studentTwo, studentThree });

            Assert.AreEqual(2, catalogue.GetHighestNoOfSpecGrade(7));
            Assert.AreEqual(14, catalogue.GetHighestNoOfSpecGrade(2));

        }

        [TestMethod]
        public void StudentsWithHighestNoOfSpecificGrade()
        {
            Subject course1 = new Subject("math", new double[] { 1, 3,10, 5, 7 });
            Subject course2 = new Subject("english", new double[] { 2, 5, 4, 3, 6 });
            Subject course3 = new Subject("physics", new double[] { 7, 4, 1, 2,10, 5 });
            Subject course4 = new Subject("logicDesign", new double[] { 2, 2, 2, 2, 2 });
            Subject course5 = new Subject("french", new double[] { 2, 2, 2,8,8, 2 });
            Subject course6 = new Subject("biochemistry", new double[] { 2, 2, 2, 2, 2 });
            Subject course7 = new Subject("informationTheory", new double[] { 3, 2, 2, 2, 2,8 });
            Subject course8 = new Subject("norwegian", new double[] { 3, 3, 3, 3,10, 3, 3,8 });
            Subject course9 = new Subject("electricalEngineering", new double[] { 2, 2,10, 2, 2, 2 });

            Student student = new Student("Marian", new Subject[] { course1, course2, course3 });
            Student studentTwo = new Student("Stefana", new Subject[] { course4, course5, course6 });
            Student studentThree = new Student("Cristina", new Subject[] { course7, course8, course9 });

            Catalogue catalogue = new Catalogue(new Student[] { student, studentTwo, studentThree });

            CollectionAssert.AreEqual(new Student[] { student, studentThree }, catalogue.GetStudentsWithHighestNoOfSpecGrade(10));
            CollectionAssert.AreEqual(new Student[] { studentTwo, studentThree }, catalogue.GetStudentsWithHighestNoOfSpecGrade(8));

        }

        [TestMethod]
        public void LowestOverallAvg()
        {
            Subject course1 = new Subject("math", new double[] { 1, 3, 10, 5, 7 });
            Subject course2 = new Subject("english", new double[] { 2, 5, 4, 3, 6 });
            Subject course3 = new Subject("physics", new double[] { 7, 4, 1, 2, 10, 5 });
            Subject course4 = new Subject("logicDesign", new double[] { 2, 2, 2, 2, 2 });
            Subject course5 = new Subject("french", new double[] { 2, 2, 2, 8, 8, 2 });
            Subject course6 = new Subject("biochemistry", new double[] { 2, 2, 2, 2, 2 });
            Subject course7 = new Subject("informationTheory", new double[] { 3, 2, 2, 2, 2, 8 });
            Subject course8 = new Subject("norwegian", new double[] { 3, 3, 3, 3, 10, 3, 3, 8 });
            Subject course9 = new Subject("electricalEngineering", new double[] { 2, 2, 10, 2, 2, 2 });

            Student student = new Student("Marian", new Subject[] { course1, course2, course3 });
            Student studentTwo = new Student("Stefana", new Subject[] { course4, course5, course6 });
            Student studentThree = new Student("Cristina", new Subject[] { course7, course8, course9 });

            Catalogue catalogue = new Catalogue(new Student[] { student, studentTwo, studentThree });

            Assert.AreEqual(2.66, catalogue.GetLowestOverallAvg(), 2);
        }

        [TestMethod]
        public void StudentsWithLowestOverallAvg()
        {
            Subject course1 = new Subject("math", new double[] { 1, 3, 10, 5, 7 });
            Subject course2 = new Subject("english", new double[] { 2, 5, 4, 3, 6 });
            Subject course3 = new Subject("physics", new double[] { 7, 4, 1, 2, 10, 5 });
            Subject course4 = new Subject("logicDesign", new double[] { 2, 2, 2, 2, 2 });
            Subject course5 = new Subject("french", new double[] { 2, 2, 2, 8, 8, 2 });
            Subject course6 = new Subject("biochemistry", new double[] { 2, 2, 2, 2, 2 });
            Subject course7 = new Subject("informationTheory", new double[] { 3, 2, 2, 2, 2, 8 });
            Subject course8 = new Subject("norwegian", new double[] { 3, 3, 3, 3, 10, 3, 3, 8 });
            Subject course9 = new Subject("electricalEngineering", new double[] { 2, 2, 10, 2, 2, 2 });

            Student student = new Student("Marian", new Subject[] { course1, course2, course3 });
            Student studentTwo = new Student("Stefana", new Subject[] { course4, course5, course6 });
            Student studentThree = new Student("Cristina", new Subject[] { course7, course8, course9 });

            Catalogue catalogue = new Catalogue(new Student[] { student, studentTwo, studentThree });

            Assert.AreEqual(2.66, catalogue.GetLowestOverallAvg(), 2);

            CollectionAssert.AreEqual(new Student[] { studentTwo }, catalogue.GetStudentsWithSpecAvg(catalogue.GetLowestOverallAvg()));
        }





    }
}
