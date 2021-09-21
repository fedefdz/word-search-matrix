using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordSearch.SmartSearch.Parallel
{
    public abstract class MatrixSmartSearcherBaseParallel<T> : IMatrixSmartSearcher<T> where T : Matrix
    {
        public Ranking Rank(T matrix, IEnumerable<string> wordstream)
        {
            var ranking = new Ranking(wordstream);
            var safeKeys = ranking.Keys.Where(key => key.Length <= matrix.N).ToArray();
            var tasks = new Task[safeKeys.Length * 4];
            var idx = 0;
            foreach (var key in safeKeys)
            {
                var reverse = new string(key.Reverse().ToArray());

                tasks[idx] = Task.Run(() => ranking[key] += matrix.CountHorizontalOcurrences(key));
                tasks[idx + 1] = Task.Run(() => ranking[key] += matrix.CountVerticalOcurrences(key));
                tasks[idx + 2] = Task.Run(() => ranking[key] += matrix.CountHorizontalOcurrences(reverse));
                tasks[idx + 3] = Task.Run(() => ranking[key] += matrix.CountVerticalOcurrences(reverse));
                idx += 4;
            }

            Task.WaitAll(tasks);
            return ranking;
        }
    }
}