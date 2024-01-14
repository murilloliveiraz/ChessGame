using ChessBoard;
using ChessGame.ChessBoard;

namespace Chess
{
    internal class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {
        }
        public override string ToString()
        {
            return "R";
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
            if (Board.IsPositionValid(position) && canMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            //notheast
            position.SetValues(position.Line - 1, position.Column + 1);
            if (Board.IsPositionValid(position) && canMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            //right
            position.SetValues(position.Line, position.Column + 1);
            if (Board.IsPositionValid(position) && canMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            //southeast
            position.SetValues(position.Line + 1, position.Column - 1);
            if (Board.IsPositionValid(position) && canMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            //down
            position.SetValues(position.Line + 1, position.Column);
            if (Board.IsPositionValid(position) && canMove(position))
            {
                mat[position.Line, position.Column] = true;
            }
            //south-west
            position.SetValues(position.Line + 1, position.Column - 1);
            if (Board.IsPositionValid(position) && canMove(position))
            {
                mat[position.Line, position.Column] = true;
            }
            //left
            position.SetValues(position.Line, position.Column - 1);
            if (Board.IsPositionValid(position) && canMove(position))
            {
                mat[position.Line, position.Column] = true;
            }
            //northwest
            position.SetValues(position.Line - 1, position.Column - 1);
            if (Board.IsPositionValid(position) && canMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            return mat;
        }
    }
}
