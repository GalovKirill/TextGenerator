using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TextGenerator
{
    // class LongCharSet : ILoadStrategy
    // {
    //     private static readonly ConcurrentDictionary<SubString, long> Chars =
    //         new ConcurrentDictionary<SubString, long>();

            
    //     public void Load()
    //     {
    //         var readLen = Program.Text.Length - K.Value - 1;
    //         Stopwatch timer = Stopwatch.StartNew();
            
    //         var result = Parallel.For(0, readLen, i =>
    //         {
    //             var subs = new SubString(i, Program.Text);
    //             Chars.AddOrUpdate(subs, Add, Update, Program.Text[i + K.Value + 1]);
               
    //         });
    //         timer.Stop();
    //         Console.WriteLine($"waited seconds {timer.Elapsed}");
    //         Console.WriteLine($"key count - {Chars.Keys.Count}");
            
    //     }
    //     static long Add(SubString subs, char c) => c.ToLong();

    //     static long Update(SubString subs, long cs, char c) => cs.Add(c);

    //     public IDictionary<SubString, List<char>> GetResult()
    //     {
    //         return null;// Chars;
    //     }
    // }
}