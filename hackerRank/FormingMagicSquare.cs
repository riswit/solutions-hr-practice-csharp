using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class FormingMagicSquare
    {
        public void Execute()
        {
            int[][] s = new int[][] { 
                new int[] { 4, 9, 2 },
                new int[] { 3, 5, 7 },
                new int[] { 8, 1, 5 }
            };
            int resExp = 1;

            //int[][] s = new int[][] {
            //    new int[] { 5, 3, 4 },
            //    new int[] { 1, 5, 8 },
            //    new int[] { 6, 4, 2 }
            //};
            //int resExp = 7;

            int result = formingMagicSquare(s);

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

        static int formingMagicSquare(int[][] s)
        {
            int costMin = 0;
            List<int> list = loadSquareInList(s);
            List<int> listMissing = getNumsMissing(list);

            if (listMissing.Count == 0)
            {
                return 0;
            }

            while (!isCorrectSquare(list))
            {

            }

            return costMin;
        }

        static List<int> getNumsMissing(List<int> list)
        {
            List<int> listMissing = new List<int>();
            int j = 0;

            for (int i = 1; i <= 9; i++)
            {
                for (j = 0; j < list.Count; j++)
                {
                    if (i == list[j])
                    {
                        break;
                    }
                }
                if (j == list.Count)
                {
                    listMissing.Add(i);
                }
            }

            return listMissing;
        }

        static bool isCorrectSquare(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        static List<int> loadSquareInList(int[][] s)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    list.Add(s[i][j]);
                }
            }

            return list;
        }





        //static int[] getSumArray(int[][] s)
        //{
        //    int line1 = s[0][0] + s[0][1] + s[0][2];
        //    int line2 = s[1][0] + s[1][1] + s[1][2];
        //    int line3 = s[2][0] + s[2][1] + s[2][2];

        //    int hor1 = s[0][0] + s[1][0] + s[2][0];
        //    int hor2 = s[0][1] + s[1][1] + s[2][1];
        //    int hor3 = s[0][2] + s[1][2] + s[2][2];

        //    int diagLR = s[0][0] + s[1][1] + s[2][2];
        //    int diagRL = s[0][2] + s[1][1] + s[2][0];

        //    int[] sumArray = new int[] { line1, line2, line3, hor1, hor2, hor3, diagLR, diagRL };

        //    return sumArray;
        //}


    }
}
