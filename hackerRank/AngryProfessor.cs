using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class AngryProfessor
    {
        public void Execute()
        {
            //int k = 3;
            //int[] a = { -1, -3, 4, 2 };
            //string resExp = "YES";

            int k = 2;
            int[] a = { 0, -1, 2, 1 };
            string resExp = "NO";

            string result = angryProfessor(k, a);

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
            }

            Console.WriteLine(result);
        }

        static string angryProfessor(int k, int[] a)
        {
            string cancelled = "NO";
            int totAttendance = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] <= 0)
                {
                    totAttendance++;
                }
            }

            if (totAttendance < k)
            {
                cancelled = "YES";
            }

            return cancelled;
        }

    }
}
