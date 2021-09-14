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

        private SmartMatrixFlyweightCounterBasic _smartMatrixFlyweightCounterBasic;
        private SmartMatrixFlyweightCounterSpan _smartMatrixFlyweightCounterSpan;
        private SmartMatrixFlyweightCounterParallel _smartMatrixFlyweightCounterParallel;
        private SmartMatrixFlyweightCounterSpanParallel _smartMatrixFlyweightCounterSpanParallel;

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

            _smartMatrixFlyweightCounterBasic = new SmartMatrixFlyweightCounterBasic();
            _smartMatrixFlyweightCounterSpan = new SmartMatrixFlyweightCounterSpan();
            _smartMatrixFlyweightCounterParallel = new SmartMatrixFlyweightCounterParallel();
            _smartMatrixFlyweightCounterSpanParallel = new SmartMatrixFlyweightCounterSpanParallel();
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            _matrix = null;

            _smartMatrixCounterBasic = null;
            _smartMatrixCounterSpan = null;
            _smartMatrixCounterParallel = null;
            _smartMatrixCounterSpanParallel = null;

            _smartMatrixFlyweightCounterBasic = null;
            _smartMatrixFlyweightCounterSpan = null;
            _smartMatrixFlyweightCounterParallel = null;
            _smartMatrixFlyweightCounterSpanParallel = null;
        }

        public IEnumerable<string[]> WordstreamData()
        {
            yield return new[] { "chill" };
            yield return new[] { "chil", "wind", "eplmdepl", "pqnsumme", "fgwiopqr" };
            yield return new[] { "chil", "wind", "eplmdepl", "pqnsumme", "fgwiopqr", "rqpoiwgf", "rqpo", "summ", "mmus", "puafc" };
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

        [Benchmark]
        [ArgumentsSource(nameof(WordstreamData))]
        public void SmartMatricFlyweightCounterBasic(string[] wordstream) => _smartMatrixFlyweightCounterBasic.Rank(_matrix, wordstream);

        [Benchmark]
        [ArgumentsSource(nameof(WordstreamData))]
        public void SmartMatricFlyweightCounterSpan(string[] wordstream) => _smartMatrixFlyweightCounterSpan.Rank(_matrix, wordstream);

        [Benchmark]
        [ArgumentsSource(nameof(WordstreamData))]
        public void SmartMatricFlyweightCounterParallel(string[] wordstream) => _smartMatrixFlyweightCounterParallel.Rank(_matrix, wordstream);

        [Benchmark]
        [ArgumentsSource(nameof(WordstreamData))]
        public void SmartMatricFlyweightCounterSpanParallel(string[] wordstream) => _smartMatrixFlyweightCounterSpanParallel.Rank(_matrix, wordstream);
    }

    [MemoryDiagnoser]
    public class WordFinderLongestStreamRankingBenchmarks
    {
        [Params(32, 64)]
        public int SizeMatrix;

        private Matrix _matrix;

        private SmartMatrixCounterSpan _smartMatrixCounterSpan;
        private SmartMatrixCounterSpanParallel _smartMatrixCounterSpanParallel;

        private SmartMatrixFlyweightCounterSpan _smartMatrixFlyweightCounterSpan;
        private SmartMatrixFlyweightCounterSpanParallel _smartMatrixFlyweightCounterSpanParallel;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var pattern = Utils.PatternMatrix;
            var repeat = SizeMatrix / pattern.Length;

            var matrixsource = Utils.RepeatMatrixBuilderAppend(pattern, repeat);

            _matrix = new Matrix(matrixsource);

            _smartMatrixCounterSpan = new SmartMatrixCounterSpan();
            _smartMatrixCounterSpanParallel = new SmartMatrixCounterSpanParallel();

            _smartMatrixFlyweightCounterSpan = new SmartMatrixFlyweightCounterSpan();
            _smartMatrixFlyweightCounterSpanParallel = new SmartMatrixFlyweightCounterSpanParallel();
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            _matrix = null;

            _smartMatrixCounterSpan = null;
            _smartMatrixCounterSpanParallel = null;

            _smartMatrixFlyweightCounterSpan = null;
            _smartMatrixFlyweightCounterSpanParallel = null;
        }

        public IEnumerable<string[]> WordstreamData()
        {
            yield return new[]
            {    "chil", "wind", "eplmdepl", "pqnsumme", "fgwiopqr", "rqpoiwgf", "rqpo", "summ", "mmus", "puafc",
                "eplmdepleplmdepleplmdepl", "fgwiopqrfgwiopqrfgwiopqr", "rqpoiwgfrqpoiwgfrqpoiwgf",
                "mdepleplmdepleplmdeplepl", "opqrfgwiopqrfgwiopqrfgwi", "gfrqpoiwgfrqpoiwgfrqpoiw"
            };
            yield return new[]
            {   "chilchilchilchilchilchil", "windwindwindwindwindwind", "eplmdepleplmdepl",
                "pqnsummepqnsumme","fgwiopqrfgwiopqr", "rqpoiwgfrqpoiwgf",
                "puafcpuafc", "puafc", "puafcpuafcpuafc", "puafcpuafcpuafcpuafc",
                "eplmdepleplmdepleplmdepl", "fgwiopqrfgwiopqrfgwiopqr", "rqpoiwgfrqpoiwgfrqpoiwgf",
                "mdepleplmdepleplmdeplepl", "opqrfgwiopqrfgwiopqrfgwi", "gfrqpoiwgfrqpoiwgfrqpoiw",
                "chilchilchilchilchilchil", "windwindwindwindwindwind", "eplmdepleplmdepl",
                "pkffpjffgqnsumme","yioippqrfgwiopqr", "xxhipoipoipoiwgf",
                "pkjkjklufc", "pjjkc", "puafcwrewrewrfc", "rioiojkyhdpuafcpuafc",
                "uiuidepleplmdepleplmdepl", "wnmkjijoimoinsdlfgwiopqr", "rqpoiwgfrqpoiwgljdgvfwmdiegegd",
                "mqeplehghjghjguiudeplepl", "opnmkherwookfgwiopqrfgwi", "hjyhuhiujjkjijiwgfrqpoiw",
            };
        }

        [Benchmark]
        [ArgumentsSource(nameof(WordstreamData))]
        public void SmartMatricCounterSpan(string[] wordstream) => _smartMatrixCounterSpan.Rank(_matrix, wordstream);

        [Benchmark]
        [ArgumentsSource(nameof(WordstreamData))]
        public void SmartMatricCounterSpanParallel(string[] wordstream) => _smartMatrixCounterSpanParallel.Rank(_matrix, wordstream);

        [Benchmark]
        [ArgumentsSource(nameof(WordstreamData))]
        public void SmartMatricFlyweightCounterSpan(string[] wordstream) => _smartMatrixFlyweightCounterSpan.Rank(_matrix, wordstream);

        [Benchmark]
        [ArgumentsSource(nameof(WordstreamData))]
        public void SmartMatricFlyweightCounterSpanParallel(string[] wordstream) => _smartMatrixFlyweightCounterSpanParallel.Rank(_matrix, wordstream);
    }
}