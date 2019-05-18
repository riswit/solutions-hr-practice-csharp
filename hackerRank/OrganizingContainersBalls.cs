using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class OrganizingContainersBalls
    {
        public void Execute()
        {
            //int[][] container = new int[][] {
            //    new int[] { 0, 2, 1 },
            //    new int[] { 1, 1, 1 },
            //    new int[] { 2, 0, 0 }
            //};
            //string resExp = "Possible";

            //int[][] container = new int[][] {
            //    new int[] { 1, 3, 1 },
            //    new int[] { 2, 1, 2 },
            //    new int[] { 3, 3, 3 }
            //};
            //string resExp = "Impossible";

            //int[][] container = new int[][] {
            //    new int[] { 0, 2 },
            //    new int[] { 1, 1 }
            //};
            //string resExp = "Impossible";

            //int[][] container = new int[][] {
            //    new int[] { 999336263, 998799923 },
            //    new int[] { 998799923, 999763019 }
            //};
            //string resExp = "Possible";

            //int[][] container = new int[][] {
            //    new int[] { 999789250, 999886349 },
            //    new int[] { 999654053, 999789250 }
            //};
            //string resExp = "Possible";

            //int[][] container = new int[][] {
            //    new int[] { 997612619, 934920795 ,998879231 ,999926463 },
            //    new int[] { 960369681, 997828120, 999792735, 979622676 },
            //    new int[] { 999013654, 998634077, 997988323 ,958769423 },
            //    new int[] { 997409523, 999301350, 940952923 ,993020546 }
            //};
            //string resExp = "Possible";

            int[][] container = new int[][] {
                new int[] { 997612619, 934920795 ,998879231 ,999926463 },
                new int[] { 960369681, 997828120, 999792735, 979622676 },
                new int[] { 999013654, 998634077, 997988323 ,958769423 },
                new int[] { 997409523, 999301350, 940952923 ,993020546 }
            };
            string resExp = "Possible";

            string result = organizingContainers(container);

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

        static string organizingContainers(int[][] container)
        {
            if (container.Length <= 1)
            {
                return "Possible";
            }

            long sumRow = 0;
            long sumCol = 0;
            List<long> listTotalsRow = new List<long>();
            List<long> listTotalsCol = new List<long>();

            for (int i = 0; i < container.Length; i++)
            {
                sumRow = 0;
                for (int j = 0; j < container.Length; j++)
                {
                    sumRow += container[i][j];
                }
                listTotalsRow.Add(sumRow);
            }

            for (int j = 0; j < container.Length; j++)
            {
                sumCol = 0;

                for (int i = 0; i < container.Length; i++)
                {
                    sumCol += container[i][j];
                }
                listTotalsCol.Add(sumCol);
            }

            listTotalsRow.Sort();
            listTotalsCol.Sort();

            for (int i = 0; i < listTotalsCol.Count(); i++)
            {
                if (listTotalsCol[i] != listTotalsRow[i])
                {
                    return "Impossible";
                }
            }

            return "Possible";
        }

        static string organizingContainers1(int[][] container)
        {
            if (container.Length <= 1)
            {
                return "Impossible";
            }

            long sumRow = 0;
            long sumCol = 0;
            List<long> listTotalsRow = new List<long>();
            List<long> listTotalsCol = new List<long>();

            for (int i = 0; i < container.Length; i++)
            {
                sumRow = 0;
                for (int j = 0; j < container.Length; j++)
                {
                    sumRow += container[i][j];
                }
                listTotalsRow.Add(sumRow);
            }

            for (int j = 0; j < container.Length; j++)
            {
                sumCol = 0;

                for (int i = 0; i < container.Length; i++)
                {
                    sumCol += container[i][j];
                }
                listTotalsCol.Add(sumCol);
            }

            listTotalsRow.Sort();

            for (int i = 0; i < listTotalsRow.Count() - 1; i++)
            {
                for (int j = i + 1; j < listTotalsRow.Count(); j++)
                {
                    if (listTotalsRow[j] - listTotalsRow[i] > 0
                        && (listTotalsRow[j] - listTotalsRow[i]) % 2 == 0)
                    {
                        return "Impossible";
                    }
                }
            }

            listTotalsCol.Sort();

            for (int i = 0; i < listTotalsCol.Count() - 1; i++)
            {
                for (int j = i + 1; j < listTotalsCol.Count(); j++)
                {
                    if (listTotalsCol[j] - listTotalsCol[i] > 0
                        && (listTotalsCol[j] - listTotalsCol[i]) % 2 == 0)
                    {
                        return "Impossible";
                    }
                }
            }

            return "Possible";
        }


    }
}
