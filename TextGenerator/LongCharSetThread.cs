using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TextGenerator
{
    internal class LongCharSetThread : ILoadStrategy
    {
        private Dictionary<int, long>[] _chars;

        private const int ConcurrencyLevel = 4;

        public LongCharSetThread()
        {
            SubstringEqualityComparer.Instance.Left = Program.Text;
            SubstringEqualityComparer.Instance.Right = Program.Text;
        }

            
        public void Load()
        {
            var readLen = Program.Text.Length - K.Value - 1;
            var timer = Stopwatch.StartNew();
            Task<Dictionary<int, long>>[] tasks = Enumerable.Range(1, ConcurrencyLevel)
            .Select(i => new { Start = (i-1) * readLen / ConcurrencyLevel, End = i * readLen / ConcurrencyLevel})
            .Select(range => Task.Run(() => Create(range.Start, range.End)))
            .ToArray();
            
            Task.WaitAll(tasks);

            Console.WriteLine($"text load at {timer.Elapsed}");

            _chars = tasks.Select(t => t.Result).ToArray();
            
        }

        private static Dictionary<int, long> Create(int start, int end)
        {
            var result = new Dictionary<int, long>(end - start, SubstringEqualityComparer.Instance);
            for(var i = start; i < end; i++)
            {
                if (result.TryGetValue(i, out var cs))
                    result[i] = cs.Add(Program.Text[i + K.Value]);
                else
                    result.Add(i, Program.Text[i + K.Value].ToLong());
            }
            return result;
        }

        public ICharGenerator GetResult()
        {
            return new MultiDicCharGenerator(_chars);
        }
    }
}