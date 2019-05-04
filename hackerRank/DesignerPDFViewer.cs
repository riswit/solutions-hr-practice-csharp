using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class DesignerPDFViewer
    {
        public void Execute()
        {
            //int[] h = { 1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            //string word = "abc";
            //int resExp = 9;

            int[] h = { 1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7 };
            string word = "zaba";
            int resExp = 28;

            int result = designerPdfViewer(h, word);

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

        static int designerPdfViewer(int[] h, string word)
        {
            int area = 0;
            int max = 0;
            string[] alph = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < alph.Length; j++)
                {
                    if (word.Substring(i, 1) == alph[j])
                    {
                        if (h[j] > max)
                        {
                            max = h[j];
                        }
                    }
                }
            }

            area = word.Length * max;

            return area;
        }


    }
}
