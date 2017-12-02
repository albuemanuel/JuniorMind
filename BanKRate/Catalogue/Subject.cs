using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    struct Subject
    {
        string name;
        double[] grades;

        public Subject(string name, double[] grades)
        {
            this.name = name;
            this.grades = grades;
        }

        public double GetAvg()
        {
            double avg = 0;
            foreach (double grade in grades)
                avg += grade;

            return avg / grades.Length;
        }

        public int GetNoOfSpecGrade(double grade)
        {
            int count = 0;
            foreach(double grd in grades)
            {
                if (grd == grade)
                    count++;
            }
            return count;
        }

        public override string ToString()
        {
            string result = name + ": ";
            for (int i = 0; i < grades.Length - 1; i++)
                result += grades[i].ToString() + ", ";

            result += grades[grades.Length - 1].ToString();

            return result;
        }
    }
}
