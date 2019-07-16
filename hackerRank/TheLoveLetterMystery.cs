using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class TheLoveLetterMystery
    {
        public void Execute()
        {
            string s = "abcba";
            int resExp = 0;

            int result = theLoveLetterMystery(s);

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

        static int theLoveLetterMystery(string s)
        {
            int res = 0;

            int posStart = 0;
            int posEnd = s.Length - 1;

            while (posStart < posEnd)
            {
                res += Math.Abs(Convert.ToInt32(s[posStart]) - Convert.ToInt32(s[posEnd]));

                posStart += 1;
                posEnd -= 1;
            }

            return res;
        }
    }
}
