using BenchmarkDotNet.Attributes;

namespace WordSearch.Benchmark
{
    [MemoryDiagnoser]
    public class MatrixCountHorizontalOcurrencesBenchmarks
    {
        [Params(8, 16, 64)]
        public int SizeMatrix;

        private Matrix _matrix = null;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var pattern = Utils.PatternMatrix;
            var repeat = SizeMatrix / pattern.Length;

            var matrixsource = Utils.RepeatMatrixBuilderAppend(pattern, repeat);

            _matrix = new Matrix(matrixsource);
        }

        [GlobalCleanup]
        public void GlobalCleanup() => _matrix = null;

        [Benchmark]
        [Arguments("chil")]
        [Arguments("pqnsumme")]
        public void CountHorizontalOucrrencesWord(string word)
        {
            _matrix.CountHorizontalOcurrences(word);
        }

        [Benchmark]
        [Arguments("chil")]
        [Arguments("pqnsumme")]
        public void CountHorizontalOucrrencesWordSpan(string word)
        {
            _matrix.CountHorizontalOcurrencesSpan(word);
        }
    }
}