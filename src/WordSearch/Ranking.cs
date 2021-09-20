using System.Collections.Generic;
using System.Linq;

namespace WordSearch
{
    public class Ranking : Dictionary<string, int>
    {
        public Ranking(IEnumerable<string> words)
        {
            foreach (var word in words)
                this.TryAdd(word, 0);
        }

        public IEnumerable<string> Top(int top) => this.OrderByDescending(x => x.Value)
            .Where(x => x.Value > 0)
            .Take(top).Select(x => x.Key);
    }
}