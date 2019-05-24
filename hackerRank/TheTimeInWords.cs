using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class TheTimeInWords
    {
        public void Execute()
        {
            //int h = 3;
            //int m = 0;
            //string resExp = "three o' clock";

            //int h = 7;
            //int m = 15;
            //string resExp = "quarter past seven";

            //int h = 7;
            //int m = 30;
            //string resExp = "half past seven";

            //int h = 7;
            //int m = 45;
            //string resExp = "quarter to eight";

            //int h = 5;
            //int m = 17;
            //string resExp = "thirteen minutes to six";

            //int h = 5;
            //int m = 47;
            //string resExp = "thirteen minutes to six";

            int h = 1;
            int m = 1;
            string resExp = "one minute past one";

            string result = timeInWords(h, m);

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

        static string timeInWords(int h, int m)
        {
            string res = "";
            int hNext = 0;
            string minutes = "minutes";

            Dictionary<int, string> dict = makeDictNumWords();

            if (m == 0)
            {
                res = dict[h] + " o' clock";
                return res;
            }

            if (m == 15)
            {
                res = "quarter past " + dict[h];
                return res;
            }

            if (m == 30)
            {
                res = "half past " + dict[h];
                return res;
            }

            if (m == 45)
            {
                hNext = h + 1;
                if (h == 12)
                {
                    hNext = 1;
                }
                res = "quarter to " + dict[hNext];
                return res;
            }

            if (m < 30)
            {
                if (m == 1)
                {
                    minutes = "minute";
                }
                res = dict[m] + " " + minutes + " past " + dict[h];
                return res;
            }

            hNext = h + 1;
            if (h == 12)
            {
                hNext = 1;
            }
            if (60 - m == 1)
            {
                minutes = "minute";
            }
            res = dict[60 - m] + " " + minutes + " to " + dict[hNext];

            return res;
        }

        static Dictionary<int, string> makeDictNumWords()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();

            dict.Add(1, "one");
            dict.Add(2, "two");
            dict.Add(3, "three");
            dict.Add(4, "four");
            dict.Add(5, "five");
            dict.Add(6, "six");
            dict.Add(7, "seven");
            dict.Add(8, "eight");
            dict.Add(9, "nine");
            dict.Add(10, "ten");
            dict.Add(11, "eleven");
            dict.Add(12, "twelve");
            dict.Add(13, "thirteen");
            dict.Add(14, "fourteen");
            dict.Add(15, "fifteen");
            dict.Add(16, "sixteen");
            dict.Add(17, "seventeen");
            dict.Add(18, "eighteen");
            dict.Add(19, "nineteen");
            dict.Add(20, "twenty");
            dict.Add(21, "twenty one");
            dict.Add(22, "twenty two");
            dict.Add(23, "twenty three");
            dict.Add(24, "twenty four");
            dict.Add(25, "twenty five");
            dict.Add(26, "twenty six");
            dict.Add(27, "twenty seven");
            dict.Add(28, "twenty eight");
            dict.Add(29, "twenty nine");

            return dict;
        }

    }
}
