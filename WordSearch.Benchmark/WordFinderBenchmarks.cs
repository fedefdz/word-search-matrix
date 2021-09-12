using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch.Benchmark
{
    //[MemoryDiagnoser]
    public class WordFinderBenchmarks
    {
        public static readonly string[] MatrixSample = {
            "abcdc",
            "fgwio",
            "chill",
            "pqnsd",
            "uvdxy"
        };

        private static readonly IWonderFinder Finder = new WordFinder(MatrixSample);

        [Benchmark(Baseline = true)]
        public void FinderSingle()
        {
            Finder.Find(new[] { "chill " });
        }
    }
}