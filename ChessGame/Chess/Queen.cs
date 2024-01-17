using ChessBoard;

namespace Chess
{

    class Queen : Piece
    {

        public Queen(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "D";
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

            // Left
            pos.setValues(position.line, position.column - 1);
            while (board.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.line, pos.column - 1);
            }

            // Right
            pos.setValues(position.line, position.column + 1);
            while (board.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.line, pos.column + 1);
            }

            // Up
            pos.setValues(position.line - 1, position.column);
            while (board.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.line - 1, pos.column);
            }

            // Down
            pos.setValues(position.line + 1, position.column);
            while (board.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.line + 1, pos.column);
            }

            // Northwest (NO)
            pos.setValues (position.line - 1, position.column - 1);
            while (board.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.line - 1, pos.column - 1);
            }

            // Northeast (NE)
            pos.setValues(position.line - 1, position.column + 1);
            while (board.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.line - 1, pos.column + 1);
            }

            // Southeast (SE)
            pos.setValues(position.line + 1, position.column + 1);
            while (board.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.line + 1, pos.column + 1);
            }

            // Southwest (SW)
            pos.setValues(position.line + 1, position.column - 1);
            while (board.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.line + 1, pos.column - 1);
            }

            return mat;
        }
    }
}
