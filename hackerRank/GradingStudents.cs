using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    public class GradingStudents
    {
        public void Execute()
        {
            int[] grades = new int[] { 73, 67, 38, 33};

            int[] result = gradingStudent(grades);

            Console.WriteLine(string.Join("\n", result));
        }

        static int[] gradingStudent(int[] grades)
        {
            const int multiple = 5;
            const int limMax = 2;
            int[] res = new int[grades.Length];
            int newGrade = 0;
            int i = 0;

            foreach (int grade in grades) {
                if (grade >= 38) {
                    newGrade = getNextMultN(grade, multiple, limMax);
                }
                else
                {
                    newGrade = grade;
                }
                res[i] = newGrade;
                i++;
            }

            return res;
        }

        static int getNextMultN(int grade, int multiple, int limMax) {
            int newGrade = grade;
            int count = 0;

            while ((newGrade % multiple) != 0)
            {
                newGrade++;
                count++;
            }

            if (count <= limMax)
            {
                grade = newGrade;
            }

            return grade;
        }

    }
}
