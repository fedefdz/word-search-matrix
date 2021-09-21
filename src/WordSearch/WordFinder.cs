﻿using System.Collections.Generic;
using WordSearch.SmartSearch;

namespace WordSearch
{
    public interface IWordFinder
    {
        IEnumerable<string> Find(IEnumerable<string> wordstream);
    }

    public class WordFinder : IWordFinder
    {
        private MatrixFlyweight _matrix;

        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = new MatrixFlyweight(matrix);
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var smartsearch = MatrixSmartSeracherStrategy.SelectBestFor(_matrix, wordstream);
            var ranking = smartsearch.Rank(_matrix, wordstream);

            return ranking.Top(10);
        }
    }
}