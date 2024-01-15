using System;

namespace ChessBoard
{
    internal class BoardExceptions : Exception
    {
        public BoardExceptions(string message) : base(message)
        {
        }
    }
}
