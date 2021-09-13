using System;
using Xunit;

namespace WordSearch.Tests
{
    public class MatrixTest
    {
        [Fact]
        public void Matrix_RowAsString_Return_All_Chars_Of_Index_Row_As_String()
        {
            var matrix = new Matrix(Stubs.MatrixSample);

            var actual = matrix.RowAsString(2);

            Assert.Equal("chill", actual);
            Assert.Equal(5, actual.Length);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(5)]
        public void Matrix_RowAsString_When_Index_Out_Of_Range_ThrowException(int index)
        {
            var matrix = new Matrix(Stubs.MatrixSample);

            Action actual = () => matrix.RowAsString(index);

            Assert.Throws<MatrixException>(actual);
            Assert.Equal(5, matrix.Rows);
        }

        [Fact]
        public void Matrix_ColumnAsString_Return_All_Chars_Of_Index_Column_As_String()
        {
            var matrix = new Matrix(Stubs.MatrixSample);

            var actual = matrix.ColumnAsString(2);

            Assert.Equal("cwind", actual);
            Assert.Equal(5, actual.Length);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(5)]
        public void Matrix_ColumnAsString_When_Index_Out_Of_Range_ThrowException(int index)
        {
            var matrix = new Matrix(Stubs.MatrixSample);

            Action actual = () => matrix.ColumnAsString(index);

            Assert.Throws<MatrixException>(actual);
            Assert.Equal(5, matrix.Columns);
        }

        [Theory]
        [InlineData("chill", 3)]
        [InlineData("cold", 1)]
        [InlineData("wind", 0)]
        [InlineData("snow", 0)]
        public void Matrix_CountOcurrences_Return_Number_Of_Ocurrences_Horizontal_Of_A_Word(string word, int ocurrencesExpected)
        {
            var sut = new Matrix(Stubs.MatrixBig);

            var actual = sut.CountHorizontalOcurrences(word);

            Assert.Equal(ocurrencesExpected, actual);
        }

        [Theory]
        [InlineData("chill", 0)]
        [InlineData("cold", 0)]
        [InlineData("llihc", 1)]
        [InlineData("dloc", 1)]
        [InlineData("wind", 1)]
        [InlineData("snow", 0)]
        public void Matrix_CountOcurrences_Return_Number_Of_Ocurrences_Vertical_Of_A_Word(string word, int ocurrencesExpected)
        {
            var sut = new Matrix(Stubs.MatrixBig);

            var actual = sut.CountVerticalOcurrences(word);

            Assert.Equal(ocurrencesExpected, actual);
        }

        [Theory]
        [InlineData("chill", 3)]
        [InlineData("cold", 1)]
        [InlineData("wind", 0)]
        [InlineData("snow", 0)]
        public void Matrix_CountOcurrencesSpan_Return_Number_Of_Ocurrences_Horizontal_Of_A_Word(string word, int ocurrencesExpected)
        {
            var sut = new Matrix(Stubs.MatrixBig);

            var actual = sut.CountHorizontalOcurrencesSpan(word);

            Assert.Equal(ocurrencesExpected, actual);
        }

        [Theory]
        [InlineData("chill", 0)]
        [InlineData("cold", 0)]
        [InlineData("llihc", 1)]
        [InlineData("dloc", 1)]
        [InlineData("wind", 1)]
        [InlineData("snow", 0)]
        public void Matrix_CountOcurrencesSpan_Return_Number_Of_Ocurrences_Vertical_Of_A_Word(string word, int ocurrencesExpected)
        {
            var sut = new Matrix(Stubs.MatrixBig);

            var actual = sut.CountVerticalOcurrencesSpan(word);

            Assert.Equal(ocurrencesExpected, actual);
        }
    }
}