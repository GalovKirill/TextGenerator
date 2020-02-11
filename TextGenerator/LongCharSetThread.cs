using System;
using System.Collections;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TextGenerator
{
    class LongCharSetThread : ILoadStrategy
    {
        private Dictionary<SubString, long>[] _chars;

        private int _concurrencyLevel = 4;

            
        public void Load()
        {
            var readLen = Program.Text.Length - K.Value - 1;
            Stopwatch timer = Stopwatch.StartNew();
            var tasks = Enumerable.Range(1, _concurrencyLevel)
            .Select(i => ((i-1) * readLen / _concurrencyLevel, i * readLen / _concurrencyLevel))
            .Select(pair => Task.Run(() => Create(pair.Item1, pair.Item2)))
            .ToArray();
            
            Task.WaitAll(tasks);

            Console.WriteLine($"waited seconds {timer.Elapsed}");

            _chars = tasks.Select(t => t.Result).ToArray();
            
        }

        private static Dictionary<SubString, long> Create(int start, int end)
        {
            Dictionary<SubString, long> result = new Dictionary<SubString, long>(end - start);
            for(var i = start; i < end; i++)
            {
                var c = Program.Text[i + K.Value + 1];
                var subs = new SubString(i, Program.Text);
                if (result.ContainsKey(subs))
                {
                    var cs = result[subs];
                    result[subs] = cs.Add(c);
                }
                else
                {
                    result.Add(subs, c.ToLong());
                }
            }
            return result;
        }

        static long Add(SubString subs, char c) => c.ToLong();

        static long Update(SubString subs, long cs, char c) => cs.Add(c);

        public ICharGenerator GetResult()
        {
            return new MultiDicCharGenerator(_chars);
        }
    }
}