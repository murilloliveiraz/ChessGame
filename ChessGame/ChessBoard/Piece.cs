using ChessBoard;

namespace ChessGame.ChessBoard
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int AmountOfMovements { get; protected set; }
        public Board Board { get; protected set; }

        public Piece( Board board, Color color)
        {
            Position = null;
            Color = color;
            AmountOfMovements = 0;
            Board = board;
        }

        public void IncreaseAmountOfMovements()
        {
            AmountOfMovements++;
        }
    }
}
