using ChessGame.ChessBoard;
using Chess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class Screen
    {
        public static void showBoard(Board Board)
        {
            for(int i = 0; i < Board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < Board.Columns; j++) 
                {
                    ShowPiece(Board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void showBoard(Board Board, bool[,] possibleMovements)
        {
            ConsoleColor Original = Console.BackgroundColor;
            ConsoleColor Alternative = ConsoleColor.DarkGray;

            for(int i = 0; i < Board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < Board.Columns; j++) 
                {
                    if (possibleMovements[i,j])
                    {
                        Console.BackgroundColor = Alternative;
                    }
                    else
                    {
                        Console.BackgroundColor = Original;
                    }
                    ShowPiece(Board.Piece(i, j));
                    Console.BackgroundColor = Original;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = Original;
        }

        public static void ShowPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
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

        public static ChessPosition ReadChessMovement()
        {
            string movement = Console.ReadLine();
            char column = movement[0];
            int line = int.Parse(movement[1] + "");
            return new ChessPosition(column, line);
        }
    }
}
