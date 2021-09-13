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
        private Matrix _matrix;

        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = new Matrix(matrix);
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
                for (int row = 0; row < _matrix.Rows; row++)
                {
                    var sentence = _matrix.RowAsString(row);
                    var ocurrences = StringUtils.CountOcurrencesWord(sentence, key);

                    results[key] += ocurrences;
                }

                // vertical
                for (int col = 0; col < _matrix.Columns; col++)
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