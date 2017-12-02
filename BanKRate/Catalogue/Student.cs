using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    struct Student
    {
        string name;
        Subject[] subs;

        public Student(string name, Subject[] subs)
        {
            this.name = name;
            this.subs = subs;
        }

        public Student(string name)
        {
            this.name = name;
            subs = new Subject[0];
        }

        public enum Comparer
        {
            Name,
            Grades
        }

        public double GetOverallAvg()
        {
            double avg = 0;
            foreach (Subject sub in subs)
                avg += sub.GetAvg();

            return avg / subs.Length;
        }

        public bool IsFirstSecondOrEqual(Student otherStudent, Comparer comparer)
        {
            if (comparer == Comparer.Name)
            {
                return (name[0] <= otherStudent.name[0]);
            }
            else
            {
                return (GetOverallAvg() >= otherStudent.GetOverallAvg());
            }
        }

        public int GetNoOfSpecGrade(double grade)
        {
            int count = 0;

            foreach (Subject sub in subs)
                count += sub.GetNoOfSpecGrade(grade);

            return count;
        }

        public override string ToString()
        {
            string result = name + ':'+ '\n';

            for(int i=0; i<subs.Length; i++)
            {
                result += subs[i].ToString() + '\n';
            }
            result += '\n';

            return result;
        }
    }
}
