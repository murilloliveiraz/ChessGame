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
        public void decreaseAmountOfMovements()
        {
            amountOfMovements--;
        }

        public bool thereArePossibleMovements()
        {
            bool[,] mat = possibleMovements();
            for (int i = 0; i < board.lines; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool isPossibleToMove(Position pos)
        {
            return possibleMovements()[pos.line, pos.column];
        }

        public abstract bool[,] possibleMovements();
    }
}
