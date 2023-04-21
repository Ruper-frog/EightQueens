using System;

namespace EightQueens
{
    internal class Program
    {
        static int Counter = 0;

        static bool[] Rows = new bool[8];
        static bool[] Columns = new bool[8];
        static bool[] Diagonal = new bool[15];
        static bool[] Diagonal2 = new bool[15];
        static void CallMeYourQueen()
        {
            bool[,] ChessBoard = new bool[8, 8];

            for (int i = 0; i < ChessBoard.GetLength(0); i++)
            {
                for (int j = 0; j < ChessBoard.GetLength(1); j++)
                {
                    if (i == 0 && j == 2)
                        ChessBoard[i, j] = true;

                    else if (i == 1 && j == 4)
                        ChessBoard[i, j] = true;

                    else if (i == 2 && j == 1)
                        ChessBoard[i, j] = true;

                    else if (i == 3 && j == 7)
                        ChessBoard[i, j] = true;

                    else if (i == 4 && j == 0)
                        ChessBoard[i, j] = true;

                    else if (i == 5 && j == 6)
                        ChessBoard[i, j] = true;

                    else if (i == 6 && j == 3)
                        ChessBoard[i, j] = true;

                    else if (i == 7 && j == 5)
                        ChessBoard[i, j] = true;

                    else
                        ChessBoard[i, j] = false;
                }
            }

        }
        static void Main(string[] args)
        {
            for (int i = 0; i < Rows.Length; i++)
                Rows[i] = false;

            for (int i = 0; i < Columns.Length; i++)
                Columns[i] = false;

            for (int i = 0; i < Diagonal.Length; i++)
                Diagonal[i] = false;

            for (int i = 0; i < Diagonal2.Length; i++)
                Diagonal2[i] = false;

            bool[,] ChessBoard = new bool[8, 8];

            for (int i = 0; i < ChessBoard.GetLength(0); i++)
            {
                for (int j = 0; j < ChessBoard.GetLength(1); j++)
                    ChessBoard[i, j] = false;
            }

            SolveEveryThingLikeABoss(ChessBoard, 0);

            Console.WriteLine("\n" + Counter);
        }
        static void SolveEveryThingLikeABoss(bool[,] Board, int QueenIndex)
        {
            if (QueenIndex == 8)
            {
                PrintQueens(Board);
                Counter++;
                return;
            }

            for (int i = 0; i < Board.GetLength(1); i++)
            {
                if (!IsEightQueensOk(i, QueenIndex))
                    continue;

                XorQueen(i, QueenIndex);

                Board[i, QueenIndex] = true;

                SolveEveryThingLikeABoss(Board, QueenIndex + 1);

                Board[i, QueenIndex] = false;

                XorQueen(i, QueenIndex);
            }
        }
        static bool IsEightQueensOk(int i, int j)
        {
            if (Rows[i])
                return false;

            if (Columns[j])
                return false;

            if (Diagonal[i - j + 7])
                return false;

            if (Diagonal2[i + j])
                return false;

            return true;
        }
        static void XorQueen(int i, int j)
        {
            Rows[i] = !Rows[i];

            Columns[j] = !Columns[j];

            Diagonal[i - j + 7] = !Diagonal[i - j + 7];

            Diagonal2[i + j] = !Diagonal2[i + j];
        }
        static void PrintQueens(bool[,] chess)
        {
            for (int i = 0; i < chess.GetLength(0); i++)
            {
                for (int j = 0; j < chess.GetLength(1); j++)
                {
                    Console.Write(chess[i, j] == true ? "1" : "0");

                    /*if (chess[i, j])
                    //{
                    //    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    //    Console.Write("X");
                    //}
                    //else
                    //{
                    //    Console.ForegroundColor = ConsoleColor.DarkRed;
                    //    Console.Write("█|");
                    //}
                    Console.ResetColor();*/
                }

                Console.WriteLine();
            }
            for (int t = 0; t < 30; t++)
                Console.Write("_");

            Console.WriteLine();
        }
    }
}
