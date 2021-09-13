using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch
{
    public class Matrix
    {
        public const int RowDimension = 1;
        public const int ColumnDimension = 0;

        private readonly char[,] _matrix;

        public Matrix(IEnumerable<string> matrix)
        {
            _matrix = GenerateMatrix(matrix);
        }

        public int Rows => _matrix.GetLength(RowDimension);

        public int Columns => _matrix.GetLength(ColumnDimension);

        public string RowAsString(int row)
        {
            if (row < 0 || row >= Rows)
                throw new MatrixException("row index out of range.");

            return _matrix.RowAsString(row);
        }

        public string ColumnAsString(int col)
        {
            if (col < 0 || col >= Columns)
                throw new MatrixException("column index out of range.");

            return _matrix.ColumnAsString(col);
        }

        private static char[,] GenerateMatrix(IEnumerable<string> matrixsource)
        {
            ValidateMatrixDimensions(matrixsource);

            var size = matrixsource.First().Length;
            var matrix = new char[size, size];

            var row = 0;
            foreach (var word in matrixsource)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    matrix[row, i] = word[i];
                }
                row++;
            }

            return matrix;
        }

        private static void ValidateMatrixDimensions(IEnumerable<string> matrix)
        {
            if (matrix is null || !matrix.Any())
                throw new MatrixException("matrix is empty.");
            if (matrix.Any(word => string.IsNullOrEmpty(word)))
                throw new ArgumentException("matrix must not contain empty words.");

            var size = matrix.First().Length;
            if (matrix.Any(word => word.Length != size))
                throw new MatrixException("matrix must contain words of equal lengths.");
            if (matrix.Count() != size)
                throw new MatrixException("matrix is not NxN.");
        }
    }

    public class MatrixException : Exception
    {
        public MatrixException(string message) : base(message)
        {
        }
    }
}