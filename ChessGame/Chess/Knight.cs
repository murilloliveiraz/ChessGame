using ChessBoard;

namespace Chess
{

    class Knight : Piece
    {

        public Knight(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "C";
        }

        private bool CanMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            pos.setValues(position.line - 1, position.column - 2);
            if (board.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.setValues(position.line - 2, position.column - 1);
            if (board.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.setValues(position.line - 2, position.column + 1);
            if (board.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.setValues(position.line - 1, position.column + 2);
            if (board.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.setValues(position.line + 1, position.column + 2);
            if (board.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.setValues(position.line + 2, position.column + 1);
            if (board.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.setValues(position.line + 2, position.column - 1);
            if (board.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.setValues(position.line + 1, position.column - 2);
            if (board.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            return mat;
        }
    }
}
