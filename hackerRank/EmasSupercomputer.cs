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

            string[] grid = { "GGGGGGGG", "GBGBGGBG", "GBGBGGBG", "GGGGGGGG", "GBGBGGBG", "GGGGGGGG", "GBGBGGBG", "GGGGGGGG" };
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
            int res = 0;

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

            bool isElabGrid = false;
            int sideElab = 0;

            while (!isElabGrid)
            {
                sideElab = boardGame.SidePlus;
                tryFindPlus(boardGame, sideElab, k, listCh, dtBads);

                while (!boardGame.FoundPlus1 || !boardGame.FoundPlus2)
                {
                    sideElab = boardGame.SideP1 - 2;

                    if (sideElab < 1)
                    {
                        break;
                    }
                    tryFindPlus(boardGame, sideElab, k, listCh, dtBads);
                }

                if (boardGame.FoundPlus1 && boardGame.FoundPlus2)
                {
                    isElabGrid = true;
                }
                else
                {
                    boardGame.StartPlusRow += 1;
                    if (boardGame.StartPlusRow >= listCh.Count())
                    {
                        isElabGrid = true;
                    }
                }
            }

            res = getAreaPlus(boardGame.SideP1) * getAreaPlus(boardGame.SideP2);

            if (res < 0)
            {
                return 0;
            }

            return res;
        }

        static int getAreaPlus(int side)
        {
            if (side == 1)
            {
                return 1; 
            }
            return ((side - 1) * 2) + 1;
        }

        static void tryFindPlus(BoardGame boardGame, int sideElab, int k, List<char[]> listChOrig, DataTable dtBads)
        {
            while (sideElab >= 1)
            {
                boardGame.SideP1 = sideElab;
                boardGame.FoundPlus1 = findPlus(1, boardGame.StartPlusRow, boardGame.SideP1, boardGame, k, listChOrig, dtBads);

                if (boardGame.FoundPlus1)
                {
                    break;
                }

                sideElab -= 2;
            }

            if (!boardGame.FoundPlus1)
            {
                return;
            }

            char[] c;
            List<char[]> listCh2 = new List<char[]>();
            for (int i = 0; i < listChOrig.Count(); i++)
            {
                c = listChOrig[i].ToArray();
                listCh2.Add(c);
            }

            DataTable dtBadsMorePlus = addMorePlusToDtBads(dtBads, boardGame, listCh2);

            boardGame.FoundPlus2 = false;
            sideElab = boardGame.SidePlus;
            while (sideElab >= 1)
            {
                boardGame.SideP2 = sideElab;
                boardGame.FoundPlus2 = findPlus(2, 0, boardGame.SideP2, boardGame, k, listCh2, dtBadsMorePlus);

                if (boardGame.FoundPlus2)
                {
                    break;
                }

                sideElab -= 2;
            }

            if (!boardGame.FoundPlus2)
            {
                boardGame.SideP2 = 0;
            }
        }

        static bool findPlus(int typePlus, int startRow, int sideElab, BoardGame boardGame, int k, List<char[]> listCh, DataTable dtBads)
        {
            int lenBranch = boardGame.getBranchPlus(sideElab);
            char[] c;
            bool isOk = false;
            int start = startRow + lenBranch;
            if (typePlus == 2)
            {
                start = lenBranch;
            }

            for (int i = start; i < listCh.Count() - lenBranch; i++)
            {
                c = listCh[i];
                for (int j = lenBranch; j < c.Count() - lenBranch; j++)
                {
                    isOk = true;

                    if (c[j] == 'G')
                    {
                        if (typePlus == 2)
                        {
                            if (overLapPlus(i, j, listCh, lenBranch))
                            {
                                isOk = false;
                            }
                        }

                        if (isOk)
                        {
                            if (lenBranch == 0)
                            {
                                boardGame.P1Row = i;
                                boardGame.P1Col = j;
                                return true;
                            }
                            if (elabPlus(k, i, j, lenBranch, boardGame, dtBads))
                            {
                                boardGame.P1Row = i;
                                boardGame.P1Col = j;
                                return true;
                            }
                        }
                    }
                }
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

        static DataTable addMorePlusToDtBads(DataTable dtBads, BoardGame boardGame, List<char[]> listCh2)
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

            int lenBranch = boardGame.getBranchPlus(boardGame.SideP1);

            newRow = dtBadsMorePlus.NewRow();
            newRow[0] = boardGame.P1Row;
            newRow[1] = boardGame.P1Col;
            dtBadsMorePlus.Rows.Add(newRow);

            char[] c = listCh2[boardGame.P1Row];
            c[boardGame.P1Col] = 'P';

            for (int i = boardGame.P1Row - 1; i >= (boardGame.P1Row - lenBranch); i--)
            {
                newRow = dtBadsMorePlus.NewRow();
                newRow[0] = i;
                newRow[1] = boardGame.P1Col;
                dtBadsMorePlus.Rows.Add(newRow);

                c = listCh2[i];
                c[boardGame.P1Col] = 'P';
            }
            for (int j = boardGame.P1Col + 1; j <= (boardGame.P1Col + lenBranch); j++)
            {
                newRow = dtBadsMorePlus.NewRow();
                newRow[0] = boardGame.P1Row;
                newRow[1] = j;
                dtBadsMorePlus.Rows.Add(newRow);

                c = listCh2[boardGame.P1Row];
                c[j] = 'P';
            }
            for (int i = boardGame.P1Row + 1; i <= (boardGame.P1Row + lenBranch); i++)
            {
                newRow = dtBadsMorePlus.NewRow();
                newRow[0] = i;
                newRow[1] = boardGame.P1Col;
                dtBadsMorePlus.Rows.Add(newRow);

                c = listCh2[i];
                c[boardGame.P1Col] = 'P';
            }
            for (int j = boardGame.P1Col - 1; j >= (boardGame.P1Col - lenBranch); j--)
            {
                newRow = dtBadsMorePlus.NewRow();
                newRow[0] = boardGame.P1Row;
                newRow[1] = j;
                dtBadsMorePlus.Rows.Add(newRow);

                c = listCh2[boardGame.P1Row];
                c[j] = 'P';
            }

            return dtBadsMorePlus;
        }

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
            private int sidePlus;
            private int branchPlus;

            private int sideP1 = 0;
            private int sideP2 = 0;
            private bool foundPlus1 = false;
            private bool foundPlus2 = false;
            private int p1Row = 0;
            private int p1Col = 0;

            private int startPlusRow = 0;
            private int startPlusCol = 0;

            public BoardGame(string[] grid, int k)
            {
                this.Cols = grid[0].ToCharArray().Length;
                this.Rows = grid.Length;
                this.SidePlus = getSidePlus(rows, cols, k);
                this.branchPlus = getBranchPlus(sidePlus);
            }

            public int Rows { get => rows; set => rows = value; }
            public int SidePlus { get => sidePlus; set => sidePlus = value; }
            public int Cols { get => cols; set => cols = value; }
            public int BranchPlus { get => branchPlus; set => branchPlus = value; }
            public int SideP1 { get => sideP1; set => sideP1 = value; }
            public int SideP2 { get => sideP2; set => sideP2 = value; }
            public bool FoundPlus1 { get => foundPlus1; set => foundPlus1 = value; }
            public bool FoundPlus2 { get => foundPlus2; set => foundPlus2 = value; }
            public int P1Row { get => p1Row; set => p1Row = value; }
            public int P1Col { get => p1Col; set => p1Col = value; }
            public int StartPlusRow { get => startPlusRow; set => startPlusRow = value; }
            public int StartPlusCol { get => startPlusCol; set => startPlusCol = value; }

            public int getSidePlus(int rows, int cols, int k)
            {
                int areaGood = (rows * cols) - k;
                if (areaGood == 0)
                {
                    return 0;
                }
                int lenPlus = (int)(Math.Sqrt(areaGood));

                if (lenPlus % 2 == 0)
                {
                    lenPlus -= 1;
                }
                return lenPlus;
            }

            public int getBranchPlus(int side)
            {
                if (side == 1)
                {
                    return 0;
                }
                return (int)(side - 1) / 2;
            }

        }


    }
}
