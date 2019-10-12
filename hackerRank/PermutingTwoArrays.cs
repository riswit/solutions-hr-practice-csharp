using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class PermutingTwoArrays
    {
        public void Execute()
        {
            int k = 10;
            int[] A = { 2, 1, 3 };
            int[] B = { 7, 8, 9 };
            string resExp = "YES";

            string result = twoArrays(k, A, B);

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

        static string twoArrays(int k, int[] A, int[] B)
        {
            A = A.OrderBy(x => x).ToArray();
            B = B.OrderByDescending(x => x).ToArray();

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] + B[i] < k)
                {
                    return "NO";
                }
            }

            return "YES";
        }
    }
}
