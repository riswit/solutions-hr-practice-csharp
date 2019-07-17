using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class PalindromeIndex
    {
        public void Execute()
        {
            string s = "aaa";
            int resExp = -1;

            int result = palindromeIndex(s);

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

        static int palindromeIndex(string s)
        {
            int res = 0;
            int ch = 0;
            int posStart = 0;
            int posEnd = s.Length - 1;

            while (posStart < posEnd)
            {
                if (!s[posStart].Equals(s[posEnd]))
                {
                    ch++;

                    if (isPal(s, posStart, posEnd - 1))
                    {
                        return posEnd;
                    }

                    if (isPal(s, posStart + 1, posEnd))
                    {
                        return posStart;
                    }
                    return -1;
                }

                posStart += 1;
                posEnd -= 1;
            }
            if (ch == 0)
            {
                return -1;
            }
            return res;
        }

        static bool isPal(string s, int posStart, int posEnd)
        {
            int ch = 0;
            while (posStart < posEnd)
            {
                if (!s[posStart].Equals(s[posEnd]))
                {
                    return false;
                }

                ch += 1;

                posStart += 1;
                posEnd -= 1;
            }
            if (ch > 0)
            {
                return true;
            }
            return false;
        }
    }
}
