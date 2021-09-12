using BenchmarkDotNet.Running;
using System;

namespace WordSearch.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var summary = BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).RunAll();
            //var summary1 = BenchmarkRunner.Run<WordFinderBenchmarks>();
            //var summary2 = BenchmarkRunner.Run<NameParserBenchmarks>();

            BenchmarkRunner.Run<StringCountOcurrencesBenchmarks>();
        }
    }
}