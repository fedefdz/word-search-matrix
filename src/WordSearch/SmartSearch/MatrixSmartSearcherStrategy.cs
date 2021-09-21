using System.Collections.Generic;
using System.Linq;
using WordSearch.SmartSearch.Parallel;
using WordSearch.SmartSearch.Sequential;

namespace WordSearch.SmartSearch
{
    public class MatrixSmartSeracherStrategy
    {
        public static IMatrixSmartSearcher<MatrixFlyweight> SelectBestFor(MatrixFlyweight matrix, IEnumerable<string> wordstream) => matrix.N switch
        {
            < 45 => new MatrixFlyweightSmartSearcherSequential(),
            >= 45 and < 60 when wordstream.Count() < 12 => new MatrixFlyweightSmartSearcherSequential(),
            60 when wordstream.Count() == 1 => new MatrixFlyweightSmartSearcherSequential(),
            _ => new MatrixFlyweightSmartSearcherParallel()
        };
    }
}