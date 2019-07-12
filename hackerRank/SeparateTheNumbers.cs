using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class SeparateTheNumbers
    {
        public void Execute()
        {
            //string s = "91011";
            //string s = "1234";
            //string s = "99100";
            //string s = "101103";
            //string s = "010203";
            string s = "10001001100210031004100510061007";

            separateNumbers(s);
        }

        static void separateNumbers(string s)
        {
            if (s.Length == 1 || s[0].Equals("0"))
            {
                Console.WriteLine("NO");
                return;
            }

            int n = 0;
            int d = 2;
            long st = 0;
            string strInit = "";
            string strTest = "";
            if (s.Length % d == 0)
            {
                n = s.Length / d;
            }
            else
            {
                n = (s.Length - 1) / d;
            }

            for (int i = 1; i <= n; i++)
            {
                strInit = s.Substring(0, i);
                st = long.Parse(strInit);
                strTest = "";
                for (long j = st; strTest.Length < s.Length; j++)
                {
                    strTest += j.ToString();
                }

                if (strTest.Equals(s))
                {
                    Console.WriteLine("YES " + strInit);
                    return;
                }
            }

            Console.WriteLine("NO");
            return;

        }


        //static void separateNumbers_OLD(string s)
        //{
        //    if (s.Length == 1 || s[0].Equals("0"))
        //    {
        //        Console.WriteLine("NO");
        //        return;
        //    }

        //    int[] arrN = s.Select(e => int.Parse(e.ToString())).ToArray();

        //    int i = 1;
        //    int n = 0;
        //    int d = 2;

        //    if (s.Length % d == 0)
        //    {
        //        n = s.Length / d;
        //    }
        //    else
        //    {
        //        n = (s.Length - 1) / d;
        //    }
        //    string left = "";
        //    string right = "";

        //    while (n >= 1)
        //    {
        //        left = s.Substring(0, n);
        //        right = s.Substring(n);

        //        if (!right.StartsWith("0"))
        //        {
        //            if (isBeautiful(d, n, s))
        //            {
        //                Console.WriteLine("YES " + left);
        //                return;
        //            }
        //        }

        //        d += 1;

        //        if (s.Length % 2 == 0)
        //        {
        //            n = s.Length / d;
        //        }
        //        else
        //        {
        //            n = (s.Length - 1) / d;
        //        }
        //    }

        //    Console.WriteLine("NO");
        //    return;

        //}

        //static bool isBeautiful(int d, int l, string s)
        //{
        //    int st = 0;
        //    int fi = 0;

        //    int[] arr = new int[d];
        //    int i = 0;

        //    while (i < d)
        //    {
        //        arr[i] = int.Parse(s.Substring(st, l));
        //        st += l;
        //    }

        //    return false;
        //}

    }
}
