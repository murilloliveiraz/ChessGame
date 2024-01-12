using ChessGame.ChessBoard;
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
                    if(Board.Piece(i, j) == null) 
                    {
                        Console.Write("- ");
                    } 
                    else
                    {
                        Screen.ShowPiece(Board.Piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ShowPiece(Piece piece)
        {
            if(piece.Color == Color.White)
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
        }
    }
}
