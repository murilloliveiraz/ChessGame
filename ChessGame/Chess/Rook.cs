using ChessBoard;
using ChessGame.ChessBoard;
using System.Runtime.ConstrainedExecution;

namespace Chess
{
    internal class Rook : Piece
    {
        public Rook( Board board, Color color) : base(board, color)
        {
        }
        public override string ToString()
        {
            return "T";
        }

        private bool canMove(Position position)
        {
        Piece p = Board.Piece(position);
        return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            //up
            position.SetValues(position.Line - 1, position.Column);
            while (Board.IsPositionValid(position) && canMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line = position.Line - 1;
            }
            
            //abaixo
            position.SetValues(position.Line + 1, position.Column);
            while (Board.IsPositionValid(position) && canMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line = position.Line + 1;
            }
            //right
            position.SetValues(position.Line, position.Column + 1);
            while (Board.IsPositionValid(position) && canMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column = position.Column + 1;
            }
            //left
            position.SetValues(position.Line, position.Column - 1);
            while (Board.IsPositionValid(position) && canMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column = position.Column - 1;
            }
            return mat;
        }
    }
}
