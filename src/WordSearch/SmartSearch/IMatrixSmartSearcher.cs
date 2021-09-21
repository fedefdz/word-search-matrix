using System.Collections.Generic;

namespace WordSearch.SmartSearch
{
    public interface IMatrixSmartSearcher<T> where T : Matrix
    {
        Ranking Rank(T matrix, IEnumerable<string> wordstream);
    }
}