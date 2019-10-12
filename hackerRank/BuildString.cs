using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class BuildString
    {
        public void Execute()
        {
            //int a = 4;
            //int b = 5;
            //string s = "aabaacaba";
            //int resExp = 26;

            //int a = 8;
            //int b = 9;
            //string s = "bacbacacb";
            //int resExp = 42;

            //int a = 2;
            //int b = 3;
            //string s = "caaahqcqes";
            //int resExp = 20;

            //int a = 1;
            //int b = 3;
            //string s = "acbbqbbqbb";
            //int resExp = 10;

            //int a = 2;
            //int b = 4;
            //string s = "cbabecbahe";
            //int resExp = 18;

            //int a = 1;
            //int b = 2;
            //string s = "cbaasgcbiikaegcbiidcbaasgcbiikaegcbiidir";
            //int resExp = 20;

            //int a = 2;
            //int b = 3;
            //string s = "cbacojcrojcrlidickjcjcrojcrlijcrojcrrojq";
            //int resExp = 45;

            //int a = 1;
            //int b = 3;
            //string s = "cabcjpsdaedsasedsascabcjpsddsdaedsasedsa";
            //int resExp = 24;

            //int a = 2;
            //int b = 4;
            //string s = "baaceacmbaaceam";
            //int resExp = 22;

            //int a = 2;
            //int b = 2;
            //string s = "cbbcnkbbcbnkbbcbtnkatnbebgcbnkbgbcnkbbcbnkmbndnknk";
            //int resExp = 50;

            int a = 7890;
            int b = 7891;
            string s = "acbcrsjcrscrsjcrcbcrsjcrscrsjccbcrsjcrscrsjcrcbcrsjrscrsjcrcbcrsjcrscrsjccbcrsjcrscrsjcrcbcsbcbcrsjh";
            int resExp = 126246;

            //int a = 7078;
            //int b = 7078;
            //string s = "abbciabbcabciabbcmabbciabbcahlbchgcmabbcmggcmababciabbcagerafrciabbcsrhgcmcabciabbchgcmabbcmsfabcmsr";
            //int resExp = 268964;

            int result = buildString(a, b, s);

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            }
            else
            {
                Console.WriteLine(result);
                Console.WriteLine("Perfetto!!!");
            }

        }

        static int buildString(int a, int b, string s)
        {
            int res = a;
            string str = s.Substring(0, 1);
            int nd = 0;

            if (s.Length > 1)
            {
                res += a;
                str += s.Substring(1, 1);
            }

            int i = 2;
            while (i < s.Length)
            {
                nd = 0;
                for (int j = i; j < s.Length; j++)
                {
                    nd += 1;

                    if (str.IndexOf(s.Substring(i, nd)) < 0 || j == s.Length - 1)
                    {
                        if (nd > 2)
                        {
                            if (str.IndexOf(s.Substring(i, nd)) < 0)
                            {
                                if (str.IndexOf(s.Substring(i + 1)) > -1)
                                {
                                    str += s.Substring(i, 1);
                                    res += a;
                                }
                                else
                                {
                                    str += s.Substring(i, nd - 1);
                                    res += b;
                                }
                            }
                            else
                            {
                                str += s.Substring(i, nd);
                                res += b;
                            }
                        }
                        else
                        {
                            if (nd == 2 && j < s.Length - 1)
                            {
                                nd -= 1;
                                res += a;
                            }
                            else
                            {
                                if (nd == 2 && j == s.Length - 1)
                                {
                                    if (nd * a > b)
                                    {
                                        res += b;
                                    }
                                    else
                                    {
                                        nd -= 1;
                                        res += a;
                                    }
                                }
                                else
                                {
                                    res += a;
                                }
                            }
                            str += s.Substring(i, nd);
                        }
                        break;
                    }
                }

                i = str.Length;
            }

            return res;
        }

        static int buildString_8Points(int a, int b, string s)
        {
            int res = a;
            string str = s.Substring(0, 1);
            int nd = 0;

            if (s.Length > 1)
            {
                res += a;
                str += s.Substring(1, 1);
            }

            for (int i = 2; i < s.Length; i++)
            {
                nd = 0;
                for (int j = str.Length; j < s.Length; j++)
                {
                    nd += 1;

                    if (str.IndexOf(s.Substring(str.Length, nd)) < 0 || j == s.Length - 1)
                    {
                        if (nd > 2)
                        {
                            res += b;
                            if (str.IndexOf(s.Substring(str.Length, nd)) < 0)
                            {
                                str += s.Substring(str.Length, nd - 1);
                            }
                            else
                            {
                                str += s.Substring(str.Length, nd);
                            }
                        }
                        else
                        {
                            res += (s.Substring(str.Length, nd).Length * a);
                            str += s.Substring(str.Length, nd);
                        }
                        break;
                    }                    
                }
            }

            return res;
        }
    }
}
