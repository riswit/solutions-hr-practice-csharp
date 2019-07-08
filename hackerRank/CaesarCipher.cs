using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class CaesarCipher
    {
        public void Execute()
        {
            string s = "middle-Outz";
            int k = 28;
            string resExp = "okffng-Qwvb";

            string result = caesarCipher(s, k);

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

        static string caesarCipher(string s, int k)
        {
            char[] alp = ("abcdefghijklmnopqrstuvwxyz").ToCharArray();
            int numShift = k;
            double t = 0;

            if (k > alp.Length)
            {
                t = k / alp.Length;
                numShift = k - ((int)Math.Floor(t) * alp.Length);
            }

            if (numShift == 0)
            {
                return s;
            }

            char[] alpC = alp.Where((e, i) => i > numShift - 1)
                .Concat(alp.Where((e, i) => i <= numShift - 1)).ToArray();

            string res = String.Join("", s.Select(e => transf(e, alp, alpC)).ToArray());

            return res;
        }

        static char transf(char e, char[] alp, char[] alpC)
        {
            bool isUpper = false;
            if (Char.IsUpper(e))
            {
                isUpper = true;
                e = Char.ToLower(e);
            }
            int ind = Array.FindIndex(alp, x => x == e);

            if (ind < 0)
            {
                return e;
            }
            if (isUpper)
            {
                return Char.ToUpper(alpC[ind]);
            }

            return alpC[ind];
        }
    }
}
