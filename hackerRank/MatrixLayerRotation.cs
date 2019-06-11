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
            //int r = 2;
            //List<List<int>> matrix = new List<List<int>>
            //                    {   new List<int>(){1, 2, 3, 4},
            //                        new List<int>(){12, 1, 2, 5},
            //                        new List<int>(){11, 4, 3, 6},
            //                        new List<int>(){10, 9, 8, 7}
            //                    };

            //int r = 2;
            //List<List<int>> matrix = new List<List<int>>
            //                    {   new List<int>(){1, 2, 3, 4},
            //                        new List<int>(){5, 6, 7, 8},
            //                        new List<int>(){9, 10, 11, 12},
            //                        new List<int>(){13, 14, 15, 16 }
            //                    };

            //int r = 7;
            //List<List<int>> matrix = new List<List<int>>
            //                    {   new List<int>(){1, 2, 3, 4},
            //                        new List<int>(){7, 8, 9, 10},
            //                        new List<int>(){13, 14, 15, 16},
            //                        new List<int>(){ 19, 20, 21, 22 },
            //                        new List<int>(){ 25, 26, 27, 28 }
            //                    };

            int r = 3;
            List<List<int>> matrix = new List<List<int>>
                                {   new List<int>(){1, 1},
                                    new List<int>(){1, 1}
                                };

            matrixRotation(matrix, r);

            Console.WriteLine("");
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
            int[] arrElem;
            int lenArrTrack = 0;
            int indAt = 0;
            bool[] arrEq = new bool[numTracks];
            int firstElem = 0;

            //Prepare elements

            for (int nt = 0; nt < numTracks; nt++)
            {
                lenArrTrack = ((rows - 1 - (nt * 2)) * 2) + ((cols - 1 - (nt * 2)) * 2);
                indAt = 0;
                arrTrack = new int[lenArrTrack][];
                arrEq[nt] = true;
                firstElem = 0;

                //side up
                for (int j = 0 + nt; j < cols - nt - 1; j++)
                {
                    arrElem = new int[3];
                    arrElem[0] = matrix[nt][j];
                    arrElem[1] = nt;
                    arrElem[2] = j;

                    arrTrack[indAt] = arrElem;
                    indAt += 1;

                    if (j == 0 + nt)
                    {
                        firstElem = matrix[nt][j];
                    }
                    else
                    {
                        if (firstElem != matrix[nt][j] && arrEq[nt] == true)
                        {
                            arrEq[nt] = false; 
                        }
                    }
                }

                //side right
                for (int i = nt; i < rows - nt - 1; i++)
                {
                    arrElem = new int[3];
                    arrElem[0] = matrix[i][cols - 1 - nt];
                    arrElem[1] = i;
                    arrElem[2] = cols - 1 - nt;

                    arrTrack[indAt] = arrElem;
                    indAt += 1;

                    if (firstElem != matrix[i][cols - 1 - nt] && arrEq[nt] == true)
                    {
                        arrEq[nt] = false;
                    }
                }

                //side down
                for (int j = cols - nt - 1; j > nt; j--)
                {
                    arrElem = new int[3];
                    arrElem[0] = matrix[rows - nt - 1][j];
                    arrElem[1] = rows - nt - 1;
                    arrElem[2] = j;

                    arrTrack[indAt] = arrElem;
                    indAt += 1;

                    if (firstElem != matrix[rows - nt - 1][j] && arrEq[nt] == true)
                    {
                        arrEq[nt] = false;
                    }
                }

                //side left
                for (int i = rows - nt - 1; i > nt; i--)
                {
                    arrElem = new int[3];
                    arrElem[0] = matrix[i][nt];
                    arrElem[1] = i;
                    arrElem[2] = nt;

                    arrTrack[indAt] = arrElem;
                    indAt += 1;

                    if (firstElem != matrix[i][nt] && arrEq[nt] == true)
                    {
                        arrEq[nt] = false;
                    }
                }

                listTracks.Add(arrTrack);
            }

            //Rotate elements

            int tmp = 0;
            int numR = 0;
            int[] arrTmp;
            int[] arrElemTmp = new int[3];
            int[] arrElemTmpR = new int[3];
            
            for (int nt = 0; nt < numTracks; nt++)
            {
                lenArrTrack = ((rows - 1 - (nt * 2)) * 2) + ((cols - 1 - (nt * 2)) * 2);

                numR = r;
                if (numR > lenArrTrack)
                {
                    if (numR % lenArrTrack != 0)
                    {
                        tmp = (int)(numR / lenArrTrack);
                        numR = numR - (tmp * lenArrTrack);
                    }
                }

                if (numR != lenArrTrack && arrEq[nt] == false)
                {
                    arrTrack = listTracks[nt];

                    arrTmp = new int[lenArrTrack];

                    for (int ii = 0; ii < arrTrack.Length; ii++)
                    {
                        arrElemTmp = arrTrack[ii];
                        arrTmp[ii] = arrElemTmp[0];
                    }

                    for (int i = 0; i < numR; i++)
                    {
                        tmp = arrTmp[0];
                        Array.ConstrainedCopy(arrTmp, 1, arrTmp, 0, arrTmp.Length - 1);
                        arrTmp[arrTmp.Length - 1] = tmp;
                    }

                    for (int ii = 0; ii < arrTrack.Length; ii++)
                    {
                        arrElemTmp = arrTrack[ii];
                        arrElemTmp[0] = arrTmp[ii];
                    }

                }
            }

            //Print elements

            StringBuilder rowP = new StringBuilder("");
            int t = 0;
            int[,] arrOut = new int[rows, cols];
            int[][] newArrTrack = new int[cols * rows][];

            for (int nt = 0; nt < numTracks; nt++)
            {
                newArrTrack = listTracks[nt];

                for (int ii = 0; ii < newArrTrack.Length; ii++)
                {
                    arrElemTmp = newArrTrack[ii];

                    arrOut[arrElemTmp[1], arrElemTmp[2]] = arrElemTmp[0];

                    t += 1;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                if (i > 0)
                {
                    Console.WriteLine("");
                    rowP.Clear();
                }

                for (int j = 0; j < cols; j++)
                {
                    if (j > 0)
                    {
                        rowP.Append(" ");
                    }
                    rowP.Append(arrOut[i, j].ToString());
                }
                Console.Write(rowP);
            }

        }

        //static int[] GetColumn(int[,] matrix, int columnNumber)
        //{
        //    return Enumerable.Range(0, matrix.GetLength(0))
        //            .Select(x => matrix[x, columnNumber])
        //            .ToArray();
        //}

        //static int[] GetRow(int[,] matrix, int rowNumber)
        //{
        //    return Enumerable.Range(0, matrix.GetLength(1))
        //            .Select(x => matrix[rowNumber, x])
        //            .ToArray();
        //}

    }
}
