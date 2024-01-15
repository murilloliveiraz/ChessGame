using ChessBoard;

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
            Piece p = board.piece(position);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            // up
            pos.setValues(position.line - 1, position.column);
            if (board.isPositionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // northeast
            pos.setValues(position.line - 1, position.column + 1);
            if (board.isPositionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // right
            pos.setValues(position.line, position.column + 1);
            if (board.isPositionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // southeast
            pos.setValues(position.line + 1, position.column + 1);
            if (board.isPositionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // down
            pos.setValues(position.line + 1, position.column);
            if (board.isPositionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // southwest
            pos.setValues(position.line + 1, position.column - 1);
            if (board.isPositionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // left
            pos.setValues(position.line, position.column - 1);
            if (board.isPositionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // northwest
            pos.setValues(position.line - 1, position.column - 1);
            if (board.isPositionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            return mat;
        }
    }
}
