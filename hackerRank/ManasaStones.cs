using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class ManasaStones
    {
        public void Execute()
        {
            //int n = 3;
            //int a = 2;
            //int b = 1;
            //int[] resExp = { 2, 3, 4 };

            //int n = 4;
            //int a = 10;
            //int b = 100;
            //int[] resExp = { 30, 120, 210, 300 };

            //int n = 7;
            //int a = 9;
            //int b = 11;
            //int[] resExp = { 54, 56, 58, 60, 62, 64, 66 };

            //int n = 58;
            //int a = 69;
            //int b = 24;
            //int[] resExp = { 1368, 1413, 1458, 1503, 1548, 1593, 1638, 1683, 1728, 1773, 1818, 1863, 1908, 1953, 1998, 2043, 2088, 2133, 2178, 2223, 2268, 2313, 2358, 2403, 2448, 2493, 2538, 2583, 2628, 2673, 2718, 2763, 2808, 2853, 2898, 2943, 2988, 3033, 3078, 3123, 3168, 3213, 3258, 3303, 3348, 3393, 3438, 3483, 3528, 3573, 3618, 3663, 3708, 3753, 3798, 3843, 3888, 3933 };

            //int n = 83;
            //int a = 86;
            //int b = 81;
            //int[] resExp = { 6642, 6647, 6652, 6657, 6662, 6667, 6672, 6677, 6682, 6687, 6692, 6697, 6702, 6707, 6712, 6717, 6722, 6727, 6732, 6737, 6742, 6747, 6752, 6757, 6762, 6767, 6772, 6777, 6782, 6787, 6792, 6797, 6802, 6807, 6812, 6817, 6822, 6827, 6832, 6837, 6842, 6847, 6852, 6857, 6862, 6867, 6872, 6877, 6882, 6887, 6892, 6897, 6902, 6907, 6912, 6917, 6922, 6927, 6932, 6937, 6942, 6947, 6952, 6957, 6962, 6967, 6972, 6977, 6982, 6987, 6992, 6997, 7002, 7007, 7012, 7017, 7022, 7027, 7032, 7037, 7042, 7047, 7052 };

            //int n = 73;
            //int a = 25;
            //int b = 25;
            //int[] resExp = { 1800 };

            int n = 2;
            int a = 1;
            int b = 1;
            int[] resExp = { 1 };

            int[] result = stones(n, a, b);

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

        static int[] stones(int n, int a, int b)
        {
            if (n == 1)
            {
                return new int[] { 0 };
            }
            if (n == 2)
            {
                if (a != b)
                {
                    return new int[] { a, b };
                }
                return new int[] { a };
            }

            List<int> listRes = new List<int>();
            int lastNumCaseA = a * (n - 1);
            int lastNumCaseB = b * (n - 1);

            int step = Math.Abs(a - b);

            if (step == 0)
            {
                return new int[] { (a * (n - 1)) };
            }

            int start = 0;
            int finish = 0;

            if (lastNumCaseA <= lastNumCaseB)
            {
                start = lastNumCaseA;
                finish = lastNumCaseB;
            }
            else
            {
                start = lastNumCaseB;
                finish = lastNumCaseA;
            }

            for (int i = start; i <= finish; i += step)
            {
                listRes.Add(i);
            }

            return listRes.ToArray();
        }
    }
}
