using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TextGenerator
{
    // class ConcurrentDicWithParallel : ILoadStrategy
    // {
    //     private static readonly ConcurrentDictionary<SubString, List<char>> Chars =
    //         new ConcurrentDictionary<SubString, List<char>>();

            
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
    //     static List<char> Add(SubString subs, char c) => new List<char> {c};

    //     static List<char> Update(SubString subs, List<char> cs, char c)
    //     {
    //         if(!cs.Contains(c))
    //             cs.Add(c);
    //         return cs;
    //     }

    //     public IDictionary<SubString, List<char>> GetResult()
    //     {
    //         return Chars;
    //     }
    // }
}