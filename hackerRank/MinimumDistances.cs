using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class MinimumDistances
    {
        public void Execute()
        {
            int[] a = { 7, 1, 3, 4, 1, 7 };
            int resExp = 3;

            int result = minimumDistances(a);

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

        static int minimumDistances(int[] a)
        {
            int min = 0;
            List<int> list = new List<int>();
            IEnumerable<int> t;

            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] == a[j])
                    {
                        t = list.Where((e, index) => e == a[i]);
                        if (t.Count() == 0)
                        {
                            list.Add(Math.Abs(j - i));
                        }
                    }
                }
            }

            if (list.Count() == 0)
            {
                return -1;
            }

            list.Sort();
            min = list[0];

            return min;
        }
    }
}
