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
            ChessPosition position = new ChessPosition('c', 7);
            Console.WriteLine(position);
            Console.WriteLine(position.toBoardPosition());
        }
    }
}
