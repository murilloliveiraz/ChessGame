using ChessBoard;
using Chess;
using System;

namespace ChessGame
{
    internal class Screen
    {
        public static void showBoard(Board board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    showPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void showBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor original = Console.BackgroundColor;
            ConsoleColor alternative = ConsoleColor.DarkGray;


            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = alternative;
                    }
                    else
                    {
                        Console.BackgroundColor = original;
                    }
                    showPiece(board.piece(i, j));
                    Console.BackgroundColor = original;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = original;
        }

        public static ChessPosition readChessMovement()
        {
            string movement = Console.ReadLine();
            char column = movement[0];
            int line = int.Parse(movement[1] + "");
            return new ChessPosition(column, line);
        }

        public static void showPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}

