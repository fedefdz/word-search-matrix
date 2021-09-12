using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSearch
{
    public interface IWonderFinder
    {
        IEnumerable<string> Find(IEnumerable<string> wordstream);
    }

    public class WordFinder : IWonderFinder
    {
        private char[,] _matrix;

        public WordFinder(IEnumerable<string> matrix)
        {
            if (matrix is null || !matrix.Any())
                throw new ArgumentException("matrix is empty.");
            if (matrix.Any(word => string.IsNullOrEmpty(word)))
                throw new ArgumentException("matrix must not contain empty words.");

            var size = matrix.First().Length;
            if (matrix.Any(word => word.Length != size))
                throw new ArgumentException("matrix must contain words of equal lengths.");
            if (matrix.Count() != size)
                throw new ArgumentException("matrix is not NxN.");

            _matrix = new char[size, size];

            var row = 0;
            foreach (var word in matrix)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    _matrix[row, i] = word[i];
                }
                row++;
            }
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var results = new Dictionary<string, int>();
            foreach (var word in wordstream)
            {
                results.TryAdd(word, 0);
            }

            foreach (var key in results.Keys)
            {
                // horizontal
                var rows = _matrix.GetLength(1);
                for (int row = 0; row < rows; row++)
                {
                    var sentence = _matrix.RowAsString(row);
                    var ocurrences = StringUtils.CountOcurrencesWord(sentence, key);

                    results[key] += ocurrences;
                }

                // vertical
                var cols = _matrix.GetLength(0);
                for (int col = 0; col < cols; col++)
                {
                    var sentence = _matrix.ColumnAsString(col);
                    var ocurrences = StringUtils.CountOcurrencesWord(sentence, key);

                    results[key] += ocurrences;
                }
            }

            return results.OrderByDescending(x => x.Value)
                .Where(x => x.Value > 0)
                .Take(10).Select(x => x.Key);
        }
    }
}