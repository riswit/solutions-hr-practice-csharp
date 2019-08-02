using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class FlippingBits
    {
        public void Execute()
        {
            long n = 123456;
            long resExp = 4294843839;

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            long result = flippingBits(n);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

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

        static long flippingBits(long n)
        {
            long res = 0;

            string binary = Convert.ToString(n, 2);
            binary = binary.Replace("1", "x").Replace("0", "1").Replace("x", "0");
            binary = (new String('1', 32 - binary.Length)) + binary;

            res = Convert.ToInt64(binary, 2);

            return res;
        }
    }
}
