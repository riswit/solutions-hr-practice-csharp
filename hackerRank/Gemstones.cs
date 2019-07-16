using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class Gemstones
    {
        public void Execute()
        {
            //string[] arr = {
            //"abcdde",
            //"baccd",
            //"eeabg"
            //};
            //int resExp = 2;

            string[] arr = {
            "vtrjvgbj",
            "mkmjyaeav",
            "sibzdmsk"
            };
            int resExp = 0;

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            int result = gemstones(arr);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

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

        static int gemstones(string[] arr)
        {
            if (arr.Length == 1)
            {
                return 0;
            }

            char[] t1 = arr[0].ToCharArray();
            char[] t2 = arr[1].ToCharArray();

            t1 = t1.Intersect(t2).ToArray();

            for (int i = 1; i < arr.Length; i++)
            {
                t2 = arr[i].ToCharArray();
                t1 = t1.Intersect(t2).ToArray();

                if (t1.Count() == 0)
                {
                    return 0;
                }
            }

            return t1.Count();
        }
    }
}
