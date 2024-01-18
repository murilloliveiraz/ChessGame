using ChessBoard;

namespace Chess
{

    class Pawn : Piece
    {
        private ChessMatch match;

        public Pawn(Board tab, Color cor, ChessMatch match) : base(tab, cor)
        {
            this.match = match;
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

                //En Passant
                if (position.line == 3)
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (board.isPositionValid(left) && thereIsOpponent(left) && board.piece(left) == match.vulneravelEnPassant)
                    {
                        mat[left.line - 1, left.column] = true;
                    }
                    Position right = new Position(position.line, position.column + 1);
                    if (board.isPositionValid(right) && thereIsOpponent(right) && board.piece(right) == match.vulneravelEnPassant)
                    {
                        mat[right.line - 1, right.column] = true;
                    }
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
                //En Passant
                if (position.line == 4)
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (board.isPositionValid(left) && thereIsOpponent(left) && board.piece(left) == match.vulneravelEnPassant)
                    {
                        mat[left.line + 1, left.column] = true;
                    }
                    Position right = new Position(position.line, position.column + 1);
                    if (board.isPositionValid(right) && thereIsOpponent(right) && board.piece(right) == match.vulneravelEnPassant)
                    {
                        mat[right.line + 1, right.column] = true;
                    }
                }
            }

            return mat;
        }
    }
}
