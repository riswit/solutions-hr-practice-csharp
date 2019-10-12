using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class JimOrders
    {
        public void Execute()
        {
            int[][] orders = new int[][] {
                new int[] { 8, 1 },
                new int[] { 4, 2 },
                new int[] { 5, 6 },
                new int[] { 3, 1 },
                new int[] { 4, 3 }
            };
            int[] resExp = { 4, 2, 5, 1, 3 };

            int[] result = jimOrders(orders);

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

        static int[] jimOrders(int[][] orders)
        {
            int[][] r = new int[orders.Length][];

            for (int i = 0; i < orders.Length; i++)
            {
                int[] a = new int[2];

                a[0] = i + 1;
                a[1] = orders[i][0] + orders[i][1];
                r[i] = a;
            }

            return r.OrderBy(e => e[1]).Select(x => x[0]).ToArray();
        }
    }
}
