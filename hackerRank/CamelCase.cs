using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class CamelCase
    {
        public void Execute()
        {
            string s = "saveChangesInTheEditor";
            int resExp = 5;

            int result = camelcase(s);

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

        static int camelcase(string s)
        {
            return s.Where(e => Char.IsUpper(e)).Count() + 1;
        }
    }
}
