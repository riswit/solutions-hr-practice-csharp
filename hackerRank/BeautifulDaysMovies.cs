using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class BeautifulDaysMovies
    {
        public void Execute()
        {
            int i = 20;
            int j = 23;
            int k = 6;
            int resExp = 2;

            int result = beautifulDays(i, j, k);

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

        static int beautifulDays(int i, int j, int k)
        {
            int numBeautifulDays = 0;


            for (int n = i; n <= j; n++)
            {
                if (isBeautifulDays(n, k))
                {
                    numBeautifulDays++;
                }
            }

            return numBeautifulDays;
        }

        static bool isBeautifulDays(int n, int k)
        {
            int reverseNum = getReverseNum(n);

            if (((n - reverseNum) % k) == 0)
            {
                return true;
            } 

            return false;
        }

        static int getReverseNum(int n)
        {
            string rev = n.ToString();
            string numOutRev = "";

            for (int i = rev.Length; i > 0; i--)
            {
                numOutRev += rev.Substring(i - 1, 1);
            }

            return int.Parse(numOutRev);
        }
    }
}
