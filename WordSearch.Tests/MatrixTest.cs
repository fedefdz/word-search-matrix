using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}