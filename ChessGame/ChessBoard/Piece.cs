namespace ChessBoard
{
    internal abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int amountOfMovements { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color)
        {
            this.position = null;
            this.board = board;
            this.color = color;
            this.amountOfMovements = 0;
        }

        public void increaseAmountOfMovements()
        {
            amountOfMovements++;
        }

        public abstract bool[,] possibleMovements();
    }
}
