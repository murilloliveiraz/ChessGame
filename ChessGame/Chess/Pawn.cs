using ChessBoard;

namespace Chess
{

    class Pawn : Piece
    {

        public Pawn(Board tab, Color cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool thereIsOpponent(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }

        private bool canMove(Position pos)
        {
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[board.lines, board.columns];
            Position pos = new Position(0, 0);

            if (color == Color.Branco)
            {
                pos.setValues(position.line - 1, position.column);
                if (board.isPositionValid(pos) && canMove(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line - 2, position.column);
                Position p2 = new Position(position.line - 1, position.column);
                if (board.isPositionValid(p2) && canMove(p2) && board.isPositionValid(pos) && canMove(pos) && amountOfMovements == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line - 1, position.column - 1);
                if (board.isPositionValid(pos) && thereIsOpponent(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line - 1, position.column + 1);
                if (board.isPositionValid(pos) && thereIsOpponent(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
            }
            else
            {
                pos.setValues(position.line + 1, position.column);
                if (board.isPositionValid(pos) && canMove(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line + 2, position.column);
                Position p2 = new Position(position.line + 1, position.column);
                if (board.isPositionValid(p2) && canMove(p2) && board.isPositionValid(pos) && canMove(pos) && amountOfMovements == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line + 1, position.column - 1);
                if (board.isPositionValid(pos) && thereIsOpponent(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line + 1, position.column + 1);
                if (board.isPositionValid(pos) && thereIsOpponent(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
            }

            return mat;
        }
    }
}
