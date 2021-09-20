using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace WordSearch.Benchmark
{
    [MemoryDiagnoser]
    public class MatrixCountHorizontalOcurrencesBenchmarks
    {
        [Params(5, 10, 20, 30, 60)]
        public int SizeMatrix;

        private Matrix _matrixBasic = null;
        private MatrixFlyweight _matrixFlyweight = null;

        public static IEnumerable<string> Words()
        {
            yield return "cold";
            yield return "wind";
            yield return "snow";
            yield return "chill";
            yield return "coldycoldy";
            yield return "chillchill";
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            var pattern = Utils.SampleMatrix;
            var repeat = SizeMatrix / pattern.Length;

            var matrixsource = Utils.RepeatMatrixBuilderAppend(pattern, repeat);

            _matrixBasic = new Matrix(matrixsource);
            _matrixFlyweight = new MatrixFlyweight(matrixsource);
        }

        [GlobalCleanup]
        public void GlobalCleanup() => _matrixBasic = null;

        [Benchmark]
        [ArgumentsSource(nameof(Words))]
        public void MatrixBasicCountHorizontalOucrrencesWord(string word) => _matrixBasic.CountHorizontalOcurrences(word);

        [Benchmark]
        [ArgumentsSource(nameof(Words))]
        public void MatrixFlyweightCountHorizontalOucrrencesWord(string word) => _matrixFlyweight.CountHorizontalOcurrences(word);
    }
}