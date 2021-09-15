using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch
{
    public class MatrixFlyweight : Matrix
    {
        private SortedDictionary<char, Flyweight> _flyweight;

        public MatrixFlyweight(IEnumerable<string> matrix) : base(matrix)
        {
            _flyweight = GenerateFlyweight();
        }

        public override int CountHorizontalOcurrences(ReadOnlySpan<char> word)
        {
            if (!_flyweight.ContainsKey(word[0]))
                return 0;

            var ocurrences = 0;
            foreach (int row in _flyweight[word[0]].Rows)
            {
                var sentence = _matrix.RowAsString(row);
                ocurrences += StringUtils.CountOcurrencesSpan(sentence, word);
            }
            return ocurrences;
        }

        public override int CountVerticalOcurrences(ReadOnlySpan<char> word)
        {
            if (!_flyweight.ContainsKey(word[0]))
                return 0;

            var ocurrences = 0;

            foreach (int col in _flyweight[word[0]].Cols)
            {
                var sentence = _matrix.ColumnAsString(col);
                ocurrences += StringUtils.CountOcurrencesSpan(sentence, word);
            }

            return ocurrences;
        }

        private SortedDictionary<char, Flyweight> GenerateFlyweight()
        {
            var flyweight = new SortedDictionary<char, Flyweight>();
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Columns; col++)
                {
                    var letter = _matrix[row, col];
                    if (flyweight.ContainsKey(letter))
                    {
                        flyweight[letter].Rows.Add(row);
                        flyweight[letter].Cols.Add(col);
                    }
                    else
                    {
                        flyweight.Add(letter, new Flyweight
                        {
                            Rows = new HashSet<int>(new[] { row }),
                            Cols = new HashSet<int>(new[] { col })
                        });
                    }
                }
            return flyweight;
        }

        private class Flyweight
        {
            internal HashSet<int> Rows { get; set; }

            internal HashSet<int> Cols { get; set; }
        }
    }
}