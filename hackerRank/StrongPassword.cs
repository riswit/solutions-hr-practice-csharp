using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class StrongPassword
    {
        public void Execute()
        {
            int n = 0;
            //string password = "Ab1";
            //int resExp = 3;

            //string password = "#HackerRank*";
            //int resExp = 1;

            //string password = "abcde";
            //int resExp = 3;

            string password = "aaA!1";
            int resExp = 1;

            int result = minimumNumber(n, password);

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

        static int minimumNumber(int n, string password)
        {
            int res = 0;
            string special_characters = "!@#$%^&*()-+";

            if (password.Where(e => Char.IsUpper(e)).Count() == 0)
            {
                res += 1;
            }
            if (password.Where(e => Char.IsLower(e)).Count() == 0)
            {
                res += 1;
            }
            if (password.Where(e => Char.IsNumber(e)).Count() == 0)
            {
                res += 1;
            }
            if (password.Where(e => special_characters.Contains(e)).Count() == 0)
            {
                res += 1;
            }

            int numMiss = 6 - password.Length;

            if (password.Length < 6)
            {
                if (numMiss > res)
                {
                    res = numMiss;
                }
            }

            return res;
        }
    }
}
