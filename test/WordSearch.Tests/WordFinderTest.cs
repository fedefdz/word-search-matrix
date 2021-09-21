using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WordSearch.Tests
{
    public class WordFinderTest
    {
        public static readonly string[] MatrixEmpty = { };

        [Fact]
        public void WordFinder_Constructor_Must_Initialize_From_An_NxN_Matrix()
        {
            var sut = new WordFinder(Stubs.MatrixSample);

            Assert.NotNull(sut);
        }

        [Fact]
        public void WordFinder_Constructor_When_Matrix_Source_Is_Empty_ThrowException()
        {
            IEnumerable<string> matrixsource = null;

            Action actual = () => new WordFinder(matrixsource);

            Assert.Throws<MatrixException>(actual);
        }

        [Fact]
        public void WordFinder_Find_When_Word_Stream_Has_Duplicates_Only_Show_One()
        {
            var wordstream = new[]
            {
                "sun", "wind", "snow", "day",
                "sun", "wind", "snow", "day",
                "sun", "wind"
            };

            // sut not contains 'snow' word
            var sut = new WordFinder(Stubs.MatrixSample);
            var result = sut.Find(wordstream);

            Assert.Equal(3, result.Count());
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(30)]
        [InlineData(50)]
        [InlineData(60)]
        public void WordFinder_Find_Show_Ranking_Result(int N)
        {
            var wordstream = new[] { "sun", "wind", "day", "snow", "day" };

            // MatrixBig contains this rank
            // day -> 3
            // wind -> 2
            // sun -> 1
            var matrixsource = Stubs.RepeatMatrixBuilderAppend(Stubs.MatrixSample, N / Stubs.MatrixSample.Length);
            var sut = new WordFinder(matrixsource);
            var result = sut.Find(wordstream);

            Assert.Collection(result,
                item => Assert.Equal("day", item),
                item => Assert.Equal("wind", item),
                item => Assert.Equal("sun", item));
        }
    }
}