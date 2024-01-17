using ChessBoard;

namespace Chess
{
    internal class King : Piece
    {
        private ChessMatch match;

        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
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

        private bool testCastleKingside(Position pos)
        {
            Piece piece = board.piece(pos);
            return  piece != null && piece is Rook && piece.color == color && piece.amountOfMovements == 0;
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

            //special move - castle kingside
            if(amountOfMovements == 0  && !match.check)
            {
                Position positionT1 = new Position(position.line, position.column);
                if(testCastleKingside(positionT1))
                {
                    Position p1 = new Position(position.line, position.column);
                    Position p2 = new Position(position.line, position.column);
                    if(board.piece(p1) == null && board.piece(p2) == null)
                    {
                        mat[position.line, position.column + 2] = true;
                    }
                }
            //special move - castle queenside
                Position positionT2 = new Position(position.line, position.column - 4);
                if(testCastleKingside(positionT2))
                {
                    Position p1 = new Position(position.line, position.column - 1);
                    Position p2 = new Position(position.line, position.column - 2);
                    Position p3 = new Position(position.line, position.column - 3);
                    if(board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null)
                    {
                        mat[position.line, position.column - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
