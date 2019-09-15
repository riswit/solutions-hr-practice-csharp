using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class EvenTree
    {
        public void Execute()
        {
            //int t_nodes = 10;
            //int t_edges = 9;
            //List<int> t_from = new List<int>();
            //t_from.Add(2);
            //t_from.Add(3);
            //t_from.Add(4);
            //t_from.Add(5);
            //t_from.Add(6);
            //t_from.Add(7);
            //t_from.Add(8);
            //t_from.Add(9);
            //t_from.Add(10);

            //List<int> t_to = new List<int>();
            //t_to.Add(1);
            //t_to.Add(1);
            //t_to.Add(3);
            //t_to.Add(2);
            //t_to.Add(1);
            //t_to.Add(2);
            //t_to.Add(6);
            //t_to.Add(8);
            //t_to.Add(8);

            //int resExp = 2;


            //int t_nodes = 20;
            //int t_edges = 19;
            //List<int> t_from = new List<int>();
            //t_from.Add(2);
            //t_from.Add(3);
            //t_from.Add(4);
            //t_from.Add(5);
            //t_from.Add(6);
            //t_from.Add(7);
            //t_from.Add(8);
            //t_from.Add(9);
            //t_from.Add(10);
            //t_from.Add(11);
            //t_from.Add(12);
            //t_from.Add(13);
            //t_from.Add(14);
            //t_from.Add(15);
            //t_from.Add(16);
            //t_from.Add(17);
            //t_from.Add(18);
            //t_from.Add(19);
            //t_from.Add(20);

            //List<int> t_to = new List<int>();
            //t_to.Add(1);
            //t_to.Add(1);
            //t_to.Add(3);
            //t_to.Add(2);
            //t_to.Add(5);
            //t_to.Add(1);
            //t_to.Add(1);
            //t_to.Add(2);
            //t_to.Add(7);
            //t_to.Add(10);
            //t_to.Add(3);
            //t_to.Add(7);
            //t_to.Add(8);
            //t_to.Add(12);
            //t_to.Add(6);
            //t_to.Add(6);
            //t_to.Add(10);
            //t_to.Add(1);
            //t_to.Add(8);

            //int resExp = 4;


            int t_nodes = 30;
            int t_edges = 29;
            List<int> t_from = new List<int>();
            t_from.Add(2);
            t_from.Add(3);
            t_from.Add(4);
            t_from.Add(5);
            t_from.Add(6);
            t_from.Add(7);
            t_from.Add(8);
            t_from.Add(9);
            t_from.Add(10);
            t_from.Add(11);
            t_from.Add(12);
            t_from.Add(13);
            t_from.Add(14);
            t_from.Add(15);
            t_from.Add(16);
            t_from.Add(17);
            t_from.Add(18);
            t_from.Add(19);
            t_from.Add(20);
            t_from.Add(21);
            t_from.Add(22);
            t_from.Add(23);
            t_from.Add(24);
            t_from.Add(25);
            t_from.Add(26);
            t_from.Add(27);
            t_from.Add(28);
            t_from.Add(29);
            t_from.Add(30);

            List<int> t_to = new List<int>();
            t_to.Add(1);
            t_to.Add(2);
            t_to.Add(3);
            t_to.Add(2);
            t_to.Add(4);
            t_to.Add(4);
            t_to.Add(1);
            t_to.Add(5);
            t_to.Add(4);
            t_to.Add(4);
            t_to.Add(8);
            t_to.Add(2);
            t_to.Add(2);
            t_to.Add(8);
            t_to.Add(10);
            t_to.Add(1);
            t_to.Add(17);
            t_to.Add(18);
            t_to.Add(4);
            t_to.Add(15);
            t_to.Add(20);
            t_to.Add(2);
            t_to.Add(12);
            t_to.Add(21);
            t_to.Add(17);
            t_to.Add(5);
            t_to.Add(27);
            t_to.Add(4);
            t_to.Add(25);

            int resExp = 11;

            int result = evenForest(t_nodes, t_edges, t_from, t_to);

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            }
            else
            {
                Console.WriteLine(result);
                Console.WriteLine("Perfetto!!!");
            }
        }

        static int evenForest(int t_nodes, int t_edges, List<int> t_from, List<int> t_to)
        {
            int res = 0;

            Dictionary<int, List<int>> t = new Dictionary<int, List<int>>();
            List<int> l0 = null;
            int a = 0;
            int b = 0;
            int numT = 0;
            Dictionary<int, Dictionary<int, bool>> arrView = new Dictionary<int, Dictionary<int, bool>>();
            int lent_from = t_from.Count();

            for (int i = 0; i < lent_from; i++)
            {
                a = t_from[i];
                b = t_to[i];

                l0 = getValueMap(t, a);

                if (l0 == null)
                {
                    l0 = new List<int>();
                    l0.Add(b);
                    t.Add(a, l0);
                    numT += 1;

                    Dictionary<int, bool> idb = new Dictionary<int, bool>();
                    idb.Add(b, false);
                    arrView.Add(a, idb);
                }
                else
                {
                    l0.Add(b);
                    t[a] = l0;
                    arrView[a].Add(b, false);
                }

                l0 = getValueMap(t, b);

                if (l0 == null)
                {
                    l0 = new List<int>();
                    l0.Add(a);
                    t.Add(b, l0);
                    numT += 1;

                    Dictionary<int, bool> idb = new Dictionary<int, bool>();
                    idb.Add(a, false);
                    arrView.Add(b, idb);
                }
                else
                {
                    l0.Add(a);
                    t[b] = l0;
                    arrView[b].Add(a, false);
                }
            }

            bool[] arrb = new bool[t_nodes + 1];
            int[] arr = t.Where(e => !e.Key.Equals(1)).Select(x => x.Key).ToArray();
            int tot = 0;
            List<int> list = new List<int>();

            foreach (KeyValuePair<int, List<int>> e in t)
            {
                if (e.Key == 1)
                {
                    continue;
                }
                tot = 0;
                arrb = new bool[t_nodes + 1];
                tot = findTot(tot, e.Key, 0, e.Key, t, arrb);

                if (tot % 2 == 0)
                {
                    list.Add(tot);
                }
            }

            return res;
        }

        static int findTot(int tot, int vfirst, int y, int vCaller, Dictionary<int, List<int>> t, bool[] arrb)
        {
            if (y == 0)
            {
                if (arrb[vfirst])
                {
                    return tot;
                }
                arrb[vfirst] = true;
            }
            else
            {
                if (arrb[y])
                {
                    return tot;
                }
                arrb[y] = true;
            }

            tot += 1;

            int b = 0;
            List<int> l1 = null;
            int caller = 0;

            if (y == 0)
            {
                l1 = new List<int>(t[vfirst]);
                caller = vfirst;
            }
            else
            {
                l1 = new List<int>(t[y]);
                caller = y;
            }
            int lenL1 = l1.Count();

            for (int i = 0; i < lenL1; i++)
            {
                b = l1[i];

                if (b == caller || b == vCaller) { continue; }
                if (b == 1) { caller = 1; tot += 1; continue; }
                tot = findTot(tot, vfirst, b, caller, t, arrb);
            }

            return tot;
        }

        static T getValueMap<T>(Dictionary<int, T> t, int e)
        {
            T v;
            t.TryGetValue(e, out v);
            return v;
        }

    }
}
