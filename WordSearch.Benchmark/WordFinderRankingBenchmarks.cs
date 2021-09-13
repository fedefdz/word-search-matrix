using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace WordSearch.Benchmark
{
    [MemoryDiagnoser]
    public class WordFinderRankingBenchmarks
    {
        [Params(8, 16, 64)]
        public int SizeMatrix;

        private Matrix _matrix;

        private SmartMatrixCounterBasic _smartMatrixCounterBasic;
        private SmartMatrixCounterSpan _smartMatrixCounterSpan;
        private SmartMatrixCounterParallel _smartMatrixCounterParallel;
        private SmartMatrixCounterSpanParallel _smartMatrixCounterSpanParallel;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var pattern = Utils.PatternMatrix;
            var repeat = SizeMatrix / pattern.Length;

            var matrixsource = Utils.RepeatMatrixBuilderAppend(pattern, repeat);

            _matrix = new Matrix(matrixsource);
            _smartMatrixCounterBasic = new SmartMatrixCounterBasic();
            _smartMatrixCounterSpan = new SmartMatrixCounterSpan();
            _smartMatrixCounterParallel = new SmartMatrixCounterParallel();
            _smartMatrixCounterSpanParallel = new SmartMatrixCounterSpanParallel();
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            _matrix = null;

            _smartMatrixCounterBasic = null;
            _smartMatrixCounterSpan = null;
            _smartMatrixCounterParallel = null;
            _smartMatrixCounterSpanParallel = null;
        }

        public IEnumerable<string[]> WordstreamData()
        {
            yield return new[] { "chill" };
            yield return new[] { "chil", "wind", "eplmdepl", "pqnsumme", "fgwiopqr" };
            yield return new[] { "chil", "wind", "eplmdepl", "pqnsumme", "fgwiopqr", "rqpoiwgf", "rqpo", "summ", "mmus", "puafc" };
        }

        private static Dictionary<string, int> InitiliazeRanking(string[] wordstream)
        {
            var ranking = new Dictionary<string, int>();
            foreach (var word in wordstream)
            {
                ranking.TryAdd(word, 0);
            }
            return ranking;
        }

        [Benchmark]
        [ArgumentsSource(nameof(WordstreamData))]
        public void SmartMatricCounterBasic(string[] wordstream) => _smartMatrixCounterBasic.Rank(_matrix, wordstream);

        [Benchmark]
        [ArgumentsSource(nameof(WordstreamData))]
        public void SmartMatricCounterSpan(string[] wordstream) => _smartMatrixCounterSpan.Rank(_matrix, wordstream);

        [Benchmark]
        [ArgumentsSource(nameof(WordstreamData))]
        public void SmartMatricCounterParallel(string[] wordstream) => _smartMatrixCounterParallel.Rank(_matrix, wordstream);

        [Benchmark]
        [ArgumentsSource(nameof(WordstreamData))]
        public void SmartMatricCounterSpanParallel(string[] wordstream) => _smartMatrixCounterSpanParallel.Rank(_matrix, wordstream);
    }
}