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
            int n = 6;
            int i_start = 6;
            int i_end = 6;
            int j_start = 0;
            int j_end = 1;
            printShortestPath(n, i_start, j_start, i_end, j_end);
        }

        static void printShortestPath(int n, int i_start, int j_start, int i_end, int j_end)
        {
            //if (i_start != j_start && ((i_start % 2 == 0 && j_start % 2 != 0) 
            //                        || (i_start % 2 != 0 && j_start % 2 == 0)))
            //{
            //    Console.WriteLine("Impossible");
            //    return;
            //}

            //if (i_end != j_end && ((i_end % 2 == 0 && j_end % 2 == 0)
            //                    || (i_end % 2 != 0 && j_end % 2 != 0)))
            //{
            //    Console.WriteLine("Impossible");
            //    return;
            //}

            if (i_start == j_start && Math.Abs(j_start - j_end) == 1)
            {
                Console.WriteLine("Impossible");
                return;
            }

            if (i_start == j_start 
                && (i_end % 2 == 0 && j_end % 2 == 0))
            {
                Console.WriteLine("Impossible");
                return;
            }

            Direction d = getDirection(n, i_start, j_start, i_end, j_end);

            int stepsUpDown = 0;
            if (i_start != i_end)
            {
                stepsUpDown = Math.Abs(i_start - i_end) / 2;
            }

        }


        static Direction getDirection(int n, int i_start, int j_start, int i_end, int j_end)
        {
            if (i_end < i_start)
            {
                if (j_end < j_start)
                {
                    return Direction.UpLeft;
                }
                if (j_end == j_start)
                {
                    return Direction.Up;
                }

                return Direction.UpRight;
            }

            if (i_end > i_start)
            {
                if (j_end < j_start)
                {
                    return Direction.LowerLeft;
                }
                if (j_end == j_start)
                {
                    return Direction.Down;
                }

                return Direction.LowerRight;
            }

            if (i_end == i_start)
            {
                if (j_end < j_start)
                {
                    return Direction.Left;
                }

                return Direction.Right;
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
            Left = 8
        }

    }
}
