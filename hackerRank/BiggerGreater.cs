using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class BiggerGreater
    {
        public void Execute()
        {
            //string w = "lmno";
            //string resExp = "lmon";

            //string w = "dcba";
            //string resExp = "no answer";

            //string w = "fedcbabcd";
            //string resExp = "fedcbabdc";

            //string w = "dkhc";
            //string resExp = "hcdk";

            //string w = "ab";
            //string resExp = "ba";

            //string w = "abdc";
            //string resExp = "acbd";

            string w = "biehzcmjckznhwrfgglverxsezxuqpj";
            string resExp = "biehzcmjckznhwrfgglverxsjepquxz";

            string result = biggerIsGreater(w);

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

        static string biggerIsGreater(string w)
        {
            char[] cStr = w.ToCharArray();

            bool isNoAnswer = true;

            for (int i = 0; i < cStr.Length - 1; i++)
            {
                for (int j = i + 1; j < cStr.Length; j++)
                {
                    if (cStr[i].CompareTo(cStr[j]) < 0)
                    {
                        isNoAnswer = false;
                        break;
                    }
                }
            }

            if (isNoAnswer)
            {
                return "no answer";
            }

            string res = "";
            int posSwap = 0;
            IEnumerable<char> leftChr = Enumerable.Empty<char>();
            IEnumerable<char> rightChr = Enumerable.Empty<char>();
            string sx = "";
            string dx = "";

            int p = 0;
            for (p = cStr.Length - 1; p > 0; p--)
            {
                if (cStr[p].CompareTo(cStr[p - 1]) > 0)
                {
                    posSwap = p;
                    break;
                }
            }

            if (posSwap < cStr.Length - 1)
            {
                rightChr = cStr.Where((elem, index) => index > posSwap);
                dx = new string(rightChr.ToArray());
            }

            if (posSwap > 1)
            {
                leftChr = cStr.Where((elem, index) => index < posSwap - 1);
                sx = new string(leftChr.ToArray());
            }

            if (posSwap == cStr.Count() - 1)
            {
                dx += cStr[posSwap - 1];
                dx.ToList().Sort();

                res = sx + cStr[posSwap] + dx;
            }
            else
            {
                rightChr = cStr.Where((e, index) => index >= posSwap);
                List<char> list = new List<char>(rightChr);
                char f = cStr[posSwap - 1];
                list.Sort();
                int indFirst = 0;
                for (int i = 0; i < list.Count(); i++)
                {
                    if (f.CompareTo(list[i]) < 0)
                    {
                        indFirst = i;
                        break;
                    }
                }

                res = sx;
                res += list[indFirst];
                list.RemoveAt(indFirst);
                list.Add(f);
                list.Sort();

                for (int e = 0; e < list.Count(); e++)
                {
                    res += list[e].ToString();
                }
            }

            return res;
        }

    }
}
