using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using WordSearch.SmartSearch.Parallel;
using WordSearch.SmartSearch.Sequential;

namespace WordSearch.Benchmark.SmartSearch
{
    public abstract class SmartSearcherBaseBenchmark
    {
        private readonly int _sizeMatrix;

        private Matrix _matrix;
        private MatrixFlyweight _matrixFlyweight;

        private MatrixSmartSearcherSequential _matrixSequential;
        private MatrixFlyweightSmartSearcherSequential _matrixFlyweightSequential;

        private MatrixSmartSearcherParallel _matrixParallel;
        private MatrixFlyweightSmartSearcherParallel _matrixFlyweightParallel;

        protected SmartSearcherBaseBenchmark(int sizematrix)
        {
            if (sizematrix % 5 != 0)
                throw new System.ArgumentException($"{nameof(sizematrix)} must be multiple of 5");

            _sizeMatrix = sizematrix;
        }

        public static IEnumerable<string[]> WordstreamData()
        {
            yield return new[] { "cold" };
            yield return new[] { "cold", "wind", "snow" };
            yield return new[] { "cold", "wind", "snow", "chill", "coldycoldy", "chillchill" };
            yield return new[] { "cold", "wind", "snow", "chill", "coldycoldy", "chillchill", "coldycoldycoldy", "chillchillchill", "windcwindcwind" };
            yield return new[] { "cold", "coldy", "wind", "cwind", "snow", "chill", "cwindcwind", "coldycoldy", "chillchill", "coldycoldycoldy", "chillchillchill", "windcwindcwind" };
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            var pattern = Utils.SampleMatrix;
            var repeat = _sizeMatrix / pattern.Length;

            var matrixsource = Utils.RepeatMatrixBuilderAppend(pattern, repeat);

            _matrix = new Matrix(matrixsource);
            _matrixFlyweight = new MatrixFlyweight(matrixsource);

            _matrixSequential = new MatrixSmartSearcherSequential();
            _matrixParallel = new MatrixSmartSearcherParallel();

            _matrixFlyweightSequential = new MatrixFlyweightSmartSearcherSequential();
            _matrixFlyweightParallel = new MatrixFlyweightSmartSearcherParallel();
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            _matrix = null;

            _matrixSequential = null;
            _matrixParallel = null;

            _matrixFlyweightSequential = null;
            _matrixFlyweightParallel = null;
        }

        [Benchmark]
        [BenchmarkCategory("sequential")]
        [ArgumentsSource(nameof(WordstreamData))]
        public void SearcherMatrixSequential(string[] wordstream) => _matrixSequential.Rank(_matrix, wordstream);

        [Benchmark]
        [BenchmarkCategory("parallel")]
        [ArgumentsSource(nameof(WordstreamData))]
        public void SearcherMatrixParallel(string[] wordstream) => _matrixParallel.Rank(_matrix, wordstream);

        [Benchmark]
        [BenchmarkCategory("sequential")]
        [ArgumentsSource(nameof(WordstreamData))]
        public void SearcherFlyweightSequential(string[] wordstream) => _matrixFlyweightSequential.Rank(_matrixFlyweight, wordstream);

        [Benchmark]
        [BenchmarkCategory("parallel")]
        [ArgumentsSource(nameof(WordstreamData))]
        public void SeracherFlyweightParallel(string[] wordstream) => _matrixFlyweightParallel.Rank(_matrixFlyweight, wordstream);
    }

    public class SmartSearchMatrixN60Benchmark : SmartSearcherBaseBenchmark
    {
        public SmartSearchMatrixN60Benchmark() : base(60)
        {
        }
    }

    public class SmartSearchMatrixN50Benchmark : SmartSearcherBaseBenchmark
    {
        public SmartSearchMatrixN50Benchmark() : base(50)
        {
        }
    }

    public class SmartSearchMatrixN45Benchmark : SmartSearcherBaseBenchmark
    {
        public SmartSearchMatrixN45Benchmark() : base(45)
        {
        }
    }

    public class SmartSearchMatrixN40Benchmark : SmartSearcherBaseBenchmark
    {
        public SmartSearchMatrixN40Benchmark() : base(40)
        {
        }
    }

    public class SmartSearchMatrixN35Benchmark : SmartSearcherBaseBenchmark
    {
        public SmartSearchMatrixN35Benchmark() : base(35)
        {
        }
    }

    public class SmartSearchMatrixN30Benchmark : SmartSearcherBaseBenchmark
    {
        public SmartSearchMatrixN30Benchmark() : base(30)
        {
        }
    }

    public class SmartSearchMatrixN25Benchmark : SmartSearcherBaseBenchmark
    {
        public SmartSearchMatrixN25Benchmark() : base(25)
        {
        }
    }

    public class SmartSearchMatrixN20Benchmark : SmartSearcherBaseBenchmark
    {
        public SmartSearchMatrixN20Benchmark() : base(20)
        {
        }
    }

    public class SmartSearchMatrixN15Benchmark : SmartSearcherBaseBenchmark
    {
        public SmartSearchMatrixN15Benchmark() : base(15)
        {
        }
    }

    public class SmartSearchMatrixN10Benchmark : SmartSearcherBaseBenchmark
    {
        public SmartSearchMatrixN10Benchmark() : base(10)
        {
        }
    }

    public class SmartSearchMatrixN05Benchmark : SmartSearcherBaseBenchmark
    {
        public SmartSearchMatrixN05Benchmark() : base(5)
        {
        }
    }
}