using System;
using System.Text.RegularExpressions;

namespace WordSearch
{
    public static class StringUtils
    {
        public static int CountOcurrencesWord(string source, string word)
        {
            var substring = source.Replace(word, string.Empty);
            if (source.Length == substring.Length)
                return 0;

            return (source.Length - substring.Length) / word.Length;
        }

        public static int CountOcurrencesWordSpan(ReadOnlySpan<char> source, ReadOnlySpan<char> word)
        {
            var count = 0;
            var index = source.IndexOf(word);
            if (index == -1)
                return count;

            count++;
            var next = index + word.Length;
            if (next >= source.Length)
                return count;

            var slice = source.Slice(next, source.Length - next);
            count += CountOcurrencesWordSpan(slice, word);
            return count;
        }

        public static int CountOcurrencesWordSpanOptimist(ReadOnlySpan<char> source, ReadOnlySpan<char> word)
        {
            var count = 0;
            try
            {
                var index = source.IndexOf(word);
                if (index == -1)
                    return count;

                count++;
                var next = index + word.Length;
                var slice = source.Slice(next, source.Length - next);
                count += CountOcurrencesWordSpan(slice, word);
                return count;
            }
            catch (ArgumentOutOfRangeException)
            {
                return count;
            }
        }

        public static int CountOcurrencesPattern(string source, string pattern) => Regex.Matches(source, pattern).Count;
    }
}