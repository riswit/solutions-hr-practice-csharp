using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class Encryption
    {
        public void Execute()
        {
            string s = "iffactsdontfittotheorychangethefacts";
            string resExp = "isieae fdtonf fotrga anoyec cttctt tfhhhs";

            string result = encryption(s);

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

        static string encryption(string s)
        {
            if (s.Length <= 2)
            {
                return s;
            }

            string res = "";
            s = s.Replace(" ", "");

            double r = Math.Sqrt(s.Length);
            int rows = (int)r;
            int cols = rows;

            if (rows * cols != s.Length)
            {
                cols += 1;
                if (rows * cols < s.Length)
                {
                    rows += 1;
                }
            }

            char[] cs = s.ToCharArray();
            char[][] grid = new char[rows][];
            int ccols = 0;
            int crows = 0;
            grid[crows] = new char[cols];
            for (int i = 0; i < cs.Length; i++)
            {
                grid[crows][ccols] = cs[i];

                if (ccols == cols - 1)
                {
                    crows++;
                    if (crows == rows)
                    {
                        break;
                    }
                    grid[crows] = new char[cols];
                    ccols = 0;
                }
                else
                {
                    ccols++;
                }
            }

            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (grid[i][j] != '\0')
                    {
                        res += grid[i][j];
                    }
                }
                if (j < cols - 1)
                {
                    res += " ";
                }
            }

            return res;
        }

        //bool isCal = false;
        //string str = "";

        //while (!isCal)
        //{

        //    if (lTopic < cols)
        //    {
        //        isCal = true;
        //    }
        //    else
        //    {
        //        lastPos += lTopic;
        //        if ((s.Length - lastPos) >= cols)
        //        {
        //            lTopic = cols;
        //        }
        //        else
        //        {
        //            lTopic = s.Length - lastPos;
        //        }
        //    }
        //}


    }
}
