using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class RepeatedString
    {
        public void Execute()
        {
            //string s = "aba";
            //long n = 10;
            //long resExp = 7;

            //string s = "abacab";
            //long n = 5;
            //long resExp = 3;

            string s = "a";
            long n = 1000000000000;
            long resExp = 1000000000000;

            long result = repeatedString(s, n);

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

        static long repeatedString(string s, long n)
        {
            char a = 'a';
            
            if (n <= s.Length)
            {
                return s.Where((str, index) => str == a && index <= n).Count();
            }

            long numRepeatS = n / s.Length;
            long pos = 0;

            if (n % s.Length != 0)
            {
                pos = n - (numRepeatS * s.Length);
            }

            int numAInS = s.Where((str, index) => str == a).Count();

            long numATot = numAInS * numRepeatS; 
            if (pos > 0)
            {
                numATot += s.Where((str, index) => str == a && index <= (pos - 1)).Count();
            }

            return numATot;
        }

    }
}
