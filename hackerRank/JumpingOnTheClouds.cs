using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class JumpingOnTheClouds
    {
        public void Execute()
        {
            //int[] c = { 0, 0, 1, 0, 0, 1, 0 };
            //int resExp = 4;

            //int[] c = { 0, 0, 0, 0, 1, 0 };
            //int resExp = 3;

            int[] c = { 0,1,0,0,0,0,0,1,0,1,0,0,0,1,0,0,1,0,1,0,0,0,0,1,0,0,1,0,0,1,0,1,0,1,0,1,0,0,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,0,0,1,0,1,0,0,0,1,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,1,0,1,0,1,0,1,0,0,0,0,0,0,1,0,0,0 };
            int resExp = 53;

            int result = jumpingOnClouds(c);

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

        static int jumpingOnClouds(int[] c)
        {
            int numJ = 0;
            int pos1 = 0;
            int i = 0;

            while (i < c.Length)
            {
                if (i == c.Length - 1)
                {
                    i += 1;
                    break;
                }

                if (c[i + 1] == 1)
                {
                    i += 2;
                    numJ++;
                }
                else
                {
                    if (i + 2 < c.Length - 2)
                    {
                        if (c[i + 2] == 0)
                        {
                            i += 2;
                            numJ++;
                        }
                        else
                        {
                            i += 1;
                            numJ++;
                        }
                    }
                    else
                    {
                        i += 2;
                        numJ++;
                    }
                }

            }

            return numJ;
        }

    }
}
