using System;

namespace WordSearch
{
    public class MatrixException : Exception
    {
        public MatrixException(string message) : base(message)
        { }
    }
}