﻿namespace ChessBoard
{
    internal class Board
    {

        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[columns, lines];
        }

        public Piece piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.line, pos.column];
        }

        public bool isPositionOccupied(Position pos)
        {
            validatePosition(pos);
            return piece(pos) != null;
        }

        public void putPiece(Piece piece, Position pos)
        {
            if (isPositionOccupied(pos))
            {
                throw new BoardExceptions("Já existe uma peça nessa posição!");
            }
            pieces[pos.line, pos.column] = piece;
            piece.position = pos;
        }

        public Piece removePiece(Position pos)
        {
            if (piece(pos) == null)
            {
                return null;
            }
            Piece aux = piece(pos);
            aux.position = null;
            pieces[pos.line, pos.column] = null;
            return aux;
        }

        public bool isPositionValid(Position pos)
        {
            if (pos.line < 0 || pos.line > lines || pos.column < 0 || pos.column >= columns)
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position pos)
        {
            if (!isPositionValid(pos))
            {
                throw new BoardExceptions("Posição Inválida");
            }
        }
    }
}
