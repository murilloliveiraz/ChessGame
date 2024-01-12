using ChessBoard;
using ChessGame.ChessBoard;
using Chess;
using System;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();
                /*board.PutPiece(new Rook(board, Color.Black), new Position(0, 0));
                board.PutPiece(new Rook(board, Color.Black), new Position(1, 3));
                board.PutPiece(new King(board, Color.Black), new Position(0, 2));

                board.PutPiece(new Rook(board, Color.White), new Position(3, 5));*/
                Screen.showBoard(match.board);
            }
            catch(Exception e)
            {
                Console.WriteLine("ERRO: " + e);
            }
        }
    }
}
