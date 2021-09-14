﻿using BenchmarkDotNet.Attributes;

namespace WordSearch.Benchmark
{
    [MemoryDiagnoser]
    public class WordFinderBenchmarks
    {
        [Params(8, 16, 64)]
        public int SizeMatrix;

        private IWordFinder _finder;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var pattern = Utils.PatternMatrix;
            var repeat = SizeMatrix / pattern.Length;

            var matrixsource = Utils.RepeatMatrixBuilderAppend(pattern, repeat);

            _finder = new WordFinder(matrixsource);
        }

        [Benchmark]
        public void FinderSingle()
        {
            _finder.Find(new[] { "chill" });
        }

        [Benchmark]
        public void FinderFive()
        {
            _finder.Find(new[] { "chil", "wind", "eplmdepl", "pqnsumme", "fgwiopqr" });
        }

        [Benchmark]
        public void FinderTen()
        {
            _finder.Find(new[] { "chil", "wind", "eplmdepl", "pqnsumme", "fgwiopqr", "rqpoiwgf", "rqpo", "summ", "mmus", "puafc" });
        }
    }
}