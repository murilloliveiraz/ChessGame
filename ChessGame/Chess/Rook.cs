using ChessGame.ChessBoard;

namespace Chess
{
    internal class Rook : Piece
    {
        public Rook(Color color, Board board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "T";
        }
    }
}
