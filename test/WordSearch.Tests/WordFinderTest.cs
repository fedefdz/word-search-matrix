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
                "cold", "wind", "snow", "chill",
                "cold", "wind", "snow", "chill",
                "cold", "wind"
            };

            // sut not contains 'snow' word
            var sut = new WordFinder(Stubs.MatrixSample);
            var result = sut.Find(wordstream);

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void WordFinder_Find_Show_Result()
        {
            var wordstream = new[] { "cold", "wind", "snow", "chill" };

            // MatrixBig contains this rank
            // chill -> 3
            // cold -> 2
            // wind -> 1
            var sut = new WordFinder(Stubs.MatrixBig);
            var result = sut.Find(wordstream);

            Assert.Collection(result,
                item => Assert.Equal("chill", item),
                item => Assert.Equal("cold", item),
                item => Assert.Equal("wind", item));
        }
    }
}