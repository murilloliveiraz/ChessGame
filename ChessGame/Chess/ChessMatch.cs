using ChessGame.ChessBoard;
using ChessBoard;
using System;
using System.Runtime.ConstrainedExecution;

namespace Chess
{
    internal class ChessMatch
    {
        public Board board { get; private set; }
        private int Turn;
        private Color CurrentPlayer;
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            putPieces();
        }

        public void makeMovement(Position origin, Position destiny)
        {
            Piece piece = board.RemovePiece(origin);
            piece.IncreaseAmountOfMovements();
            Piece CapturedPiece = board.RemovePiece(destiny);
            board.PutPiece(piece, destiny);
        }
        private void putPieces() 
        {
            board.PutPiece(new Rook(board, Color.White), new ChessPosition('c', 1).toBoardPosition());
            board.PutPiece(new Rook(board, Color.White), new ChessPosition('c', 2).toBoardPosition());
            board.PutPiece(new Rook(board, Color.White), new ChessPosition('d', 2).toBoardPosition());
            board.PutPiece(new Rook(board, Color.White), new ChessPosition('e', 2).toBoardPosition());
            board.PutPiece(new Rook(board, Color.White), new ChessPosition('e', 1).toBoardPosition());
            board.PutPiece(new King(board, Color.White), new ChessPosition('d', 1).toBoardPosition());

            board.PutPiece(new Rook(board, Color.Black), new ChessPosition('c', 7).toBoardPosition());
            board.PutPiece(new Rook(board, Color.Black), new ChessPosition('c', 8).toBoardPosition());
            board.PutPiece(new Rook(board, Color.Black), new ChessPosition('d', 7).toBoardPosition());
            board.PutPiece(new Rook(board, Color.Black), new ChessPosition('e', 7).toBoardPosition());
            board.PutPiece(new Rook(board, Color.Black), new ChessPosition('e', 8).toBoardPosition());
            board.PutPiece(new King(board, Color.Black), new ChessPosition('d', 8).toBoardPosition());
        }
    }
}
