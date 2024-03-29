﻿using ChessBoard;
using Chess;
using System;
using System.Security.Cryptography;

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
                    try
                    {
                        Console.Clear();
                        Screen.startMatch(match);
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origin = Screen.readChessMovement().toBoardPosition();
                        match.validateOriginPosition(origin);
                        
                        bool[,] possiblePositions = match.board.piece(origin).possibleMovements();

                        Console.Clear();
                        Screen.showBoard(match.board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position destiny = Screen.readChessMovement().toBoardPosition();
                        match.validateDestinyPosition(origin, destiny);

                        match.chessMove(origin, destiny);
                    }
                    catch (BoardExceptions e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.startMatch(match);
            }
            catch (BoardExceptions e)
            {
                Console.WriteLine("ERRO: " + e);
            }
        }
    }
}
