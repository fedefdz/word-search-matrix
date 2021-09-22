using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace WordSearch.Sample
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Please enter matrix file and stremword file");
                return 1;
            }
            var matrixpath = args[0];
            var streampath = args[1];

            var matrix = File.ReadAllLines(matrixpath);
            var streams = File.ReadAllLines(streampath);
            WriteLineArray(matrix);

            var wf = new WordFinder(matrix);

            foreach (var stream in streams)
            {
                var words = stream.Split(' ');
                Console.WriteLine($"\nstream[{words.Length}]: {stream}");
                Console.WriteLine($"rank:");

                var sw = Stopwatch.StartNew();
                var top10 = wf.Find(words);
                var duration = sw.Elapsed;
                sw.Stop();

                WriteLineArray(top10);
                Console.WriteLine($"search completed in {duration.TotalMilliseconds}ms");
            }

            return 0;
        }

        private static void WriteLineArray(IEnumerable<string> arr)
        {
            if (!arr.Any())
            {
                Console.WriteLine("[]");
                return;
            }

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}