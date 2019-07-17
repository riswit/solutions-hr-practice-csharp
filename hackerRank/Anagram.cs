using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class Anagram
    {
        public void Execute()
        {
            string s = "xulkowreuowzxgnhmiqekxhzistdocbnyozmnqthhpievvlj";
            int resExp = 13;

            int result = anagram(s);

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

        static int anagram(string s)
        {
            if (s.Length % 2 != 0)
            {
                return -1;
            }
            int res = 0;

            int m = s.Length / 2;

            string strLeft = s.Substring(0, m);
            string strRight = s.Substring(m);

            char[] left = strLeft.ToCharArray();
            char[] right = strRight.ToCharArray();
            int pos = 0;
            int ll = left.Count();

            for (int i = 0; i < ll; i++)
            {
                pos = Array.IndexOf(right, left[i]);

                if (pos < 0)
                {
                    res += 1;
                }
                else
                {
                    right[pos] = '_';
                }
            }

            return res;
        }

        static int anagram_SLOW(string s)
        {
            if (s.Length % 2 != 0)
            {
                return -1;
            }
            int res = 0;

            int m = s.Length / 2;

            string strLeft = s.Substring(0, m);
            string strRight = s.Substring(m);

            char[] left = strLeft.ToCharArray();
            char[] right = strRight.ToCharArray();
            int pos = 0;
            int ll = left.Count();

            for (int i = 0; i < ll; i++)
            {
                pos = Array.IndexOf(strRight.ToCharArray(), left[i]);

                if (pos < 0)
                {
                    res += 1;
                }
                else
                {
                    strRight = strRight.Substring(0, pos) + strRight.Substring(pos + 1);
                }
            }

            return res;
        }

        //var t = left.Intersect(right);
        //var tr = right.Intersect(left);
        //int c = t.Count();
        //if (c == 0)
        //{
        //    return left.Count();
        //}
        //var d = left.Except(t);
        //res = d.Count();

    }
}
