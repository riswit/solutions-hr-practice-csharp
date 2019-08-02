using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class SherlockAnagrams
    {
        public void Execute()
        {
            //string s = "kkkk";
            //int resExp = 10;

            //string s = "ifailuhkqq";
            //int resExp = 3;

            //string s = "abba";
            //int resExp = 4;

            //string s = "abcd";
            //int resExp = 0;

            string s = "bcbabbaccacbacaacbbaccbcbccbaaaabbbcaccaacaccbabcbabccacbaabbaaaabbbcbbbbbaababacacbcaabbcbcbcabbaba";
            int resExp = 11577;

            int result = sherlockAndAnagrams(s);

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

        static int sherlockAndAnagrams(string s)
        {
            int res = 0;
            int i0 = 1;
            string s1 = "";
            string s2 = "";

            while (i0 < s.Length)
            {
                for (int i = 0; i + i0 - 1 < s.Length - 1; i++)
                {
                    for (int j = i + 1; j + i0 - 1 < s.Length; j++)
                    {
                        s1 = s.Substring(i, i0);
                        s2 = s.Substring(j, i0);
                        if (s1.Equals(s2))
                        {
                            res += 1;
                        }
                        else
                        {
                            if (isAnagrams(s1, s2))
                            {
                                res += 1;
                            }
                        }
                    }
                }

                i0++;
            }

            return res;
        }

        static bool isAnagrams(string s1, string s2)
        {
            char[] left = s1.ToCharArray();
            char[] right = s2.ToCharArray();
            int pos = 0;

            for (int i = 0; i < s1.Length; i++)
            {
                pos = Array.IndexOf(right, left[i]);

                if (pos < 0)
                {
                    return false;
                }
                else
                {
                    right[pos] = '_';
                }
            }

            return true;
        }
    }
}
