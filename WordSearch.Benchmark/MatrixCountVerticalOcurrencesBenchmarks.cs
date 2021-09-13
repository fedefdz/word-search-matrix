using BenchmarkDotNet.Attributes;

namespace WordSearch.Benchmark
{
    [MemoryDiagnoser]
    public class MatrixCountVerticalOcurrencesBenchmarks
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
        [Arguments("wind")]
        [Arguments("eplmdepl")]
        public void CountVerticalOucrrencesWord(string word)
        {
            _matrix.CountVerticalOcurrences(word);
        }

        [Benchmark]
        [Arguments("wind")]
        [Arguments("eplmdepl")]
        public void CountVerticalOucrrencesWordSpan(string word)
        {
            _matrix.CountVerticalOcurrencesSpan(word);
        }
    }
}