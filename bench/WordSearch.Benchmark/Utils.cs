using System.Collections.Generic;
using System.Text;

namespace WordSearch.Benchmark
{
    public class Utils
    {
        public static readonly string[] PatternMatrix = new string[]
        {
            "abcdcefg",
            "fgwiopqr",
            "chilllkj",
            "pqnsumme",
            "uvdxydsu",
            "abcdcefg",
            "fgwiopqr",
            "chilllkj"
        };

        public static readonly string[] SampleMatrix = new string[]
        {
            "abcdc",
            "fgwio",
            "chill",
            "pqnsd",
            "uvdxy"
        };

        public static string RepeatStringBuilderAppend(string s, int n) => new StringBuilder(s.Length * n)
            .AppendJoin(s, new string[n + 1])
            .ToString();

        public static IEnumerable<string> RepeatMatrixBuilderAppend(string[] matrixpattern, int n)
        {
            var matrix = new string[matrixpattern.Length * n];
            for (int i = 0; i < matrixpattern.Length; i++)
            {
                matrix[i] = RepeatStringBuilderAppend(matrixpattern[i], n);
            }

            for (int j = matrixpattern.Length - 1; j < matrixpattern.Length * n; j++)
            {
                matrix[j] = matrix[j - (matrixpattern.Length - 1)];
            }

            return matrix;
        }
    }
}