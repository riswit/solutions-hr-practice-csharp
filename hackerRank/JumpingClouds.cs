using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class JumpingClouds
    {
        public void Execute()
        {
            //int[] c = { 0, 0, 1, 0, 0, 1, 1, 0 };
            //int k = 2;

            int[] c = { 0, 0, 1, 0 };
            int k = 2;

            int resExp = 96;

            int result = jumpingOnClouds(c, k);

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

        static int jumpingOnClouds(int[] c, int k)
        {
            int e = 100;
            
            for (int i = 0; i < c.Length; i += k)
            {
                e--;
                if ((i + k) <= (c.Length - 1))
                {
                    if (c[i + k] == 1)
                    {
                        e = e - 2;
                    }
                }
                else
                {
                    if (c[0] == 1)
                    {
                        e = e - 2;
                    }
                }
            }

            return e;
        }

    }
}
