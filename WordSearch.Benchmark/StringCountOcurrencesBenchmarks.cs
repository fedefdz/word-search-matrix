using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch.Benchmark
{
    [MemoryDiagnoser]
    public class StringCountOcurrencesBenchmarks
    {
        private static string RepeatStringBuilderAppend(string s, int n) => new StringBuilder(s.Length * n)
            .AppendJoin(s, new string[n + 1])
            .ToString();

        [Params(8, 16, 32, 64)]
        public int N;

        private string _source = string.Empty;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var pattern = "abcd";
            var repeat = N / pattern.Length;

            _source = RepeatStringBuilderAppend(pattern, repeat);
        }

        //[Benchmark]
        [Arguments("bc")]
        [Arguments("abcdab")]
        [Arguments("abcdabcd")]
        [Arguments("abcdabcdabcdabcd")]
        public void CountOucrrencesWord(string word)
        {
            StringUtils.CountOcurrencesWord(_source, word);
        }

        [Benchmark]
        [Arguments("bc")]
        [Arguments("abcdab")]
        [Arguments("abcdabcd")]
        [Arguments("abcdabcdabcdabcd")]
        public void CountOucrrencesWordSpan(string word)
        {
            StringUtils.CountOcurrencesWordSpan(_source, word);
        }

        [Benchmark]
        [Arguments("bc")]
        [Arguments("abcdab")]
        [Arguments("abcdabcd")]
        [Arguments("abcdabcdabcdabcd")]
        public void CountOucrrencesWordSpanOptimist(string word)
        {
            StringUtils.CountOcurrencesWordSpanOptimist(_source, word);
        }

        //[Benchmark]
        [Arguments("bc")]
        [Arguments("abcdab")]
        [Arguments("abcdabcd")]
        [Arguments("abcdabcdabcdabcd")]
        public void CountOucrrencesPattern(string word)
        {
            StringUtils.CountOcurrencesPattern(_source, word);
        }
    }
}