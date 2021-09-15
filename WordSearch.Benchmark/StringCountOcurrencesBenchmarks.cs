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

        //[Benchmark]
        [Arguments("ab")]
        [Arguments("abcdabcd")]
        [Arguments("abcdabcdabcdabcd")]
        [Arguments("abcdabcdabcdabcdabcdabcdabcdabcd")]
        public void CountOucrrencesWord(string word)
        {
            StringUtils.CountOcurrences(_source, word);
        }

        [Benchmark]
        [Arguments("ab")]
        [Arguments("abcdabcd")]
        [Arguments("abcdabcdabcdabcd")]
        [Arguments("abcdabcdabcdabcdabcdabcdabcdabcd")]
        public void CountOucrrencesWordSpan(string word)
        {
            StringUtils.CountOcurrencesSpan(_source, word);
        }

        [Benchmark]
        [Arguments("ab")]
        [Arguments("abcdabcd")]
        [Arguments("abcdabcdabcdabcd")]
        [Arguments("abcdabcdabcdabcdabcdabcdabcdabcd")]
        public void CountOucrrencesPattern(string word)
        {
            StringUtils.CountOcurrencesPattern(_source, word);
        }
    }

    [MemoryDiagnoser]
    public class StringCountOcurrencesSpanBenchmarks
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
        [Arguments("abcdabcdabcdabcdabcdabcdabcdabcd")]
        public void CountOucrrencesWordSpan(string word)
        {
            StringUtils.CountOcurrencesSpan(_source, word);
        }

        [Benchmark]
        [Arguments("ab")]
        [Arguments("abcdabcd")]
        [Arguments("abcdabcdabcdabcd")]
        [Arguments("abcdabcdabcdabcdabcdabcdabcdabcd")]
        public void CountOucrrencesWordSpanOptimist(string word)
        {
            StringUtils.CountOcurrencesSpanOptimist(_source, word);
        }
    }

    [MemoryDiagnoser]
    public class StringCountOcurrencesBetweenSpanBenchmarks
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
        [Arguments("abcdabcdabcdabcdabcdabcdabcdabcd")]
        public void CountOucrrencesWordSpan(string word)
        {
            StringUtils.CountOcurrencesSpan(_source, word);
        }

        [Benchmark]
        [Arguments("ab")]
        [Arguments("abcdabcd")]
        [Arguments("abcdabcdabcdabcd")]
        [Arguments("abcdabcdabcdabcdabcdabcdabcdabcd")]
        public void CountOucrrencesWordSpanLoop(string word)
        {
            StringUtils.CountOcurrencesSpanLoop(_source, word);
        }
    }

    [MemoryDiagnoser]
    public class StringCountOcurrencesSpanLoopBenchmarks
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
        [Arguments("abcdabcdabcdabcdabcdabcdabcdabcd")]
        public void CountOucrrencesSpan(string word)
        {
            StringUtils.CountOcurrencesSpan(_source, word);
        }

        [Benchmark]
        [Arguments("ab")]
        [Arguments("abcdabcd")]
        [Arguments("abcdabcdabcdabcd")]
        [Arguments("abcdabcdabcdabcdabcdabcdabcdabcd")]
        public void CountOucrrencesSpanLoop(string word)
        {
            StringUtils.CountOcurrencesSpanLoop(_source, word);
        }
    }
}