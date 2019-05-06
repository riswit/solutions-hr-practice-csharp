using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class SequenceEquation
    {
        public void Execute()
        {
            //int[] p = { 5, 2, 1, 3, 4 };
            //int[] resExp = { 4, 2, 5, 1, 3 };

            int[] p = { 4, 3, 5, 1, 2 };
            int[] resExp = { 1, 3, 5, 4, 2 };

            int[] result = permutationEquation(p);

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore - Expected: " + string.Join(" ", resExp) + " - now: " + string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
            }
        }

        static int[] permutationEquation(int[] p)
        {
            int[] res = new int[p.Length];
            int y = 0;
            int ir = 0;

            for (int n = 1; n <= p.Length; n++)
            {
                for (int i = 0; i < p.Length; i++)
                {
                    if (n == p[i])
                    {
                        for (int j = 0; j < p.Length; j++)
                        {
                            if (p[j] == (i + 1))
                            {
                                y = j + 1;
                                res[ir] = y;
                                ir++;
                                break;
                            }
                        }
                        break;
                    }
                }
            }

            return res;
        }


    }
}
