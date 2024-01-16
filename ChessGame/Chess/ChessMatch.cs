using System.Collections.Generic;
using ChessBoard;

namespace Chess
{
    internal class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.Branco;
            finished = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieces();
        }

        public void makeMovement(Position origin, Position destiny)
        {
            Piece piece = board.removePiece(origin);
            piece.increaseAmountOfMovements();
            Piece capturedPiece = board.removePiece(destiny);
            board.putPiece(piece, destiny);
            if(capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
        }

        public void chessMove(Position origin, Position destiny)
        {
            makeMovement(origin, destiny);
            turn++;
            changeTurn();
        }

        public void validateOriginPosition(Position pos)
        {
            if (board.piece(pos) == null)
            {
                throw new BoardExceptions("Não existe peça na posição de origem");
            }
            if (currentPlayer != board.piece(pos).color)
            {
                throw new BoardExceptions("A peça de origem escolhida não é sua");
            }
            if (!board.piece(pos).thereArePossibleMovements())
            {
                throw new BoardExceptions("Não existem movimentos possíveis para a peça na posição de origem");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny)
        {
            if(!board.piece(origin).canMoveTo(destiny))
            {
                throw new BoardExceptions("Posição de destino invalida!");
            }
        }

        private void changeTurn()
        {
            currentPlayer = (currentPlayer == Color.Branco) ? Color.Preto : Color.Branco;
        }

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece> ();
            foreach (Piece x in captured)
            {
                if(x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Piece> piecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece> ();
            foreach (Piece x in pieces)
            {
                if(x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        public void putNewPiece(char column, int line, Piece piece)
        {
            board.putPiece(piece, new ChessPosition(column, line).toBoardPosition());
            pieces.Add(piece);
        }

        private void putPieces()
        {
            putNewPiece('c', 2, new Rook(board, Color.Branco));
            putNewPiece('d', 2, new Rook(board, Color.Branco));
            putNewPiece('e', 2, new Rook(board, Color.Branco));
            putNewPiece('c', 1, new Rook(board, Color.Branco));
            putNewPiece('e', 1, new Rook(board, Color.Branco));
            putNewPiece('d', 1, new King(board, Color.Branco));
            
            putNewPiece('c', 7, new Rook(board, Color.Preto));
            putNewPiece('c', 8, new Rook(board, Color.Preto));
            putNewPiece('d', 7, new Rook(board, Color.Preto));
            putNewPiece('e', 7, new Rook(board, Color.Preto));
            putNewPiece('e', 8, new Rook(board, Color.Preto));
            putNewPiece('d', 8, new King(board, Color.Preto));
        }
    }
}
