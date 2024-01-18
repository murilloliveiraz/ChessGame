using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
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
        public bool check { get; private set; }
        public Piece vulneravelEnPassant { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.Branco;
            finished = false;
            check = false;
            vulneravelEnPassant = null;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieces();
        }

        public Piece makeMovement(Position origin, Position destiny)
        {
            Piece piece = board.removePiece(origin);
            piece.increaseAmountOfMovements();
            Piece capturedPiece = board.removePiece(destiny);
            board.putPiece(piece, destiny);
            if(capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }

            //special played - kingside
            if(piece is King && destiny.column == origin.column + 2)
            {
                Position originT = new Position(origin.line, origin.column + 3);
                Position destinyT = new Position(origin.line, origin.column + 1);
                Piece T = board.removePiece(originT);
                T.increaseAmountOfMovements();
                board.putPiece(T, destinyT);
            }
            
            //special played - queenside
            if(piece is King && destiny.column == origin.column - 2)
            {
                Position originT = new Position(origin.line, origin.column - 4);
                Position destinyT = new Position(origin.line, origin.column - 1);
                Piece T = board.removePiece(originT);
                T.increaseAmountOfMovements();
                board.putPiece(T, destinyT);
            }

            //#En Passant
            if (piece is Pawn)
            {
                if (origin.column != destiny.column && capturedPiece == null)
                {
                    Position posP;
                    if (piece.color == Color.Branco)
                    {
                        posP = new Position(destiny.line + 1, destiny.column);
                    }
                    else
                    {
                        posP = new Position(destiny.line - 1, destiny.column);
                    }
                    capturedPiece = board.removePiece(posP);
                    captured.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }

        public void undoMove(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = board.removePiece(destiny);
            p.decreaseAmountOfMovements();
            if (capturedPiece != null)
            {
                board.putPiece(capturedPiece, destiny);
                captured.Remove(capturedPiece);
            }
            board.putPiece(p, origin);

            //special played - kingside
            if (p is King && destiny.column == origin.column + 2)
            {
                Position originT = new Position(origin.line, origin.column + 3);
                Position destinyT = new Position(origin.line, origin.column + 1);
                Piece T = board.removePiece(destinyT);
                T.decreaseAmountOfMovements();
                board.putPiece(T, originT);
            }

            //special played - queenside
            if (p is King && destiny.column == origin.column - 2)
            {
                Position originT = new Position(origin.line, origin.column - 4);
                Position destinyT = new Position(origin.line, origin.column - 1);
                Piece T = board.removePiece(destinyT);
                T.decreaseAmountOfMovements();
                board.putPiece(T, originT);
            }

            // En passant
            if (p is Pawn)
            {
                if(origin.column != destiny.column && capturedPiece == vulneravelEnPassant)
                {
                    Piece pawn = board.removePiece(destiny);
                    Position posP;
                    if(p.color == Color.Branco)
                    {
                        posP = new Position(3, destiny.column);
                    }
                    else
                    {
                        posP = new Position(4, destiny.column);
                    }
                    board.putPiece(pawn, posP);
                }
            }
        }

        public void chessMove(Position origin, Position destiny)
        {
            Piece captured = makeMovement(origin, destiny);

            if(areInCheck(currentPlayer))
            {
                undoMove(origin, destiny, captured);
                throw new BoardExceptions("Voce nao pode se colocar em xeque");
            }

            Piece p = board.piece(destiny);

            //special play - Promotion
            if (p is Pawn)
            {
                if ((p.color == Color.Branco && destiny.line == 0) || (p.color == Color.Preto && destiny.line == 7))
                {
                    p = board.removePiece(destiny);
                    pieces.Remove(p);
                    Piece queen = new Queen(board, p.color);
                    board.putPiece(queen, destiny);
                    pieces.Add(queen);
                }
            }

            if (areInCheck(opponent(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (testCheckmate(opponent(currentPlayer))){
                finished = true;
            }
            else
            {
                turn++;
                changeTurn();
            }

            //# Special Play - En Passant
            if(p is Pawn && (destiny.line == origin.line - 2) || (destiny.line == origin.line + 2))
            {
                vulneravelEnPassant = p;
            }
            else
            {
                vulneravelEnPassant = null;
            }
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
            if(!board.piece(origin).isPossibleToMove(destiny))
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

        private Color opponent(Color color)
        {
            if (color == Color.Branco)
            {
                return Color.Preto;
            }
            else
            {
                return Color.Branco;
            }
        }

        private Piece King(Color color)
        {
            foreach(Piece x in piecesInGame(color))
            {
                if(x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool areInCheck(Color color)
        {
            Piece K = King(color);
            if (K == null)
            {
                throw new BoardExceptions("Não existe rei da cor "+ color + " no tabuleiro");
            }
            foreach (Piece x in piecesInGame(opponent(color)))
            {
                bool[,] mat = x.possibleMovements();
                if (mat[K.position.line, K.position.column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testCheckmate(Color color)
        {
            if (!areInCheck(color))
            {
                return false;
            }
            foreach (Piece x in piecesInGame(color))
            {
                bool[,] mat = x.possibleMovements();
                for (int i = 0; i < board.lines; i++)
                {
                    for (int j = 0; i < board.columns; i++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.position;
                            Position destiny = new Position(i, j);
                            Piece captured = makeMovement(origin, destiny);
                            bool testCheck = areInCheck(color);
                            undoMove(origin, destiny, captured);
                            if(!testCheck)
                            {
                                return false;
                            }
                        }
                    }

                }
            }
            return true;
        }

        public void putNewPiece(char column, int line, Piece piece)
        {
            board.putPiece(piece, new ChessPosition(column, line).toBoardPosition());
            pieces.Add(piece);
        }
        private void putPieces()
        {
            putNewPiece('a', 1, new Rook(board, Color.Branco));
            putNewPiece('b', 1, new Knight(board, Color.Branco));
            putNewPiece('c', 1, new Bishop(board, Color.Branco));
            putNewPiece('d', 1, new Queen(board, Color.Branco));
            putNewPiece('e', 1, new King(board, Color.Branco, this));
            putNewPiece('f', 1, new Bishop(board, Color.Branco));
            putNewPiece('g', 1, new Knight(board, Color.Branco));
            putNewPiece('h', 1, new Rook(board, Color.Branco));
            putNewPiece('a', 2, new Pawn(board, Color.Branco, this));
            putNewPiece('b', 2, new Pawn(board, Color.Branco, this));
            putNewPiece('c', 2, new Pawn(board, Color.Branco, this));
            putNewPiece('d', 2, new Pawn(board, Color.Branco, this));
            putNewPiece('e', 2, new Pawn(board, Color.Branco, this));
            putNewPiece('f', 2, new Pawn(board, Color.Branco, this));
            putNewPiece('g', 2, new Pawn(board, Color.Branco, this));
            putNewPiece('h', 2, new Pawn(board, Color.Branco, this));

            putNewPiece('a', 8, new Rook(board, Color.Preto));
            putNewPiece('b', 8, new Knight(board, Color.Preto));
            putNewPiece('c', 8, new Bishop(board, Color.Preto));
            putNewPiece('d', 8, new Queen(board, Color.Preto));
            putNewPiece('e', 8, new King(board, Color.Preto, this));
            putNewPiece('f', 8, new Bishop(board, Color.Preto));
            putNewPiece('g', 8, new Knight(board, Color.Preto));
            putNewPiece('h', 8, new Rook(board, Color.Preto));
            putNewPiece('a', 7, new Pawn(board, Color.Preto, this));
            putNewPiece('b', 7, new Pawn(board, Color.Preto, this));
            putNewPiece('c', 7, new Pawn(board, Color.Preto, this));
            putNewPiece('d', 7, new Pawn(board, Color.Preto, this));
            putNewPiece('e', 7, new Pawn(board, Color.Preto, this));
            putNewPiece('f', 7, new Pawn(board, Color.Preto, this));
            putNewPiece('g', 7, new Pawn(board, Color.Preto, this));
            putNewPiece('h', 7, new Pawn(board, Color.Preto, this));
        }
    }
}
