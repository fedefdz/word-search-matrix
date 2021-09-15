using BenchmarkDotNet.Running;

namespace WordSearch.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var summary = BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).RunAll();
            //var summary1 = BenchmarkRunner.Run<WordFinderBenchmarks>();
            //var summary2 = BenchmarkRunner.Run<NameParserBenchmarks>();

            //BenchmarkRunner.Run<StringCountOcurrencesBenchmarks>();
            //BenchmarkRunner.Run<StringCountOcurrencesSpanBenchmarks>();
            //BenchmarkRunner.Run<StringCountOcurrencesBetweenSpanBenchmarks>();
            //BenchmarkRunner.Run<StringCountOcurrencesSpanCompareBenchmarks>();
            //BenchmarkRunner.Run<StringCountOcurrencesSpanStepingBenchmarks>();
            //BenchmarkRunner.Run<StringCountOcurrencesSpanLoopBenchmarks>();

            //BenchmarkRunner.Run<MatrixCountHorizontalOcurrencesBenchmarks>();
            //BenchmarkRunner.Run<MatrixCountHorizontalOcurrencesNotLoopBenchmarks>();

            BenchmarkRunner.Run<MatrixCountVerticalOcurrencesBenchmarks>();
            BenchmarkRunner.Run<MatrixCountVerticalOcurrencesNotLoopBenchmarks>();

            //BenchmarkRunner.Run<WordFinderBenchmarks>();
            //BenchmarkRunner.Run<WordFinderRankingBenchmarks>();
            //BenchmarkRunner.Run<WordFinderLongestStreamRankingBenchmarks>();
        }
    }
}