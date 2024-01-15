﻿using ChessBoard;

namespace Chess
{
    internal class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.Branco;
            finished = false;
            putPieces();
        }

        public void makeMovement(Position origin, Position destiny)
        {
            Piece piece = board.removePiece(origin);
            piece.increaseAmountOfMovements();
            Piece capturedPiece = board.removePiece(destiny);
            board.putPiece(piece, destiny);
        }

        public void chessMove(Position origin, Position destiny)
        {
            makeMovement(origin, destiny);
            turn++;
            changeTurn();
        }

        private void changeTurn()
        {
            if(currentPlayer == Color.Branco)
            {
                currentPlayer = Color.Preto;
            }
            else
            {
                currentPlayer = Color.Branco;
            }
        }

        private void putPieces()
        {
            board.putPiece(new Rook(board, Color.Branco), new ChessPosition('c', 1).toBoardPosition());
            board.putPiece(new Rook(board, Color.Branco), new ChessPosition('c', 2).toBoardPosition());
            board.putPiece(new Rook(board, Color.Branco), new ChessPosition('d', 2).toBoardPosition());
            board.putPiece(new Rook(board, Color.Branco), new ChessPosition('e', 2).toBoardPosition());
            board.putPiece(new Rook(board, Color.Branco), new ChessPosition('e', 1).toBoardPosition());
            board.putPiece(new King(board, Color.Branco), new ChessPosition('d', 1).toBoardPosition());

            board.putPiece(new Rook(board, Color.Preto), new ChessPosition('c', 7).toBoardPosition());
            board.putPiece(new Rook(board, Color.Preto), new ChessPosition('c', 8).toBoardPosition());
            board.putPiece(new Rook(board, Color.Preto), new ChessPosition('d', 7).toBoardPosition());
            board.putPiece(new Rook(board, Color.Preto), new ChessPosition('e', 7).toBoardPosition());
            board.putPiece(new Rook(board, Color.Preto), new ChessPosition('e', 8).toBoardPosition());
            board.putPiece(new King(board, Color.Preto), new ChessPosition('d', 8).toBoardPosition());
        }
    }
}