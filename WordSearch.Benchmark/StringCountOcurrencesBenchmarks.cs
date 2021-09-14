using BenchmarkDotNet.Attributes;

namespace WordSearch.Benchmark
{
    [MemoryDiagnoser]
    public class StringCountOcurrencesBenchmarks
    {
        [Params(8, 16, 64)]
        public int N;

        private string _source = string.Empty;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var pattern = "abcd";
            var repeat = N / pattern.Length;

            _source = Utils.RepeatStringBuilderAppend(pattern, repeat);
        }

        [GlobalCleanup]
        public void GlobalCleanup() => _source = string.Empty;

        [Benchmark]
        [Arguments("ab")]
        [Arguments("abcdabcd")]
        [Arguments("abcdabcdabcdabcd")]
        public void CountOucrrencesWord(string word)
        {
            StringUtils.CountOcurrencesWord(_source, word);
        }

        [Benchmark]
        [Arguments("ab")]
        [Arguments("abcdabcd")]
        [Arguments("abcdabcdabcdabcd")]
        public void CountOucrrencesWordSpan(string word)
        {
            StringUtils.CountOcurrencesWordSpan(_source, word);
        }

        [Benchmark]
        [Arguments("ab")]
        [Arguments("abcdabcd")]
        [Arguments("abcdabcdabcdabcd")]
        public void CountOucrrencesWordSpanOptimist(string word)
        {
            StringUtils.CountOcurrencesWordSpanOptimist(_source, word);
        }

        [Benchmark]
        [Arguments("ab")]
        [Arguments("abcdabcd")]
        [Arguments("abcdabcdabcdabcd")]
        public void CountOucrrencesPattern(string word)
        {
            StringUtils.CountOcurrencesPattern(_source, word);
        }
    }
}