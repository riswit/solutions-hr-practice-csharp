using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class Abbreviation
    {
        public void Execute()
        {
            string a = "bBccC";
            string b = "BBC";
            string resExp = "YES";

            string result = abbreviation(a, b);

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

        static string abbreviation(string a, string b)
        {
            int i = a.ToLower().IndexOf(b.ToLower());

            if (i > -1)
            {
                string strL = "";
                string strR = "";
                if (i > 0)
                {
                    strL = a.Substring(0, i);
                }

                strR = a.Substring(i + b.Length);

                if (string.Compare((strL + strR).ToLower(), (strL + strR)) == 0)
                {
                    return "YES";
                }
                if (b.Length == 1)
                {
                    return "NO";
                }
            }

            string str = "";
            i = a.ToLower().IndexOf(b[0].ToString().ToLower());
            while (i > -1)
            {
                int j = 0;
                str = a[i].ToString();
                for (j = i + 1; j < a.Length && str.Length < b.Length; j++)
                {

                    if (str.ToUpper() + a[j].ToString().ToUpper() == b.Substring(0, str.Length + 1).ToUpper())
                    {
                        if (j < a.Length - 1)
                        {
                            if (char.IsLower(a[j]) && char.IsUpper(a[j + 1])
                                && str.ToUpper() + a[j + 1].ToString().ToUpper() == b.Substring(0, str.Length + 1).ToUpper())
                            {
                            }
                            else
                            {
                                str += a[j].ToString();
                            }
                        }
                        else
                        {
                            str += a[j].ToString();
                        }
                    }
                    else
                    {
                        if (char.IsUpper(a[j]))
                        {
                            break;
                        }
                    }
                }

                if (str.ToUpper() == b)
                {
                    string strL = "";
                    string strR = "";
                    if (i > 0)
                    {
                        strL = a.Substring(0, i);
                    }

                    if (j < a.Length)
                    {
                        strR = a.Substring(j);
                    }

                    if (string.Compare((strL + strR).ToLower(), (strL + strR)) == 0)
                    {
                        return "YES";
                    }
                }

                i = a.ToLower().IndexOf(b[0].ToString().ToLower(), i + 1);
            }

            return "NO";
        }
    }
}
