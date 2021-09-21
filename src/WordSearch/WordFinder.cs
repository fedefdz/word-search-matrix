using System.Collections.Generic;
using WordSearch.SmartSearch;

namespace WordSearch
{
    public interface IWordFinder
    {
        IEnumerable<string> Find(IEnumerable<string> wordstream);
    }

    public class WordFinder : IWordFinder
    {
        private Matrix _matrix;

        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = new Matrix(matrix);
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var smartsearch = new SmartSearch.Sequential.MatrixSmartSearcherSequential(); //MatrixSmartSeracherStrategy.SelectBestFor(_matrix, wordstream);
            var ranking = smartsearch.Rank(_matrix, wordstream);

            return ranking.Top(10);
        }
    }
}