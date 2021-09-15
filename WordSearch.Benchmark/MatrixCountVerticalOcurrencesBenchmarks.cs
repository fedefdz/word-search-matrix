using BenchmarkDotNet.Attributes;

namespace WordSearch.Benchmark
{
    [MemoryDiagnoser]
    public class MatrixCountVerticalOcurrencesBenchmarks
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

        [Benchmark]
        [Arguments("wind")]
        [Arguments("eplmdepl")]
        public void MatrixBasicCountHorizontalOucrrencesWord(string word)
        {
            _matrixBasic.CountHorizontalOcurrences(word);
        }

        [Benchmark]
        [Arguments("wind")]
        [Arguments("eplmdepl")]
        public void MatrixFlyweightCountHorizontalOucrrencesWord(string word)
        {
            _matrixFlyweight.CountHorizontalOcurrences(word);
        }
    }

    [MemoryDiagnoser]
    public class MatrixCountVerticalOcurrencesNotLoopBenchmarks
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

        [Benchmark]
        [Arguments("wind")]
        [Arguments("eplmdepl")]
        public void MatrixBasicCountHorizontalOucrrencesWord(string word)
        {
            _matrixBasic.CountHorizontalOcurrences(word);
        }

        [Benchmark]
        [Arguments("wind")]
        [Arguments("eplmdepl")]
        public void MatrixFlyweightCountHorizontalOucrrencesWord(string word)
        {
            _matrixFlyweight.CountHorizontalOcurrences(word);
        }
    }
}