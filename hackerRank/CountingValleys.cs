using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class CountingValleys
    {
        public void Execute()
        {
            int n = 0;
            string s = "DDUUUUDD";
            int resExp = 1;

            //int n = 0;
            //string s = "UDDDUDUU";
            //int resExp = 1;

            int result = countingValleys(n, s);

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

        static int countingValleys(int n, string s)
        {
            int numValleys = 0;
            int actualLevelSea = 0;
            bool isDownLevelSea = false;

            for (int i = 0; i < s.Length; i++)
            {
                actualLevelSea = setActualLevelSea(actualLevelSea, s.Substring(i, 1));

                if (actualLevelSea < 0)
                {
                    isDownLevelSea = true;
                }
                else
                {
                    if (actualLevelSea == 0)
                    {
                        if (isDownLevelSea)
                        {
                            numValleys++;
                        }
                    }
                    isDownLevelSea = false;
                }
            }

            return numValleys;
        }

        static int setActualLevelSea(int actualLevelSea, string UpDown)
        {
            switch (UpDown)
            {
                case "U":
                    actualLevelSea++;
                    break;
                case "D":
                    actualLevelSea--;
                    break;
            }
            return actualLevelSea;
        }
    }
}
