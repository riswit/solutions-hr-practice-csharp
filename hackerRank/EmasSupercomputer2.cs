using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace hackerRank
{
    class EmasSupercomputer2
    {
        public void Execute()
        {
            //string[] grid = { "GGG", "GBB", "GGG", "GGB", "GGG" };
            //int resExp = 1;

            //string[] grid = { "GG", "GB" };
            //int resExp = 1;

            //string[] grid = { "BB", "GB" };
            //int resExp = 0;

            //string[] grid = { "GGG", "GBB", "GGG", "GGG", "GGG" };
            //int resExp = 5;

            //string[] grid = { "GGGGGG", "GBBBGB", "GGGGGG", "GGBBGB", "GGGGGG" };
            //int resExp = 5;

            //string[] grid = { "BGBBGB", "GGGGGG", "BGBBGB", "GGGGGG", "BGBBGB", "BGBBGB" };
            //int resExp = 25;

            //string[] grid = { "GGGGGGGG", "GBGBGGBG", "GBGBGGBG", "GGGGGGGG", "GBGBGGBG", "GGGGGGGG", "GBGBGGBG", "GGGGGGGG" };
            //int resExp = 81;

            //string[] grid = {
            //    "BBBGBGBBB",
            //    "BBBGBGBBB",
            //    "BBBGBGBBB",
            //    "GGGGGGGGG",
            //    "BBBGBGBBB",
            //    "BBBGBGBBB",
            //    "GGGGGGGGG",
            //    "BBBGBGBBB",
            //    "BBBGBGBBB",
            //    "BBBGBGBBB"
            //};
            //int resExp = 81;

            //string[] grid = {
            //    "GGGGGGGGG",
            //    "GBBBGGBGG",
            //    "GBBBGGBGG",
            //    "GBBBGGBGG",
            //    "GBBBGGBGG",
            //    "GBBBGGBGG",
            //    "GBBBGGBGG",
            //    "GGGGGGGGG"
            //};
            //int resExp = 1;

            string[] grid = {
            "BBGBGGGGGBBGGBB",
            "BBGBGGGGGBBGGBB",
            "GGGGGGGGGGGGGGG",
            "GGGGGGGGGGGGGGG",
            "BBGBGGGGGBBGGBB",
            "BBGBGGGGGBBGGBB",
            "BBGBGGGGGBBGGBB",
            "GGGGGGGGGGGGGGG",
            "BBGBGGGGGBBGGBB",
            "BBGBGGGGGBBGGBB",
            "BBGBGGGGGBBGGBB",
            "BBGBGGGGGBBGGBB",
            "BBGBGGGGGBBGGBB",
            "BBGBGGGGGBBGGBB",
            "GGGGGGGGGGGGGG"
                        };
            int resExp = 377;

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            int result = twoPluses(grid);

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

        static int twoPluses(string[] grid)
        {
            List<char[]> listCh = new List<char[]>();
            List<int[]> listRowG = new List<int[]>();
            int k = 0;
            DataTable dtBads = new DataTable();
            dtBads.Columns.Add("r", typeof(int));
            dtBads.Columns.Add("c", typeof(int));
            //dtBads.Columns.Add("s", typeof(int));
            DataRow newRow;
            char[] c;
            int size = 0;
            bool existP1One = false;
            bool existP2One = false;
            BoardGame boardGame = new BoardGame(grid, k);

            for (int i = 0; i < grid.Length; i++)
            {
                c = grid[i].ToCharArray();
                listCh.Add(c);

                size = getSizeMaxRow(c, i, grid);
                if (size > 1)
                {
                    listRowG.Add(new int[] { i, size });
                }
                else
                {
                    if (size == 1)
                    {
                        if (!existP1One)
                        {
                            existP1One = true;
                        }
                        else
                        {
                            if (!existP2One)
                            {
                                existP2One = true;
                            }
                        }
                    }
                }

                for (int j = 0; j < c.Length; j++)
                {
                    if (c[j] == 'B')
                    {
                        k++;
                        newRow = dtBads.NewRow();
                        newRow[0] = i;
                        newRow[1] = j;
                        //newRow[2] = 0;
                        dtBads.Rows.Add(newRow);
                    }
                }
            }

            if (listRowG.Count() == 0)
            {
                if (existP1One && existP2One)
                {
                    return 1;
                }
                return 0;
            }

            char[] r1;
            char[] r2;
            int areaP1 = 0;
            int areaP2 = 0;
            int branchP1 = 0;
            int branchP2 = 0;
            int maxArea = 0;
            int[] arr;
            int rowElab = 0;
            int rowElab2 = 0;
            int k2 = 0;
            DataTable dtBadsElab = new DataTable(); ;
            //List<char[]> listCh2 = new List<char[]>();
            int m = 0;
            bool addedP = false;
            //List<DataRow> listDr = new List<DataRow>();

            for (int i = 0; i < listRowG.Count(); i++)
            {
                arr = listRowG[i];
                rowElab = arr[0];

                if (rowElab != 0 && rowElab != listCh.Count() - 1)
                {
                    //size = arr[1];

                    r1 = listCh[rowElab];
                    for (int j = 1; j < r1.Count() - 1; j++)
                    {
                        branchP1 = getBranchPlus(k, rowElab, j, boardGame, dtBads);
                        areaP1 = getAreaPlus(getSizeFromBranch(branchP1));
                        while (branchP1 >= 1)
                        {
                            addedP = false;
                            for (int i2 = i + 1; i2 < listRowG.Count(); i2++)
                            {
                                arr = listRowG[i2];
                                rowElab2 = arr[0];

                                if (rowElab2 != 0 && rowElab2 != listCh.Count() - 1)
                                {
                                    if (!addedP)
                                    {
                                        k2 = k;
                                        dtBadsElab = new DataTable();
                                        //listCh2 = new List<char[]>();
                                        dtBadsElab = addPlus1ToList(branchP1, rowElab, j, listCh, dtBads, ref k2);

                                        addedP = true;
                                    }

                                    r2 = listCh[rowElab2];
                                    for (int j2 = 1; j2 < r2.Count() - 1; j2++)
                                    {
                                        branchP2 = getBranchPlus(k2, rowElab2, j2, boardGame, dtBadsElab);
                                        areaP2 = getAreaPlus(getSizeFromBranch(branchP2));
                                        m = areaP1 * areaP2;
                                        if (m > maxArea)
                                        {
                                            maxArea = m;
                                        }
                                    }
                                }
                                else
                                {
                                    r2 = listCh[rowElab2];
                                    string strRow = new string(r2);
                                    if (strRow.IndexOf("G") > -1)
                                    {
                                        areaP2 = 1;
                                        m = areaP1 * areaP2;
                                        if (m > maxArea)
                                        {
                                            maxArea = m;
                                        }
                                    }
                                }

                            }

                            branchP1 -= 1;
                        }
                    }
                }
            }

            if (listRowG.Count() > 0 && maxArea == 0)
            {
                if (existP1One && existP2One)
                {
                    return 1;
                }
                return 0;
            }

            return maxArea;
        }

        static int getSizeMaxRow(char[] c, int i, string[] grid)
        {
            string strRow = new string(c);

            //if (i == 0 || i == grid.Length - 1)
            //{
            //    if (strRow.IndexOf("G") > -1)
            //    {
            //        return 1;
            //    }
            //    return 0;
            //}

            int len = c.Length;
            if (len % 2 == 0)
            {
                len -= 1;
            }
            string strG = "";

            while (len >= 1)
            {
                strG = new String('G', len);

                if (strRow.IndexOf(strG) > -1)
                {
                    return len;
                }

                len -= 2;
            }
            return len;
        }

        static int getBranchPlus(int k, int row, int col, BoardGame boardGame, DataTable dtBads)
        {
            int branch = 0;
            int nTop = 0;
            int nRight = 0;
            int nBottom = 0;
            int nLeft = 0;

            nTop = calcTop(k, row, col, dtBads);
            branch = nTop;

            nRight = calcRight(boardGame, k, row, col, dtBads);
            if (nRight < branch) { branch = nRight; }

            nBottom = calcBottom(boardGame, k, row, col, dtBads);
            if (nBottom < branch) { branch = nBottom; }

            nLeft = calcLeft(k, row, col, dtBads);
            if (nLeft < branch) { branch = nLeft; }

            return branch;
        }

        static int getAreaPlus(int side)
        {
            return ((side - 1) * 2) + 1;
        }

        static int getSizeFromBranch(int branch)
        {
            return (branch * 2) + 1;
        }

        static DataTable addPlus1ToList(int branchP, int row, int col, List<char[]> listChOrig, DataTable dtBads, ref int k2)
        {
            //for (int i = 0; i < listChOrig.Count(); i++)
            //{
            //    listCh2.Add(listChOrig[i].ToArray());
            //}

            DataTable dtBadsMorePlus2 = addMorePlusToDtBads(branchP, row, col, dtBads, ref k2);

            return dtBadsMorePlus2;
        }

        static DataTable addMorePlusToDtBads(int branchP, int row, int col, DataTable dtBads, ref int k2)
        {
            //DataTable dtBadsMorePlus = new DataTable();
            //dtBadsMorePlus = dtBads.Clone();
            //dtBadsMorePlus = dtBads.Copy();
            DataTable dtBadsMorePlus = new DataTable();
            dtBadsMorePlus.Columns.Add("r", typeof(int));
            dtBadsMorePlus.Columns.Add("c", typeof(int));
            DataRow newRow;

            dtBadsMorePlus = dtBads.Copy();

            //for (int i = 0; i < dtBads.Rows.Count; i++)
            //{
            //    DataRow r = dtBads.Rows[i];
            //    newRow = dtBadsMorePlus.NewRow();
            //    newRow[0] = r[0].ToString();
            //    newRow[1] = r[1].ToString();
            //    dtBadsMorePlus.Rows.Add(newRow);
            //}

            newRow = dtBadsMorePlus.NewRow();
            newRow[0] = row;
            newRow[1] = col;
            //newRow[2] = 1;
            dtBadsMorePlus.Rows.Add(newRow);
            //listDr.Add(newRow);
            k2 += 1;

            //char[] c = listCh2[row];
            //c[col] = 'P';

            for (int i = row - 1; i >= (row - branchP); i--)
            {
                newRow = dtBadsMorePlus.NewRow();
                newRow[0] = i;
                newRow[1] = col;
                //newRow[2] = 1;
                dtBadsMorePlus.Rows.Add(newRow);

                //c = listCh2[i];
                //c[col] = 'P';
    //                listDr.Add(newRow);
                k2 += 1;
            }
            for (int j = col + 1; j <= (col + branchP); j++)
            {
                newRow = dtBadsMorePlus.NewRow();
                newRow[0] = row;
                newRow[1] = j;
                //newRow[2] = 1;
                dtBadsMorePlus.Rows.Add(newRow);

                //c = listCh2[row];
                //c[j] = 'P';
    //                listDr.Add(newRow);
                k2 += 1;
            }
            for (int i = row + 1; i <= (row + branchP); i++)
            {
                newRow = dtBadsMorePlus.NewRow();
                newRow[0] = i;
                newRow[1] = col;
                //newRow[2] = 1;
                dtBadsMorePlus.Rows.Add(newRow);

                //c = listCh2[i];
                //c[col] = 'P';
    //                listDr.Add(newRow);
                k2 += 1;
            }
            for (int j = col - 1; j >= (col - branchP); j--)
            {
                newRow = dtBadsMorePlus.NewRow();
                newRow[0] = row;
                newRow[1] = j;
                //newRow[2] = 1;
                dtBadsMorePlus.Rows.Add(newRow);

                //c = listCh2[row];
                //c[j] = 'P';
    //                listDr.Add(newRow);
                k2 += 1;
            }

            return dtBadsMorePlus;
        }

        static int calcTop(int k, int rowQ, int colQ, DataTable dt)
        {
            if (rowQ == 0)
            {
                return 0;
            }
            int totSquares = 0;
            int[] s;

            if (k > 0)
            {
                DataRow[] foundRows = dt.Select("r < " + rowQ + " and c = " + colQ, "r desc");
                if (foundRows.Length > 0)
                {
                    totSquares += ((rowQ - int.Parse(foundRows[0][0].ToString())) - 1);
                    return totSquares;
                }
            }

            totSquares += rowQ;

            return totSquares;
        }

        static int calcBottom(BoardGame boardGame, int k, int rowQ, int colQ, DataTable dt)
        {
            if (rowQ == (boardGame.Rows - 1))
            {
                return 0;
            }
            int totSquares = 0;
            int[] s;

            if (k > 0)
            {
                DataRow[] foundRows = dt.Select("r > " + rowQ + " and c = " + colQ, "r");
                if (foundRows.Length > 0)
                {
                    totSquares += ((int.Parse(foundRows[0][0].ToString()) - rowQ) - 1);
                    return totSquares;
                }
            }

            totSquares += ((boardGame.Rows - 1) - rowQ);

            return totSquares;
        }

        static int calcLeft(int k, int rowQ, int colQ, DataTable dt)
        {
            if (colQ == 0)
            {
                return 0;
            }
            int totSquares = 0;
            int[] s;

            if (k > 0)
            {
                DataRow[] foundRows = dt.Select("r = " + rowQ + " and c < " + colQ, "c desc");
                if (foundRows.Length > 0)
                {
                    totSquares += ((colQ - int.Parse(foundRows[0][1].ToString())) - 1);
                    return totSquares;
                }
            }

            totSquares += colQ;

            return totSquares;
        }

        static int calcRight(BoardGame boardGame, int k, int rowQ, int colQ, DataTable dt)
        {
            if (colQ == (boardGame.Cols - 1))
            {
                return 0;
            }
            int totSquares = 0;
            int[] s;

            if (k > 0)
            {
                DataRow[] foundRows = dt.Select("r = " + rowQ + " and c > " + colQ, "c");
                if (foundRows.Length > 0)
                {
                    totSquares += ((int.Parse(foundRows[0][1].ToString()) - colQ) - 1);
                    return totSquares;
                }
            }

            totSquares += ((boardGame.Cols - 1) - colQ);

            return totSquares;
        }

        class BoardGame
        {
            private int cols;
            private int rows;

            public BoardGame(string[] grid, int k)
            {
                this.Cols = grid[0].ToCharArray().Length;
                this.Rows = grid.Length;
            }

            public int Rows { get => rows; set => rows = value; }
            public int Cols { get => cols; set => cols = value; }
        }

    }
}
