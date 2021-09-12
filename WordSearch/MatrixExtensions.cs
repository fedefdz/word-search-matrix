namespace WordSearch
{
    public static class MatrixExtensions
    {
        public static string RowAsString(this char[,] matrix, int row)
        {
            var cols = matrix.GetLength(Matrix.ColumnDimension);
            var sentence = new char[cols];
            for (int i = 0; i < cols; i++)
            {
                sentence[i] = matrix[row, i];
            }
            return new string(sentence);
        }

        public static string ColumnAsString(this char[,] matrix, int col)
        {
            var rows = matrix.GetLength(Matrix.RowDimension);
            var sentence = new char[rows];
            for (int i = 0; i < rows; i++)
            {
                sentence[i] = matrix[col, i];
            }
            return new string(sentence);
        }
    }
}