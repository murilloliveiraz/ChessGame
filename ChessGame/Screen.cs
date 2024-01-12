using ChessGame.ChessBoard;
using System;
using System.Collections.Generic;
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
                for (int j = 0; j < Board.Columns; j++) 
                {
                    if(Board.Piece(i, j) == null) 
                    {
                        Console.Write("- ");
                    } 
                    else
                    {
                        Console.Write(Board.Piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
