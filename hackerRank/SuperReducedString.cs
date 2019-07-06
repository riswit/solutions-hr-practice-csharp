using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class SuperReducedString
    {
        public void Execute()
        {
            string s = "aaabccddd";
            string resExp = "abd";

            string result = superReducedString(s);

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

        static string superReducedString(string s)
        {
            char[] arr = s.ToCharArray();
            bool existPair = true;
            char[] left;
            char[] right;
            
            while (existPair)
            {
                existPair = false;

                for (int i = 1; i < arr.Length && !existPair; i++)
                {
                    left = null;
                    right = null;

                    if (arr[i] == arr[i - 1])
                    {
                        existPair = true;
                        if (i - 1 > 0)
                        {
                            left = new char[i - 1];
                            Array.Copy(arr, 0, left, 0, i - 1);
                        }
                        if (arr.Length - i - 1 > 0)
                        {
                            right = new char[arr.Length - i - 1];
                            Array.Copy(arr, i + 1, right, 0, arr.Length - i - 1);
                        }
                        arr = new char[0];
                        if (left != null)
                        {
                            arr = left;
                        }
                        if (right != null)
                        {
                            arr = arr.Concat(right).ToArray();
                        }
                    }
                }
            }

            if (arr.Length == 0)
            {
                return "Empty String";
            }

            return new string(arr);
        }
    }
}
