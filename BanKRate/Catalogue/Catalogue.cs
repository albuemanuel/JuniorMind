using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    struct Catalogue
    {
        Student[] students;

        public Catalogue(Student[] students)
        {
            this.students = students;
        }

        public void Swap(int indOne, int indTwo)
        {
            Student temp = students[indOne];
            students[indOne] = students[indTwo];
            students[indTwo] = temp;
        }

        void QuickSort(int st, int end, Student.Comparer comparer)
        {
            if (end - st < 1)
                return;

            int indPiv = Divide(st, end, comparer);

            QuickSort(st, indPiv - 1, comparer);
            QuickSort(indPiv + 1, end, comparer);
        }

        int Divide(int st, int end, Student.Comparer comparer)
        {
            int q = st;

            for (int i = st; i <= end - 1; i++)
            {
                if (students[i].IsFirstSecondOrEqual(students[end], comparer))
                {
                    Swap(q, i);
                    q++;
                }
            }
            Swap(q, end);

            return q;
        }

        public void OrderStudentsAlphabetically() => QuickSort(0, students.Length - 1, Student.Comparer.Name);
        public void OrderStudentsByOverallAvg() => QuickSort(0, students.Length - 1, Student.Comparer.Grades);

        public override string ToString()
        {
            string result = "";

            foreach (Student student in students)
                result += student.ToString();

            return result;
        }

    }
}
