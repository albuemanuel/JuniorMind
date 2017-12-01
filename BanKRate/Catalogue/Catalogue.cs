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

        void AddStudent(ref Student[] list, int index)
        {
            Array.Resize(ref list, list.Length + 1);

            list[list.Length - 1] = students[index];
        }

        int GetFirstOccurence(int index)
        {
            if (index == 0)
                return index;

            double grade = students[index].GetOverallAvg();

            int i = index;

            while (students[i].GetOverallAvg() == grade)
                i--;

            return i + 1;
        }

        public int BinarySearch(double avg, int st, int end)
        {
            if (st > end)
                return -1;

            int mid = (st+end) / 2;

            if (avg == students[mid].GetOverallAvg())
                return GetFirstOccurence(mid);

            return avg > students[mid].GetOverallAvg() ? BinarySearch(avg, st, mid-1) : BinarySearch(avg, mid+1, end);

        }

        public bool IsOrderedByAvg()
        {
            for (int i = 0; i < students.Length - 1; i++)
            {
                if (students[i].GetOverallAvg() < students[i + 1].GetOverallAvg())
                    return false;
            }
            return true;
        }

        public Student[] GetStudentsWithSpecAvg(double avg)
        {
            Student[] wantedStudents = new Student[0];
            if (IsOrderedByAvg())
            {
                int index = BinarySearch(avg, 0, students.Length - 1);
                if (index != -1)
                    for (int i = index; i < students.Length && students[i].GetOverallAvg() == avg; i++)
                        AddStudent(ref wantedStudents, i);
            }
            else
                for (int i = 0; i < students.Length; i++)
                {
                    if (students[i].GetOverallAvg() == avg)
                        AddStudent(ref wantedStudents, i);
                }

            return wantedStudents;
        }

    }
}
