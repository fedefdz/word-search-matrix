using AutoFixture;
using System;
using System.Collections.Generic;
using Xunit;

namespace WordSearch.Tests
{
    public class SmartSearcherStrategyTest
    {
        [Theory]
        [InlineData(5, 10)]
        [InlineData(10, 10)]
        [InlineData(20, 5)]
        [InlineData(20, 15)]
        public void MatrixSmartSeracherStrategy_SelectBestFor_Matrix_N_LessOrEqual_Than_20_Should_Return_Searcher_Sequential(int N, int streamLenght)
        {
            var matrix = new MatrixFlyweight(GenerateEnumerableStringMatrix(N));
            var random = new Random();
            var minLenght = random.Next(5);
            var stream = RandomWordStream(streamLenght, streamLenght, minLenght, minLenght + 10);

            var searcher = SmartSearch.MatrixSmartSeracherStrategy.SelectBestFor(matrix, stream);

            Assert.IsType<SmartSearch.Sequential.MatrixFlyweightSmartSearcherSequential>(searcher);
        }

        [Theory]
        [InlineData(21, 5)]
        [InlineData(21, 12)]
        [InlineData(25, 5)]
        [InlineData(30, 12)]
        [InlineData(35, 5)]
        [InlineData(35, 12)]
        public void MatrixSmartSeracherStrategy_SelectBestFor_Matrix_N_LessOrEqual_Than_35_And_Stream_LessOrEqual_12_Should_Return_Searcher_Sequential(int N, int streamLenght)
        {
            var matrix = new MatrixFlyweight(GenerateEnumerableStringMatrix(N));
            var random = new Random();
            var minLenght = random.Next(5);
            var stream = RandomWordStream(streamLenght, streamLenght, minLenght, minLenght + 10);

            var searcher = SmartSearch.MatrixSmartSeracherStrategy.SelectBestFor(matrix, stream);

            Assert.IsType<SmartSearch.Sequential.MatrixFlyweightSmartSearcherSequential>(searcher);
        }

        [Theory]
        [InlineData(21, 13)]
        [InlineData(25, 15)]
        [InlineData(30, 20)]
        [InlineData(35, 20)]
        [InlineData(35, 13)]
        public void MatrixSmartSeracherStrategy_SelectBestFor_Matrix_N_LessOrEqual_Than_35_And_Stream_Greater_12_Should_Return_Searcher_Parallel(int N, int streamLenght)
        {
            var matrix = new MatrixFlyweight(GenerateEnumerableStringMatrix(N));
            var random = new Random();
            var minLenght = random.Next(5);
            var stream = RandomWordStream(streamLenght, streamLenght, minLenght, minLenght + 10);

            var searcher = SmartSearch.MatrixSmartSeracherStrategy.SelectBestFor(matrix, stream);

            Assert.IsType<SmartSearch.Parallel.MatrixFlyweightSmartSearcherParallel>(searcher);
        }

        [Theory]
        [InlineData(36, 1)]
        [InlineData(40, 2)]
        [InlineData(50, 3)]
        public void MatrixSmartSeracherStrategy_SelectBestFor_Matrix_N_LessOrEqual_Than_50_And_Stream_LessOrEqual_03_Should_Return_Searcher_Sequential(int N, int streamLenght)
        {
            var matrix = new MatrixFlyweight(GenerateEnumerableStringMatrix(N));
            var random = new Random();
            var minLenght = random.Next(5);
            var stream = RandomWordStream(streamLenght, streamLenght, minLenght, minLenght + 10);

            var searcher = SmartSearch.MatrixSmartSeracherStrategy.SelectBestFor(matrix, stream);

            Assert.IsType<SmartSearch.Sequential.MatrixFlyweightSmartSearcherSequential>(searcher);
        }

        [Theory]
        [InlineData(36, 4)]
        [InlineData(40, 10)]
        [InlineData(50, 7)]
        public void MatrixSmartSeracherStrategy_SelectBestFor_Matrix_N_LessOrEqual_Than_50_And_Stream_Greater_03_Should_Return_Searcher_Parallel(int N, int streamLenght)
        {
            var matrix = new MatrixFlyweight(GenerateEnumerableStringMatrix(N));
            var random = new Random();
            var minLenght = random.Next(5);
            var stream = RandomWordStream(streamLenght, streamLenght, minLenght, minLenght + 10);

            var searcher = SmartSearch.MatrixSmartSeracherStrategy.SelectBestFor(matrix, stream);

            Assert.IsType<SmartSearch.Parallel.MatrixFlyweightSmartSearcherParallel>(searcher);
        }

        [Theory]
        [InlineData(51, 1)]
        [InlineData(55, 1)]
        [InlineData(60, 1)]
        public void MatrixSmartSeracherStrategy_SelectBestFor_Matrix_N_LessOrEqual_Than_60_And_Stream_Equal_01_Should_Return_Searcher_Sequential(int N, int streamLenght)
        {
            var matrix = new MatrixFlyweight(GenerateEnumerableStringMatrix(N));
            var random = new Random();
            var minLenght = random.Next(5);
            var stream = RandomWordStream(streamLenght, streamLenght, minLenght, minLenght + 10);

            var searcher = SmartSearch.MatrixSmartSeracherStrategy.SelectBestFor(matrix, stream);

            Assert.IsType<SmartSearch.Sequential.MatrixFlyweightSmartSearcherSequential>(searcher);
        }

        [Theory]
        [InlineData(51, 2)]
        [InlineData(55, 10)]
        [InlineData(60, 2)]
        public void MatrixSmartSeracherStrategy_SelectBestFor_Matrix_N_LessOrEqual_Than_60_And_Stream_Greater_01_Should_Return_Searcher_Parallel(int N, int streamLenght)
        {
            var matrix = new MatrixFlyweight(GenerateEnumerableStringMatrix(N));
            var random = new Random();
            var minLenght = random.Next(5);
            var stream = RandomWordStream(streamLenght, streamLenght, minLenght, minLenght + 10);

            var searcher = SmartSearch.MatrixSmartSeracherStrategy.SelectBestFor(matrix, stream);

            Assert.IsType<SmartSearch.Parallel.MatrixFlyweightSmartSearcherParallel>(searcher);
        }

        [Theory]
        [InlineData(61, 1)]
        [InlineData(64, 10)]
        [InlineData(64, 2)]
        public void MatrixSmartSeracherStrategy_SelectBestFor_Matrix_N_Greater_Than_60_Should_Return_Searcher_Parallel(int N, int streamLenght)
        {
            var matrix = new MatrixFlyweight(GenerateEnumerableStringMatrix(N));
            var random = new Random();
            var minLenght = random.Next(5);
            var stream = RandomWordStream(streamLenght, streamLenght, minLenght, minLenght + 10);

            var searcher = SmartSearch.MatrixSmartSeracherStrategy.SelectBestFor(matrix, stream);

            Assert.IsType<SmartSearch.Parallel.MatrixFlyweightSmartSearcherParallel>(searcher);
        }

        public static IEnumerable<string> GenerateEnumerableStringMatrix(int n)
        {
            var word = new string('x', n);
            var stream = new string[n];
            for (int i = 0; i < n; i++)
            {
                stream[i] = word;
            }
            return stream;
        }

        public static IEnumerable<string> RandomWordStream(int minStream, int maxStream, int minLength, int maxLength)
        {
            var random = new Random();

            var n = random.Next(minLength, maxLength);
            var word = new string('x', n);

            var size = random.Next(minStream, maxStream);
            var stream = new string[size];
            for (int i = 0; i < size; i++)
            {
                stream[i] = word;
            }
            return stream;
        }
    }
}