using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class MarsExploration
    {
        public void Execute()
        {
            //string s = "SOSSPSSQSSOR";
            //int resExp = 3;

            //string s = "SOSSOT";
            //int resExp = 1;

            //string s = "SOSSOSSOS";
            //int resExp = 0;

            string s = "QQQ";
            int resExp = 3;

            int result = marsExploration(s);

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

        static int marsExploration(string s)
        {
            if (s.Length < 3)
            {
                return 0;
            }

            int res = 0;
            int numMsg = s.Length / 3;
            char[] chArr = s.ToCharArray();

            string strG = "SOS";
            StringBuilder sb = new StringBuilder(strG);

            for (int i = 1; i < numMsg; i++)
            {
                sb.Append(strG);
            }

            res = sb.ToString().ToCharArray().Where((e, i) => !e.Equals(chArr[i])).Count();


            return res;
        }
    }
}
