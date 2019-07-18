using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class MakingAnagrams
    {
        public void Execute()
        {
            string s1 = "absdjkvuahdakejfnfauhdsaavasdlkj";
            string s2 = "djfladfhiawasdkjvalskufhafablsdkashlahdfa";
            int resExp = 19;

            int result = makingAnagrams(s1, s2);

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

        static int makingAnagrams(string s1, string s2)
        {
            int res = 0;

            char[] left = s1.ToCharArray();
            char[] right = s2.ToCharArray();
            int pos = 0;

            for (int i = 0; i < s1.Length; i++)
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

            right = s2.ToCharArray();
            for (int i = 0; i < s2.Length; i++)
            {
                pos = Array.IndexOf(left, right[i]);

                if (pos < 0)
                {
                    res += 1;
                }
                else
                {
                    left[pos] = '_';
                }
            }

            return res;
        }
    }
}
