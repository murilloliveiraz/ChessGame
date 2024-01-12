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
            Board ChessBoard = new Board(8, 8);
            ChessBoard.PutPiece(new Rook(Color.Black, ChessBoard), new Position(0, 0));
            ChessBoard.PutPiece(new Rook(Color.Black, ChessBoard), new Position(1, 3));
            ChessBoard.PutPiece(new King(Color.Black, ChessBoard), new Position(2, 4));
            Screen.showBoard(ChessBoard);
        }
    }
}
