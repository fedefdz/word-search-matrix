using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch.Benchmark
{
    [MemoryDiagnoser]
    public class NameParserBenchmarks
    {
        private const string FullName = "Steve J Gordon";
        private static readonly NameParser Parser = new NameParser();

        [Benchmark(Baseline = true)]
        public void GetLastName()
        {
            Parser.GetLastName(FullName);
        }
    }
}