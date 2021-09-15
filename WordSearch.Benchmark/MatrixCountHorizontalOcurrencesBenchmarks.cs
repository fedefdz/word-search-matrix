using BenchmarkDotNet.Attributes;

namespace WordSearch.Benchmark
{
    [MemoryDiagnoser]
    public class MatrixCountHorizontalOcurrencesBenchmarks
    {
        [Params(8, 16, 64)]
        public int SizeMatrix;

        private Matrix _matrixBasic = null;
        private MatrixFlyweight _matrixFlyweight = null;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var pattern = Utils.PatternMatrix;
            var repeat = SizeMatrix / pattern.Length;

            var matrixsource = Utils.RepeatMatrixBuilderAppend(pattern, repeat);

            _matrixBasic = new Matrix(matrixsource);
            _matrixFlyweight = new MatrixFlyweight(matrixsource);
        }

        [GlobalCleanup]
        public void GlobalCleanup() => _matrixBasic = null;

        [Benchmark]
        [Arguments("chil")]
        [Arguments("pqnsumme")]
        public void MatrixBasicCountHorizontalOucrrencesWord(string word)
        {
            _matrixBasic.CountHorizontalOcurrences(word);
        }

        [Benchmark]
        [Arguments("chil")]
        [Arguments("pqnsumme")]
        public void MatrixFlyweightCountHorizontalOucrrencesWord(string word)
        {
            _matrixFlyweight.CountHorizontalOcurrences(word);
        }
    }

    [MemoryDiagnoser]
    public class MatrixCountHorizontalOcurrencesNotLoopBenchmarks
    {
        [Params(8, 16, 64)]
        public int SizeMatrix;

        private Matrix _matrixBasic = null;
        private MatrixFlyweight _matrixFlyweight = null;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var pattern = Utils.PatternMatrix;
            var repeat = SizeMatrix / pattern.Length;

            var matrixsource = Utils.RepeatMatrixBuilderAppend(pattern, repeat);

            _matrixBasic = new Matrix(matrixsource);
            _matrixFlyweight = new MatrixFlyweight(matrixsource);
        }

        [GlobalCleanup]
        public void GlobalCleanup() => _matrixBasic = null;

        [Benchmark]
        [Arguments("chil")]
        [Arguments("pqnsumme")]
        public void MatrixBasicCountHorizontalOucrrencesWord(string word)
        {
            _matrixBasic.CountHorizontalOcurrences(word);
        }

        [Benchmark]
        [Arguments("chil")]
        [Arguments("pqnsumme")]
        public void MatrixFlyweightCountHorizontalOucrrencesWord(string word)
        {
            _matrixFlyweight.CountHorizontalOcurrences(word);
        }
    }
}