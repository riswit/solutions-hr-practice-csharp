using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace hackerRank
{
    class TheBombermanGame
    {
        public void Execute()
        {
            int n = 27;
            string[] grid = { ".......", "...O...", "....O..", ".......", "OO....O", "OO....." };
            string[] resExp = { "OOO.OOO", "OO...OO", "OOO...O", "..OO.O.", "...OO..", "...OOO." };

            string[] result = bomberMan(n, grid);

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore - Expected: " + string.Join(" ", resExp) + " - now: " + string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
                Console.WriteLine(string.Join(" ", result));
            }
        }

        static string[] bomberMan(int n, string[] grid)
        {
            string[] res = { };
            int cBoom = 0;
            int cPut = 0;
            bool isPut2 = false;
            bool isBum2 = false;
            int lim = 9;

            List<char[]> listCh = new List<char[]>();
            for (int i = 0; i < grid.Length; i++)
            {
                listCh.Add(grid[i].Replace("O", "0").ToCharArray());
            }

            for (long s = 2; s <= n; s++)
            {
                if (s % 2 == 0)
                {
                    if (cPut == 0)
                    {
                        cPut = 2;
                        isPut2 = true;
                    }
                    else
                    {
                        if (isPut2)
                        {
                            cPut = 3;
                            isPut2 = false;
                        }
                        else
                        {
                            cPut = 2;
                            isPut2 = true;
                        }
                    }
                    listCh = putBomb(cPut, listCh);
                }
                else
                {
                    if (cBoom != 0)
                    {
                        if (isBum2)
                        {
                            cBoom = 3;
                            isBum2 = false;
                        }
                        else
                        {
                            cBoom = 2;
                            isBum2 = true;
                        }
                    }
                    listCh = boom(cBoom, listCh);
                    if (cBoom == 0)
                    {
                        cBoom = 2;
                    }
                }

                if (n > lim && s == lim)
                {
                    long d = (long)((n - lim) / 4L);
                    s = (4L * d) + 9L;
                }
            }

            Regex regex = new Regex("[0-9]");

            for (int i = 0; i < grid.Length; i++)
            {
                grid[i] = regex.Replace(new string(listCh[i]), "O");
            }

            return grid;
        }

        static List<char[]> putBomb(int s, List<char[]> listCh)
        {
            for (int i = 0; i < listCh.Count(); i++)
            {
                listCh[i] = (new string (listCh[i])).Replace(".", s.ToString()).ToCharArray();
            }
            return listCh;
        }

        static List<char[]> boom(int s, List<char[]> listChOrig)
        {
            int ind = 0;
            char[] c;
            char[] c1;

            List<char[]> listCh2 = new List<char[]>();
            for (int i = 0; i < listChOrig.Count(); i++)
            {
                c = listChOrig[i].ToArray();
                listCh2.Add(c);
            }

            for (int i = 0; i < listCh2.Count(); i++)
            {
                c = listCh2[i];

                ind = Array.FindIndex(listChOrig[i], 0, e => e == char.Parse(s.ToString()));

                while (ind > -1)
                {
                    c[ind] = '.';

                    if (i > 0)
                    {
                        c1 = listCh2[i - 1];
                        c1[ind] = 'X';
                    }
                    if (ind < c.Count() - 1)
                    {
                        c[ind + 1] = 'X';
                    }
                    if (i < listCh2.Count() - 1)
                    {
                        c1 = listCh2[i + 1];
                        c1[ind] = 'X';
                    }
                    if (ind > 0)
                    {
                        c[ind - 1] = 'X';
                    }

                    ind = Array.FindIndex(listChOrig[i], ind + 1, e => e == char.Parse(s.ToString()));
                }

            }

            for (int i = 0; i < listCh2.Count(); i++)
            {
                listCh2[i] = (new string(listCh2[i])).Replace("X", ".").ToCharArray();
            }

            return listCh2;
        }

    }
}
