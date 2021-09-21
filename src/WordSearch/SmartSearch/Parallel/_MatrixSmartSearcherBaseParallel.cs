using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordSearch.SmartSearch.Parallel
{
    public abstract class MatrixSmartSearcherBaseParallel<T> : IMatrixSmartSearcher<T> where T : Matrix
    {
        public Ranking Rank(T matrix, IEnumerable<string> wordstream)
        {
            var ranking = new ConcurrentDictionary<string, int>();
            foreach (var word in wordstream)
                ranking.TryAdd(word, 0);

            var safeKeys = ranking.Keys.Where(key => key.Length <= matrix.N).ToArray();
            var tasks = new Task[safeKeys.Length * 4];
            var idx = 0;
            foreach (var key in safeKeys)
            {
                var reverse = new string(key.Reverse().ToArray());

                tasks[idx] = Task.Run(() => ranking.AddOrUpdate(key, 0, (key, current) => current += matrix.CountHorizontalOcurrences(key)));
                tasks[idx + 1] = Task.Run(() => ranking.AddOrUpdate(key, 0, (key, current) => current += matrix.CountVerticalOcurrences(key)));
                tasks[idx + 2] = Task.Run(() => ranking.AddOrUpdate(key, 0, (key, current) => current += matrix.CountHorizontalOcurrences(reverse)));
                tasks[idx + 3] = Task.Run(() => ranking.AddOrUpdate(key, 0, (key, current) => current += matrix.CountVerticalOcurrences(reverse)));
                idx += 4;
            }

            Task.WaitAll(tasks);
            return new Ranking(ranking);
        }
    }
}