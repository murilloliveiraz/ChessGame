﻿using System;
using ChessBoard;

namespace Chess
{
    internal class ChessPosition
    {
        public char column { get; set; }
        public int line { get; set; }

        public ChessPosition(char column, int line)
        {
            this.column = column;
            this.line = line;
        }

        public Position toBoardPosition()
        {
            return new Position(8 - line, column - 'a');
        }

        public override string ToString()
        {
            return "" + column + line;
        }
    }
}
