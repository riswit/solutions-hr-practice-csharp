using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class BearSteadyGene
    {
        public void Execute()
        {
            string gene = "GAAATAAA";
            int resExp = 5;

            int result = steadyGene(gene);

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

        static int steadyGene(string gene)
        {
            int res = 0;

            Dictionary<char, int> t = (from a in gene.ToCharArray().GroupBy(x => x) select a).ToDictionary(
                                                                            p => p.Key,
                                                                            p => p.Count()
                                                                            );



            return res;
        }
    }
}
