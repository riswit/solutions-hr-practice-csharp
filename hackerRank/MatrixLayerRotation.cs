using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class MatrixLayerRotation
    {
        public void Execute()
        {
            int r = 0;
            List<List<int>> matrix = new List<List<int>>
                                {   new List<int>(){1, 2, 3, 4},
                                    new List<int>(){12, 1, 2, 5},
                                    new List<int>(){11, 4, 3, 6},
                                    new List<int>(){10, 9, 8, 7}
                                };

            matrixRotation(matrix, r);
        }

        static void matrixRotation(List<List<int>> matrix, int r)
        {
            int rows = matrix.Count();
            int cols = matrix[0].Count();
            int numTracks = 0;
            int minSize = 0;
            int maxSize = 0;
            if (rows <= cols)
            {
                minSize = rows;
                maxSize = cols;
            }
            else
            {
                minSize = cols;
                maxSize = rows;
            }
            numTracks = minSize / 2;

            List<int[][]> listTracks = new List<int[][]>();
            int[][] arrTrack;
            int[] arrElem = new int[2];
            int lenArrTrack = 0;
            int indAt = 0;

            for (int nt = 0; nt < numTracks; nt++)
            {
                lenArrTrack = ((rows - 1 - (nt * 2)) * 2) + ((cols - 1 - (nt * 2)) * 2);
                indAt = 0;
                arrTrack = new int[lenArrTrack][];

                for (int i = 0 + nt; i < rows - nt; i++)
                {
                    for (int j = 0 + nt; j < cols - nt; j++)
                    {
                        arrElem = new int[2];
                        arrElem[0] = matrix[i][j];
                        arrElem[1] = i;
                        arrElem[2] = j;

                        arrTrack[indAt] = arrElem;
                        indAt += 1;
                    }


                }

                listTracks.Add(arrTrack);
            }
        }





//var source = Enumerable.Range(1, 100).Cast<int?>().ToArray();
//var destination = new int?[source.Length];

//var s = new Stopwatch();
//s.Start();
//for (int i = 0; i < 1000000;i++)
//{
//    Array.Copy(source, 1, destination, 0, source.Length - 1);
//}
//s.Stop();
//Console.WriteLine(s.Elapsed);


    }
}
