using ChessBoard;

namespace Chess
{
    internal class ChessMatch
    {
        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool finished { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
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
        private void putPieces()
        {
            board.putPiece(new Rook(board, Color.White), new ChessPosition('c', 1).toBoardPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('c', 2).toBoardPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('d', 2).toBoardPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('e', 2).toBoardPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('e', 1).toBoardPosition());
            board.putPiece(new King(board, Color.White), new ChessPosition('d', 1).toBoardPosition());

            board.putPiece(new Rook(board, Color.Black), new ChessPosition('c', 7).toBoardPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('c', 8).toBoardPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('d', 7).toBoardPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('e', 7).toBoardPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('e', 8).toBoardPosition());
            board.putPiece(new King(board, Color.Black), new ChessPosition('d', 8).toBoardPosition());
        }
    }
}
