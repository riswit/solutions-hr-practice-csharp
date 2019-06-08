using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace hackerRank
{
    class EmasSupercomputer
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

            string[] grid = {
                "BBBGBGBBB",
                "BBBGBGBBB",
                "BBBGBGBBB",
                "GGGGGGGGG",
                "BBBGBGBBB",
                "BBBGBGBBB",
                "GGGGGGGGG",
                "BBBGBGBBB",
                "BBBGBGBBB",
                "BBBGBGBBB"
            };
            int resExp = 81;

            int result = twoPluses(grid);

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

        static int twoPluses(string[] grid)
        {
            List<char[]> listCh = new List<char[]>();
            int k = 0;
            DataTable dtBads = new DataTable();
            dtBads.Columns.Add("r", typeof(int));
            dtBads.Columns.Add("c", typeof(int));
            DataRow newRow;
            char[] c;

            for (int i = 0; i < grid.Length; i++)
            {
                c = grid[i].ToCharArray();
                listCh.Add(c);

                for (int j = 0; j < c.Length; j++)
                {
                    if (c[j] == 'B')
                    {
                        k++;
                        newRow = dtBads.NewRow();
                        newRow[0] = i;
                        newRow[1] = j;
                        dtBads.Rows.Add(newRow);
                    }
                }
            }

            BoardGame boardGame = new BoardGame(grid, k);

            int branchP = 0;
            int area = 0;
            int maxArea = 0;

            for (int i = 0; i < listCh.Count(); i++)
            {
                c = listCh[i];
                for (int j = 0; j < c.Count(); j++)
                {
                    if (c[j] == 'G')
                    {
                        branchP = getBranchPlus(k, i, j, boardGame, dtBads);

                        area = getAreaMax(branchP, i, j, k, listCh, boardGame, dtBads);

                        if (area > maxArea)
                        {
                            maxArea = area;
                        }
                    }
                }
            }

            return maxArea;
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

        static int getSizeFromBranch(int branch)
        {
            return (branch * 2) + 1;
        }

        static int getAreaMax(int branchP, int row, int col, int k, List<char[]> listChOrig, BoardGame boardGame, DataTable dtBads)
        {
            int areaMax = 0;
            int areaP1 = 0;
            int areaP2 = 0;
            List<int> listArea = new List<int>();
            int sideElabP1 = getSizeFromBranch(branchP);
            int sideElabP2 = 0;
            List<char[]> listCh2 = new List<char[]>();
            DataTable dtBadsElab;
            int k2 = k;
            char[] c;
            int branchP2 = 0;

            k2 = k;
            dtBadsElab = new DataTable();
            listCh2 = new List<char[]>();
            dtBadsElab = addPlus1ToList(branchP, row, col, listChOrig, ref listCh2, dtBads, ref k2);

            areaP1 = getAreaPlus(sideElabP1);

            for (int i = 0; i < listCh2.Count(); i++)
            {
                c = listCh2[i];
                for (int j = 0; j < c.Count(); j++)
                {
                    if (c[j] == 'G')
                    {
                        branchP2 = getBranchPlus(k, i, j, boardGame, dtBadsElab);
                        sideElabP2 = getSizeFromBranch(branchP2);

                        areaP2 = getAreaPlus(sideElabP2);

                        if ((areaP1 * areaP2) > areaMax)
                        {
                            areaMax = areaP1 * areaP2;
                        }
                    }
                }
            }

            return areaMax;
        }

        static DataTable addPlus1ToList(int branchP, int row, int col, List<char[]> listChOrig, ref List<char[]> listCh2, DataTable dtBads, ref int k2)
        {
            char[] c;
            for (int i = 0; i < listChOrig.Count(); i++)
            {
                c = listChOrig[i].ToArray();
                listCh2.Add(c);
            }

            DataTable dtBadsMorePlus = addMorePlusToDtBads(branchP, row, col, dtBads, ref listCh2, ref k2);

            return dtBadsMorePlus;
        }

        static DataTable addMorePlusToDtBads(int branchP, int row, int col, DataTable dtBads, ref List<char[]> listCh2, ref int k2)
        {
            DataTable dtBadsMorePlus = new DataTable();
            dtBadsMorePlus.Columns.Add("r", typeof(int));
            dtBadsMorePlus.Columns.Add("c", typeof(int));
            DataRow newRow;

            for (int i = 0; i < dtBads.Rows.Count; i++)
            {
                DataRow r = dtBads.Rows[i];
                newRow = dtBadsMorePlus.NewRow();
                newRow[0] = r[0].ToString();
                newRow[1] = r[1].ToString();
                dtBadsMorePlus.Rows.Add(newRow);
            }

            newRow = dtBadsMorePlus.NewRow();
            newRow[0] = row;
            newRow[1] = col;
            dtBadsMorePlus.Rows.Add(newRow);
            k2 += 1;

            char[] c = listCh2[row];
            c[col] = 'P';

            for (int i = row - 1; i >= (row - branchP); i--)
            {
                newRow = dtBadsMorePlus.NewRow();
                newRow[0] = i;
                newRow[1] = col;
                dtBadsMorePlus.Rows.Add(newRow);

                c = listCh2[i];
                c[col] = 'P';
                k2 += 1;
            }
            for (int j = col + 1; j <= (col + branchP); j++)
            {
                newRow = dtBadsMorePlus.NewRow();
                newRow[0] = row;
                newRow[1] = j;
                dtBadsMorePlus.Rows.Add(newRow);

                c = listCh2[row];
                c[j] = 'P';
                k2 += 1;
            }
            for (int i = row + 1; i <= (row + branchP); i++)
            {
                newRow = dtBadsMorePlus.NewRow();
                newRow[0] = i;
                newRow[1] = col;
                dtBadsMorePlus.Rows.Add(newRow);

                c = listCh2[i];
                c[col] = 'P';
                k2 += 1;
            }
            for (int j = col - 1; j >= (col - branchP); j--)
            {
                newRow = dtBadsMorePlus.NewRow();
                newRow[0] = row;
                newRow[1] = j;
                dtBadsMorePlus.Rows.Add(newRow);

                c = listCh2[row];
                c[j] = 'P';
                k2 += 1;
            }

            return dtBadsMorePlus;
        }

        static int getAreaPlus(int side)
        {
            return ((side - 1) * 2) + 1;
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

        ///////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////

        //static void tryFindPlus(BoardGame boardGame, int sideElab, int k, List<char[]> listChOrig, DataTable dtBads)
        //{
        //    while (sideElab >= 1)
        //    {
        //        boardGame.SideP1 = sideElab;
        //        boardGame.FoundPlus1 = findPlus(1, boardGame.StartPlusRow, boardGame.SideP1, boardGame, k, listChOrig, dtBads);

        //        if (boardGame.FoundPlus1)
        //        {
        //            break;
        //        }

        //        sideElab -= 2;
        //    }

        //    if (!boardGame.FoundPlus1)
        //    {
        //        return;
        //    }

        //    char[] c;
        //    List<char[]> listCh2 = new List<char[]>();
        //    for (int i = 0; i < listChOrig.Count(); i++)
        //    {
        //        c = listChOrig[i].ToArray();
        //        listCh2.Add(c);
        //    }

        //    DataTable dtBadsMorePlus = addMorePlusToDtBads(dtBads, boardGame, listCh2);

        //    boardGame.FoundPlus2 = false;
        //    sideElab = boardGame.SidePlus;
        //    while (sideElab >= 1)
        //    {
        //        boardGame.SideP2 = sideElab;
        //        boardGame.FoundPlus2 = findPlus(2, 0, boardGame.SideP2, boardGame, k, listCh2, dtBadsMorePlus);

        //        if (boardGame.FoundPlus2)
        //        {
        //            break;
        //        }

        //        sideElab -= 2;
        //    }

        //    if (!boardGame.FoundPlus2)
        //    {
        //        boardGame.SideP2 = 0;
        //    }
        //}

        //static bool findPlus(int typePlus, int startRow, int sideElab, BoardGame boardGame, int k, List<char[]> listCh, DataTable dtBads)
        //{
        //    int lenBranch = boardGame.getBranchPlus(sideElab);
        //    char[] c;
        //    bool isOk = false;
        //    int start = startRow + lenBranch;
        //    if (typePlus == 2)
        //    {
        //        start = lenBranch;
        //    }

        //    for (int i = start; i < listCh.Count() - lenBranch; i++)
        //    {
        //        c = listCh[i];
        //        for (int j = lenBranch; j < c.Count() - lenBranch; j++)
        //        {
        //            isOk = true;

        //            if (c[j] == 'G')
        //            {
        //                if (typePlus == 2)
        //                {
        //                    if (overLapPlus(i, j, listCh, lenBranch))
        //                    {
        //                        isOk = false;
        //                    }
        //                }

        //                if (isOk)
        //                {
        //                    if (lenBranch == 0)
        //                    {
        //                        boardGame.P1Row = i;
        //                        boardGame.P1Col = j;
        //                        return true;
        //                    }
        //                    if (elabPlus(k, i, j, lenBranch, boardGame, dtBads))
        //                    {
        //                        boardGame.P1Row = i;
        //                        boardGame.P1Col = j;
        //                        return true;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    return false;
        //}

        static bool elabPlus(int k, int row, int col, int lenBranch, BoardGame boardGame, DataTable dtBads)
        {
            int nTop = 0;
            int nRight = 0;
            int nBottom = 0;
            int nLeft = 0;

            nTop = calcTop(k, row, col, dtBads);
            if (nTop >= lenBranch) { nTop = lenBranch; }

            nRight = calcRight(boardGame, k, row, col, dtBads);
            if (nRight >= lenBranch) { nRight = lenBranch; }

            nBottom = calcBottom(boardGame, k, row, col, dtBads);
            if (nBottom >= lenBranch) { nBottom = lenBranch; }

            nLeft = calcLeft(k, row, col, dtBads);
            if (nLeft >= lenBranch) { nLeft = lenBranch; }

            if (nTop == nRight && nTop == nBottom && nTop == nLeft)
            {
                return true;
            }

            return false;
        }

        static bool overLapPlus(int i, int j, List<char[]> listCh, int lenBranch)
        {
            char[] c;

            if (i > lenBranch)
            {
                c = listCh[i - lenBranch - 1];
                if (c[j] == 'P')
                {
                    return true;
                }
            }

            c = listCh[i];
            if (j + lenBranch < c.Length - 1)
            {
                if (c[j + lenBranch + 1] == 'P')
                {
                    return true;
                }
            }

            if (j > lenBranch)
            {
                if (c[j - lenBranch - 1] == 'P')
                {
                    return true;
                }
            }

            if (i + lenBranch < listCh.Count() - 1)
            {
                c = listCh[i + lenBranch + 1];
                if (c[j] == 'P')
                {
                    return true;
                }
            }

            return false;
        }

        //while (sideElabP1 >= 1)
        //{

        //    sideElabP1 -= 2;
        //}

    }
}
