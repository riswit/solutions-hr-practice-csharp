using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class ArraysDS
    {
        public void Execute()
        {
            int[] a = { 10, 5, 20, 20, 4, 5, 2, 25, 1 };
            int[] resExp = { 2, 4 };

            int[] result = reverseArray(a);

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore - Expected: " + string.Join(" ", resExp) + " - now: " + string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
                Console.WriteLine(string.Join(" ", result));
            }
        }

        static int[] reverseArray(int[] a)
        {
            int[] res = a.Reverse().ToArray();

            return res;
        }
    }
}
