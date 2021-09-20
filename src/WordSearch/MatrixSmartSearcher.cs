using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordSearch
{
    public interface IMatrixSmartSearcher
    {
        Ranking Rank(Matrix matrix, IEnumerable<string> wordstream);
    }

    public class MatrixSmartSeracherStrategy
    {
        public static IMatrixSmartSearcher SelectBestFor(Matrix matrix, IEnumerable<string> wordstream) => matrix.N switch
        {
            > 16 => new MatrixSmartSearcherParallel(),

            16 when wordstream.Count() > 5 => new MatrixSmartSearcherParallel(),

            _ => new MatrixSmartSearcherSequential(),
        };
    }

    public class MatrixSmartSearcherSequential : MatrixSmartSearcherBaseSequential<Matrix> { }

    public class MatrixFlyweightSmartSearcherSequential : MatrixSmartSearcherBaseSequential<MatrixFlyweight> { }

    public abstract class MatrixSmartSearcherBaseSequential<T> : IMatrixSmartSearcher where T : Matrix
    {
        public Ranking Rank(Matrix matrix, IEnumerable<string> wordstream)
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

    public class MatrixSmartSearcherParallel : MatrixSmartSearcherBaseParallel<Matrix> { }

    public class MatrixFlyweightSmartSearcherParallel : MatrixSmartSearcherBaseParallel<MatrixFlyweight> { }

    public abstract class MatrixSmartSearcherBaseParallel<T> : IMatrixSmartSearcher where T : Matrix
    {
        public Ranking Rank(Matrix matrix, IEnumerable<string> wordstream)
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