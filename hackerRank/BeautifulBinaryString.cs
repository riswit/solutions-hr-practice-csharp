using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class BeautifulBinaryString
    {
        public void Execute()
        {
            //string s = "AAAA";
            //int resExp = 3;

            string s = "0101010";
            int resExp = 2;

            //string s = "0100101010";
            //int resExp = 3;

            int result = beautifulBinaryString(s);

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

        static int beautifulBinaryString(string b)
        {
            int res = 0;

            int ind = b.IndexOf("010");

            while (ind < b.Length && ind > -1)
            {
                res += 1;
                ind = b.IndexOf("010", ind + 3);
            }

            return res;
        }
    }
}
