using Xunit;

namespace WordSearch.Tests
{
    public class StringUtilsTest
    {
        [Theory]
        [InlineData("qhouseuiohouseghjklhousenm", "house", 3)]
        [InlineData("tableyuiopasdfghtablecvbnm", "table", 2)]
        [InlineData("qwertyuiopasdfghjklzxcvbnm", "chair", 0)]
        [InlineData("chair", "chair", 1)]
        [InlineData("chair", "chairs", 0)]
        [InlineData("xabababx", "abab", 1)]
        public void CountOcurrencesWord_Should_Return_Number_Of_Times_That_It_Appears(string source, string word, int ocurrences)
        {
            var numnerOfTimes = StringUtils.CountOcurrences(source, word);
            Assert.Equal(ocurrences, numnerOfTimes);
        }

        [Theory]
        [InlineData("qhouseuiohouseghjklhousenm", "house", 3)]
        [InlineData("tableyuiopasdfghtablecvbnm", "table", 2)]
        [InlineData("qwertyuiopasdfghjklzxcvbnm", "chair", 0)]
        [InlineData("chairchairchair", "chair", 3)]
        [InlineData("chair", "chair", 1)]
        [InlineData("chair", "chairs", 0)]
        [InlineData("aaaaa", "a", 5)]
        [InlineData("xabababx", "abab", 1)]
        public void CountOcurrencesWordSpan_Should_Return_Number_Of_Times_That_It_Appears(string source, string word, int ocurrences)
        {
            var numnerOfTimes = StringUtils.CountOcurrencesSpan(source, word);
            Assert.Equal(ocurrences, numnerOfTimes);
        }

        [Theory]
        [InlineData("qhouseuiohouseghjklhousenm", "house", 3)]
        [InlineData("tableyuiopasdfghtablecvbnm", "table", 2)]
        [InlineData("qwertyuiopasdfghjklzxcvbnm", "chair", 0)]
        [InlineData("chairchairchair", "chair", 3)]
        [InlineData("chair", "chair", 1)]
        [InlineData("chair", "chairs", 0)]
        [InlineData("aaaaa", "a", 5)]
        [InlineData("xabababx", "abab", 1)]
        public void CountOcurrencesWordSpanOptimist_Should_Return_Number_Of_Times_That_It_Appears(string source, string word, int ocurrences)
        {
            var numnerOfTimes = StringUtils.CountOcurrencesSpanOptimist(source, word);
            Assert.Equal(ocurrences, numnerOfTimes);
        }

        [Theory]
        [InlineData("qhouseuiohouseghjklhousenm", "house", 3)]
        [InlineData("tableyuiopasdfghtablecvbnm", "table", 2)]
        [InlineData("qwertyuiopasdfghjklzxcvbnm", "chair", 0)]
        [InlineData("chairchairchair", "chair", 3)]
        [InlineData("chair", "chair", 1)]
        [InlineData("chair", "chairs", 0)]
        [InlineData("aaaaa", "a", 5)]
        [InlineData("xabababx", "abab", 1)]
        public void CountOcurrencesSpanLoop_Should_Return_Number_Of_Times_That_It_Appears(string source, string word, int ocurrences)
        {
            var numnerOfTimes = StringUtils.CountOcurrencesSpanLoop(source, word);
            Assert.Equal(ocurrences, numnerOfTimes);
        }

        [Theory]
        [InlineData("qhouseuiohouseghjklhousenm", "house", 3)]
        [InlineData("tableyuiopasdfghtablecvbnm", "table", 2)]
        [InlineData("qwertyuiopasdfghjklzxcvbnm", "chair", 0)]
        [InlineData("chair", "chair", 1)]
        [InlineData("chair", "chairs", 0)]
        [InlineData("xabababx", "abab", 1)]
        public void CountOcurrencesPattern_Should_Return_Number_Of_Times_That_It_Appears(string source, string word, int ocurrences)
        {
            var numnerOfTimes = StringUtils.CountOcurrencesPattern(source, word);
            Assert.Equal(ocurrences, numnerOfTimes);
        }
    }
}