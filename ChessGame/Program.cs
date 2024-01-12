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
                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.showBoard(match.board);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position origin = Screen.ReadChessMovement().toBoardPosition();
                    Console.Write("Destino: ");
                    Position destiny = Screen.ReadChessMovement().toBoardPosition();

                    match.makeMovement(origin, destiny);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("ERRO: " + e);
            }
        }
    }
}
