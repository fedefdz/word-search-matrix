using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using WS = WordSearch;

namespace WordSearch.Benchmark
{
    public abstract class WordFinderBenchmark
    {
        private readonly int _sizeMatrix;

        private WS.WordFinder _finder;

        protected WordFinderBenchmark(int sizematrix)
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

            _finder = new WS.WordFinder(matrixsource);
        }

        [GlobalCleanup]
        public void GlobalCleanup() => _finder = null;

        [Benchmark]
        [ArgumentsSource(nameof(WordstreamData))]
        public void Find(string[] wordstream) => _finder.Find(wordstream);
    }

    public class WordFinderN60Benchmark : WordFinderBenchmark
    {
        public WordFinderN60Benchmark() : base(60)
        {
        }
    }

    public class WordFinderN50Benchmark : WordFinderBenchmark
    {
        public WordFinderN50Benchmark() : base(50)
        {
        }
    }

    public class WordFinderN45Benchmark : WordFinderBenchmark
    {
        public WordFinderN45Benchmark() : base(45)
        {
        }
    }

    public class WordFinderN40Benchmark : WordFinderBenchmark
    {
        public WordFinderN40Benchmark() : base(40)
        {
        }
    }

    public class WordFinderN35Benchmark : WordFinderBenchmark
    {
        public WordFinderN35Benchmark() : base(35)
        {
        }
    }

    public class WordFinderN30Benchmark : WordFinderBenchmark
    {
        public WordFinderN30Benchmark() : base(30)
        {
        }
    }

    public class WordFinderN25Benchmark : WordFinderBenchmark
    {
        public WordFinderN25Benchmark() : base(25)
        {
        }
    }

    public class WordFinderN20Benchmark : WordFinderBenchmark
    {
        public WordFinderN20Benchmark() : base(20)
        {
        }
    }

    public class WordFinderN15Benchmark : WordFinderBenchmark
    {
        public WordFinderN15Benchmark() : base(15)
        {
        }
    }

    public class WordFinderN10Benchmark : WordFinderBenchmark
    {
        public WordFinderN10Benchmark() : base(10)
        {
        }
    }

    public class WordFinderN05Benchmark : WordFinderBenchmark
    {
        public WordFinderN05Benchmark() : base(5)
        {
        }
    }
}