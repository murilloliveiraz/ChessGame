using ChessBoard;

namespace ChessGame.ChessBoard
{
    internal class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[Columns, Lines];
        }

        public Piece Piece(int line, int column) 
        {
            return Pieces[line, column];
        }
        public Piece Piece(Position position) 
        {
            return Pieces[position.Line, position.Column];
        }

        public void PutPiece(Piece piece, Position position)
        {
            if(IsPositionOccupied(position))
            {
                throw new BoardExceptions("Já existe uma peça nessa posição!");
            }
            Pieces[position.Line, position.Column] = piece;
        }

        public bool IsPositionValid(Position position)
        {
            if(position.Line < 0 || position.Line > Lines || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public bool IsPositionOccupied(Position position)
        {
            validatePosition(position);
            return Piece(position) != null;
        }

        public void validatePosition(Position position)
        {
            if (!IsPositionValid(position)) throw new BoardExceptions("Posição Inválida");
        }
    }
}
