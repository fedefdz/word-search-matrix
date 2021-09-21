using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSearch.SmartSearch.Sequential
{
    public abstract class MatrixSmartSearcherBaseSequential<T> : IMatrixSmartSearcher<T> where T : Matrix
    {
        public Ranking Rank(T matrix, IEnumerable<string> wordstream)
        {
            var ranking = new Ranking(wordstream);
            foreach (var key in ranking.Keys)
            {
                if (key.Length > matrix.N)
                    continue;

                var reverse = new string(key.Reverse().ToArray());

                ranking[key] += matrix.CountHorizontalOcurrences(key);
                ranking[key] += matrix.CountHorizontalOcurrences(reverse);
                ranking[key] += matrix.CountVerticalOcurrences(key);
                ranking[key] += matrix.CountVerticalOcurrences(reverse);
            }

            return ranking;
        }
    }
}