using ChessBoard;
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
                while (!match.finished)
                {
                    Console.Clear();
                    Screen.showBoard(match.board);
                    Console.WriteLine();
                    Console.WriteLine("Turno: " + match.turn);
                    Console.WriteLine("Aguardando jogada do Jogador: "+ match.currentPlayer);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position origin = Screen.readChessMovement().toBoardPosition();

                    bool[,] possiblePositions = match.board.piece(origin).possibleMovements();

                    Console.Clear();
                    Screen.showBoard(match.board, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Position destiny = Screen.readChessMovement().toBoardPosition();

                    match.chessMove(origin, destiny);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERRO: " + e);
            }
        }
    }
}
