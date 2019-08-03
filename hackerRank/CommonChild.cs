using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class CommonChild
    {
        public void Execute()
        {
            string s1 = "HARRY";
            string s2 = "SALLY";
            int resExp = 2;

            int result = commonChild(s1, s2);

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
                Console.WriteLine(result);
            }
        }

        static int commonChild(string s1, string s2)
        {
            int[,] c = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++) { c[i, 0] = 0; c[0, i] = 0; }

            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        c[i + 1, j + 1] = c[i, j] + 1;
                    }
                    else
                    {
                        c[i + 1, j + 1] = c[i + 1, j] > c[i, j + 1] ? c[i + 1, j] : c[i, j + 1];
                    }
                }
            }

            return c[s1.Length, s1.Length];
        }
    }
}
