using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class StringConstruction
    {
        public void Execute()
        {
            string s = "xulkowreuowzxgnhmiqekxhzistdocbnyozmnqthhpievvlj";
            int resExp = 13;

            int result = stringConstruction(s);

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

        static int stringConstruction(string s)
        {

            return s.Distinct().Count();
        }
    }
}
