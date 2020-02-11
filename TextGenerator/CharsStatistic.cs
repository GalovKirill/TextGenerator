using System;
using System.Linq;
using System.Collections.Generic;

namespace TextGenerator
{
    class CharsStatistic : IAnalysis
    {
        public void Print(IDictionary<SubString, List<char>> chars)
        {
            var stats = new Dictionary<char, double>();
            double len = Program.Text.Length;
            foreach(var c in Program.Text)
            {
                if(stats.ContainsKey(c))
                    stats[c] += 1d / len;
                else
                    stats.Add(c, 1d / len);
            }

            foreach (var(c, percent) in stats.OrderByDescending(p => p.Value))
            {
                Console.WriteLine($"char {c} - {percent:0.000} - abs - {(int)(percent * len)}");
            }
        }
    }
}