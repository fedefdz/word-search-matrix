using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using WSU = WordSearch.Utils;

namespace WordSearch.Benchmark.StringUtils
{
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
        [ArgumentsSource(nameof(Words))]
        public void CountOucrrences(string word) => WSU.StringUtils.CountOcurrences(_source, word);

        [Benchmark]
        [ArgumentsSource(nameof(Words))]
        public void CountOucrrencesSpan(string word) => WSU.StringUtils.CountOcurrencesSpan(_source, word);

        [Benchmark]
        [ArgumentsSource(nameof(Words))]
        public void CountOucrrencesPattern(string word) => WSU.StringUtils.CountOcurrencesPattern(_source, word);

        public static IEnumerable<string> Words()
        {
            yield return "ab";
            yield return "abcdabcd";
            yield return "abcdabcdabcdabcd";
            yield return "abcdabcdabcdabcdabcdabcdabcdabcd";
        }
    }

    public class StringCountOcurrencesBetweenSpanBenchmarks
    {
        [Params(5, 15, 30, 60)]
        public int N;

        private string _source = string.Empty;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var pattern = "coldx";
            var repeat = N / pattern.Length;

            _source = Utils.RepeatStringBuilderAppend(pattern, repeat);
        }

        [GlobalCleanup]
        public void GlobalCleanup() => _source = string.Empty;

        [Benchmark]
        [ArgumentsSource(nameof(Words))]
        public void CountOucrrencesSpan(string word) => WSU.StringUtils.CountOcurrencesSpan(_source, word);

        [Benchmark]
        [ArgumentsSource(nameof(Words))]
        public void CountOucrrencesSpanOptimist(string word) => WSU.StringUtils.CountOcurrencesSpanOptimist(_source, word);

        [Benchmark]
        [ArgumentsSource(nameof(Words))]
        public void CountOucrrencesSpanLoop(string word) => WSU.StringUtils.CountOcurrencesSpanLoop(_source, word);

        public static IEnumerable<string> Words()
        {
            yield return "cold";
            yield return "coldx";
            yield return "coldxcoldxcoldx";
        }
    }

    public class StringCountOcurrenceSpanRecursiveBenchmarks
    {
        [Params(5, 15, 20, 40, 60)]
        public int N;

        private string _source = string.Empty;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var pattern = "coldx";
            var repeat = N / pattern.Length;

            _source = Utils.RepeatStringBuilderAppend(pattern, repeat);
        }

        [GlobalCleanup]
        public void GlobalCleanup() => _source = string.Empty;

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Words))]
        public void CountOucrrencesSpan(string word) => WSU.StringUtils.CountOcurrencesSpan(_source, word);

        [Benchmark]
        [ArgumentsSource(nameof(Words))]
        public void CountOucrrencesSpanLoop(string word) => WSU.StringUtils.CountOcurrencesSpanLoop(_source, word);

        public static IEnumerable<string> Words()
        {
            yield return "cold";
            yield return "coldx";
            yield return "coldxcold";
            yield return "coldxcoldx";
            yield return "coldxcoldxcold";
            yield return "coldxcoldxcoldx";
            yield return "coldxcoldxcoldxcold";
            yield return "coldxcoldxcoldxcoldx";
        }
    }
}