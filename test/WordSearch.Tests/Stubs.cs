using System.Collections.Generic;
using System.Text;

namespace WordSearch.Tests
{
    public class Stubs
    {
        public static readonly string[] MatrixSample =
        {
            "nusdc",
            "fgwio",
            "dwind",
            "aqnsa",
            "yadxy"
        };

        public static readonly string[] MatrixBig =
        {
            "abcdcchill",
            "fgwiofgwio",
            "chillchill",
            "pqnslpqnsd",
            "uvdxlucold",
            "xyxyiyxyxy",
            "xllihcydyx",
            "xyxycyxlxy",
            "xyxoxyxoxy",
            "xyxcxyxcxy"
        };

        public static IEnumerable<string> RepeatMatrixBuilderAppend(string[] matrixpattern, int n)
        {
            var matrix = new string[matrixpattern.Length * n];
            for (int i = 0; i < matrixpattern.Length; i++)
            {
                matrix[i] = RepeatStringBuilderAppend(matrixpattern[i], n);
            }

            for (int j = matrixpattern.Length; j < matrixpattern.Length * n; j++)
            {
                matrix[j] = matrix[j - (matrixpattern.Length)];
            }

            return matrix;
        }

        public static string RepeatStringBuilderAppend(string s, int n) => new StringBuilder(s.Length * n)
            .AppendJoin(s, new string[n + 1])
            .ToString();
    }
}