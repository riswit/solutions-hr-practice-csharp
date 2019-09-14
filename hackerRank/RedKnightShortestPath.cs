using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    //https://www.hackerrank.com/challenges/red-knights-shortest-path/problem
    class RedKnightShortestPath
    {
        public void Execute()
        {
            //int n = 6;
            //int i_start = 6;
            //int j_start = 6;
            //int i_end = 0;
            //int j_end = 1;

            int n = 70;
            int i_start = 7;
            int j_start = 15;
            int i_end = 67;
            int j_end = 3;

            //int n = 100;
            //int i_start = 2;
            //int j_start = 24;
            //int i_end = 92;
            //int j_end = 45;

            //int n = 150;
            //int i_start = 24;
            //int j_start = 15;
            //int i_end = 46;
            //int j_end = 102;

            printShortestPath(n, i_start, j_start, i_end, j_end);
        }

        static void printShortestPath(int n, int r_start, int c_start, int r_end, int c_end)
        {
            if (r_start == r_end && Math.Abs(c_start - c_end) == 1)
            {
                Console.WriteLine("Impossible");
                return;
            }

            if (r_start == r_end 
                && ((c_start % 2 == 0 && c_end % 2 == 0) || (c_start % 2 != 0 && c_end % 2 != 0)))
            {
                Console.WriteLine("Impossible");
                return;
            }

            if (r_start != r_end
                && ((r_start % 2 == 0 && r_end % 2 != 0) || (r_start % 2 != 0 && r_end % 2 == 0)))
            {
                Console.WriteLine("Impossible");
                return;
            }

            bool[,] viewed = new bool[n, n];

            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "UL");
            dict.Add(3, "UR");
            dict.Add(4, "R");
            dict.Add(5, "LR");
            dict.Add(7, "LL");
            dict.Add(8, "L");

            Dictionary<int, List<string>> roads = new Dictionary<int, List<string>>();
            List<string> listSteps = new List<string>();
            int[] arrMove = new int[3];
            arrMove[0] = r_start;
            arrMove[1] = c_start;
            arrMove[2] = 0;
            int nRoad = 0;
            Direction d = getDirection(n, r_start, c_start, r_end, c_end);

            while (!d.Equals(Direction.Center))
            {
                arrMove = moveK(n, arrMove, d, r_end, c_end);

                if (arrMove[2] == -1)
                {
                    Console.WriteLine("Impossible");
                    return;
                }

                d = (Direction)Enum.Parse(typeof(Direction), arrMove[2].ToString());

                if (d.Equals(Direction.UpLeft)
                    || d.Equals(Direction.UpRight)
                    || d.Equals(Direction.Right)
                    || d.Equals(Direction.LowerRight)
                    || d.Equals(Direction.LowerLeft)
                    || d.Equals(Direction.Left))
                {
                    int cS = listSteps.Count();

                    if (cS > 0 && (d.Equals(Direction.Left) || d.Equals(Direction.Right)))
                    {
                        if (d.Equals(Direction.Left) && listSteps[cS - 1] == "R")
                        {
                            Console.WriteLine("Impossible");
                            return;
                        }
                        if (d.Equals(Direction.Right) && listSteps[cS - 1] == "L")
                        {
                            Console.WriteLine("Impossible");
                            return;
                        }
                    }
                    listSteps.Add(dict[(int)d]);
                }
                d = getDirection(n, arrMove[0], arrMove[1], r_end, c_end);

                if (d.Equals(Direction.none))
                {
                    break;
                }

                if (arrMove[0] == r_end && arrMove[1] == c_end)
                {
                    d = Direction.Center;
                    nRoad += 1;
                }
            }

            if (verifyLRLL(listSteps))
            {
                listSteps = listSteps.OrderByDescending(x => x).ToList();
            }

            Console.WriteLine(listSteps.Count());
            if (listSteps.Count() > 0)
            {
                Console.WriteLine(string.Join(" ", listSteps));
            }
        }

        static int[] moveK(int n, int[] arrMove, Direction d, int r_end, int c_end)
        {
            if (d.Equals(Direction.UpLeft))
            {
                if (arrMove[1] - 1 >= 0 && arrMove[0] - 2 >= 0)
                {
                    arrMove[1] -= 1;
                    arrMove[0] -= 2;
                    arrMove[2] = 1;
                }
                else
                {
                    arrMove[2] = -1;
                }
            }
            else if (d.Equals(Direction.Up))
            {
                if (arrMove[1] - 1 >= 0 && arrMove[0] - 2 >= 0)
                {
                    arrMove[1] -= 1;
                    arrMove[0] -= 2;
                    arrMove[2] = 1;
                }
                else if (arrMove[1] + 1 < n && arrMove[0] - 2 >= 0)
                {
                    arrMove[1] += 1;
                    arrMove[0] -= 2;
                    arrMove[2] = 3;
                }
                else
                {
                    arrMove[2] = -1;
                }
            }
            else if (d.Equals(Direction.UpRight))
            {
                if (arrMove[1] + 1 < n && arrMove[0] - 2 >= 0)
                {
                    arrMove[1] += 1;
                    arrMove[0] -= 2;
                    arrMove[2] = 3;
                }
                else
                {
                    arrMove[2] = -1;
                }
            }
            else if (d.Equals(Direction.Right))
            {
                if (arrMove[1] + 2 < n)
                {
                    arrMove[1] += 2;
                    arrMove[2] = 4;
                }
                else
                {
                    arrMove[2] = -1;
                }
            }
            else if (d.Equals(Direction.LowerRight))
            {
                int sR = (r_end - arrMove[0]) / 2;
                int sC = c_end - arrMove[1];

                if (arrMove[1] + 2 < n && sC - sR > 0)
                {
                    arrMove[1] += 2;
                    arrMove[2] = 4;
                }
                else if (arrMove[1] + 1 < n && arrMove[0] + 2 < n)
                {
                    arrMove[1] += 1;
                    arrMove[0] += 2;
                    arrMove[2] = 5;
                }
                else
                {
                    arrMove[2] = -1;
                }
            }
            else if (d.Equals(Direction.Down))
            {
                if (arrMove[1] + 1 < n && arrMove[0] + 2 < n)
                {
                    arrMove[1] += 1;
                    arrMove[0] += 2;
                    arrMove[2] = 5;
                }
                else if (arrMove[1] - 1 >= 0 && arrMove[0] + 2 < n)
                {
                    arrMove[1] -= 1;
                    arrMove[0] += 2;
                    arrMove[2] = 7;
                }
                else
                {
                    arrMove[2] = -1;
                }
            }
            else if (d.Equals(Direction.LowerLeft))
            {
                if (arrMove[1] - 1 >= 0 && arrMove[0] + 2 < n)
                {
                    arrMove[1] -= 1;
                    arrMove[0] += 2;
                    arrMove[2] = 7;
                }
                else
                {
                    arrMove[2] = -1;
                }
            }
            else if (d.Equals(Direction.Left))
            {
                if (arrMove[1] - 2 >= 0)
                {
                    arrMove[1] -= 2;
                    arrMove[2] = 8;
                }
                else
                {
                    arrMove[2] = -1;
                }
            }

            return arrMove;
        }

        static bool verifyLRLL(List<string> listSteps)
        {
            foreach (string e in listSteps)
            {
                if (!e.Equals("LL") && !e.Equals("LR"))
                {
                    return false;
                }
            }
            return true;
        }

        static Direction getDirection(int n, int r_start, int c_start, int r_end, int c_end)
        {
            if (r_end < r_start)
            {
                if (c_end < c_start)
                {
                    return Direction.UpLeft;
                }
                if (c_end == c_start)
                {
                    return Direction.Up;
                }

                return Direction.UpRight;
            }

            if (r_end > r_start)
            {
                if (c_end < c_start)
                {
                    return Direction.LowerLeft;
                }
                if (c_end == c_start)
                {
                    return Direction.Down;
                }

                return Direction.LowerRight;
            }

            if (r_end == r_start)
            {
                if (c_end < c_start)
                {
                    return Direction.Left;
                }
                if (c_end > c_start)
                {
                    return Direction.Right;
                }

                return Direction.Center;
            }

            return Direction.none;
        }

        enum Direction
        {
            none = 0,
            UpLeft = 1,
            Up = 2,
            UpRight = 3,
            Right = 4,
            LowerRight = 5,
            Down = 6,
            LowerLeft = 7,
            Left = 8,
            Center = 9
        }

    }
}
