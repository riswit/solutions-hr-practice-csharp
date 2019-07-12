using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class FunnyString
    {
        public void Execute()
        {
            //string s = "acxz";
            //string resExp = "Funny";

            string s = "bcxz";
            string resExp = "Not Funny";

            string result = funnyString(s);

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

        static string funnyString(string s)
        {
            byte[] aB = Encoding.ASCII.GetBytes(s);
            byte[] rAB = aB.Reverse().ToArray();

            for (int i = 1; i < aB.Length; i++)
            {
                if (Math.Abs(aB[i] - aB[i - 1]) != Math.Abs(rAB[i] - rAB[i - 1]))
                {
                    return "Not Funny";
                }
            }

            return "Funny";
        }
    }
}
