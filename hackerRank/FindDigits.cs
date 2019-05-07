using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class FindDigits
    {
        public void Execute()
        {
            //int n = 111;
            //int resExp = 3;

            //int n = 12;
            //int resExp = 2;

            int n = 1012;
            int resExp = 3;

            int result = findDigits(n);

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

        static int findDigits(int n)
        {
            int numDivisors = 0;
            string nString = n.ToString();
            int d = 0;

            for (int i = 0; i < nString.Length; i++)
            {
                d = int.Parse(nString.Substring(i, 1));

                if (d != 0)
                {
                    if ((n % d) == 0)
                    {
                        numDivisors++;
                    }
                }
            }

            return numDivisors;
        }

    }
}
