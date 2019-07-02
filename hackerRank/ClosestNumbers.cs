using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class ClosestNumbers
    {
        public void Execute()
        {
            //int[] arr = { -20, -3916237, -357920, -3620601, 7374819, -7330761, 30, 6246457, -6461594, 266854 };
            //int[] resExp = { -20, 30 };

            //int[] arr = { -20, -3916237, -357920, -3620601, 7374819, -7330761, 30, 6246457, -6461594, 266854, -520, -470 };
            //int[] resExp = { -520, -470, -20, 30 };

            int[] arr = { 5, 4, 3, 2 };
            int[] resExp = { 2, 3, 3, 4, 4, 5 };

            int[] result = closestNumbers(arr);

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

        static int[] closestNumbers(int[] arr)
        {
            Dictionary<int, int> t = (from a in arr.GroupBy(x => x) orderby a.Key select a).ToDictionary(
                                                                                        p => p.Key,
                                                                                        p => p.Count()
                                                                                        );

            var t1 = t.Aggregate(new List<int[]>(), (prev, val) => calc(prev, val));

            var t2 = from a in t1 orderby a[2] select a;

            List<int> res = new List<int>();
            int prec = 0;

            foreach (int[] e in t2)
            {
                if (e[2] != 0)
                {
                    if (e[2] != prec && prec != 0)
                    {
                        break;
                    }
                    res.Add(e[0]);
                    res.Add(e[1]);

                    prec = e[2];
                }
            }

            return res.ToArray();
        }

        static List<int[]> calc(List<int[]> prev, KeyValuePair<int, int> val)
        {
            if (prev.Count() == 0)
            {
                prev.Add(new int[3] { val.Key, 0, 0 });
                return prev;
            }

            int lastN1 = prev[prev.Count() - 1][0];

            if (prev.Count() == 1)
            {
                prev.Add(new int[3] { lastN1, val.Key, val.Key - lastN1 });
                return prev;
            }

            int lastN2 = prev[prev.Count() - 1][1];

            prev.Add(new int[3] { lastN2, val.Key, val.Key - lastN2 });

            return prev;
        }

    }
}
