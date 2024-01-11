using ChessBoard;

namespace ChessGame.ChessBoard
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; set; }
        public int AmountOfMovements { get; set; }
        public Board Board { get; set; }

        public Piece(Position position, Color color, Board board)
        {
            Position = position;
            Color = color;
            AmountOfMovements = 0;
            Board = board;
        }
    }
}
