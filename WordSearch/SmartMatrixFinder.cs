﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordSearch
{
    public interface ISmartMatrixCounter
    {
        Ranking Rank(Matrix matrix, IEnumerable<string> wordstream);
    }

    public class SmartMatrixCounterStrategy
    {
        public static ISmartMatrixCounter SelectBestFor(Matrix matrix, IEnumerable<string> wordstream) => matrix.N switch
        {
            > 16 => new SmartMatrixCounterSpanParallel(),

            16 when wordstream.Count() > 5 => new SmartMatrixCounterSpanParallel(),

            _ => new SmartMatrixCounterSpan(),
        };
    }

    public class SmartMatrixCounterBasic : ISmartMatrixCounter
    {
        public Ranking Rank(Matrix matrix, IEnumerable<string> wordstream)
        {
            var ranking = new Ranking(wordstream);
            foreach (var key in ranking.Keys)
            {
                var reverse = new string(key.Reverse().ToArray());

                ranking[key] += matrix.CountHorizontalOcurrences(key);
                ranking[key] += matrix.CountHorizontalOcurrences(reverse);
                ranking[key] += matrix.CountVerticalOcurrences(key);
                ranking[key] += matrix.CountVerticalOcurrences(reverse);
            }

            return ranking;
        }
    }

    public class SmartMatrixCounterSpan : ISmartMatrixCounter
    {
        public Ranking Rank(Matrix matrix, IEnumerable<string> wordstream)
        {
            var ranking = new Ranking(wordstream);
            foreach (var key in ranking.Keys)
            {
                var reverse = new string(key.Reverse().ToArray());

                ranking[key] += matrix.CountHorizontalOcurrencesSpan(key);
                ranking[key] += matrix.CountHorizontalOcurrencesSpan(reverse);
                ranking[key] += matrix.CountVerticalOcurrencesSpan(key);
                ranking[key] += matrix.CountVerticalOcurrencesSpan(reverse);
            }

            return ranking;
        }
    }

    public class SmartMatrixCounterParallel : ISmartMatrixCounter
    {
        public Ranking Rank(Matrix matrix, IEnumerable<string> wordstream)
        {
            var ranking = new Ranking(wordstream);
            var tasks = new Task[ranking.Keys.Count * 4];
            var idx = 0;
            foreach (var key in ranking.Keys)
            {
                var reverse = new string(key.Reverse().ToArray());

                tasks[idx] = Task.Run(() => ranking[key] += matrix.CountHorizontalOcurrences(key));
                tasks[idx + 1] = Task.Run(() => ranking[key] += matrix.CountVerticalOcurrences(key));
                tasks[idx + 2] = Task.Run(() => ranking[key] += matrix.CountHorizontalOcurrences(reverse));
                tasks[idx + 3] = Task.Run(() => ranking[key] += matrix.CountVerticalOcurrences(reverse));
                idx += 4;
            }

            Task.WaitAll(tasks);
            return ranking;
        }
    }

    public class SmartMatrixCounterSpanParallel : ISmartMatrixCounter
    {
        public Ranking Rank(Matrix matrix, IEnumerable<string> wordstream)
        {
            var ranking = new Ranking(wordstream);
            var tasks = new Task[ranking.Keys.Count * 4];
            var idx = 0;
            foreach (var key in ranking.Keys)
            {
                var reverse = new string(key.Reverse().ToArray());

                tasks[idx] = Task.Run(() => ranking[key] += matrix.CountHorizontalOcurrencesSpan(key));
                tasks[idx + 1] = Task.Run(() => ranking[key] += matrix.CountVerticalOcurrencesSpan(key));
                tasks[idx + 2] = Task.Run(() => ranking[key] += matrix.CountHorizontalOcurrencesSpan(reverse));
                tasks[idx + 3] = Task.Run(() => ranking[key] += matrix.CountVerticalOcurrencesSpan(reverse));
                idx += 4;
            }

            Task.WaitAll(tasks);
            return ranking;
        }
    }

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