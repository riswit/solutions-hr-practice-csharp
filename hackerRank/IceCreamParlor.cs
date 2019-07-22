using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class IceCreamParlor
    {
        public void Execute()
        {
            int m = 0;
            int[] arr = { 10, 5, 20, 20, 4, 5, 2, 25, 1 };
            int[] resExp = { 2, 4 };

            int[] result = icecreamParlor(m, arr);

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore - Expected: " + string.Join(" ", resExp) + " - now: " + string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
            }

            Console.WriteLine(string.Join(" ", result));
        }

        static int[] icecreamParlor(int m, int[] arr)
        {
            int[] res = new int[2];
            int c = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    c = arr[i] + arr[j];
                    if (c == m)
                    {
                        res[0] = i + 1;
                        res[1] = j + 1;
                        return res;
                    }
                }
            }

            return res;
        }
    }
}
