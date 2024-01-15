namespace ChessBoard
{
    internal class Position
    {
        public int line { get; set; }
        public int column { get; set; }

        public Position(int line, int column)
        {
            this.line = line;
            this.column = column;
        }
        public void setValues(int line, int column)
        {
            this.line = line;
            this.column = column;
        }

        public void SetValues(int line, int column)
        {
            line = line;
            column = column;
        }

        public override string ToString()
        {
            return $"{line}, {column}";
        }
    }
}
