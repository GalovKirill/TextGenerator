using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TextGenerator
{
    class Program
    {

        static Program()
        {
            Text = new  string(File.ReadAllText("res.txt").Where(c => Symbols.ValidSymbol.Contains(c)).ToArray());
        }

        public static readonly string Text;
        

        public readonly static ILoadStrategy LoadStrategy = new LongCharSetThread();

        private static void Main(string[] args)
        {
            try
            {
                Work();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }

        private static void Work()
        {
            // Console.WriteLine(PrintList(Symbols.Chars));
            // Console.Read();
            K.Value = 7;
            LoadStrategy.Load();
            var chars = LoadStrategy.GetResult();
            
            var startIndex = new Random().Next(1000, Text.Length - 1000);

            var s = Text.Substring(startIndex, 15);

            for(int i = 0; i < 100; i++)
            {
                SubString subs = s.LastSubs();
                char c = chars.Next(subs);

                s += c;
            }

            Console.WriteLine(s);

            Console.WriteLine("Done");
            
            Console.ReadKey();
        }

        private static string PrintList(IEnumerable<char> l)
        {
            var stringBuilder = new StringBuilder();
            foreach (var c in l)
            {
                stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }

        /*
            int collisions = chars.Keys.Count - chars.Keys.Select(k => k.GetHashCode()).ToHashSet().Count;
            Console.WriteLine($"collisions - {collisions}");
           
            new CharsStatistic().Print(chars);           
           
            Console.Read();
            return;
            

            var ints = chars.Keys
                .GroupBy(k => k.GetHashCode())
                // .Select(g => g.Count())
                .OrderByDescending(c => c.Count())
                .First()
                .Select(s => (s, PrintList(chars[s])));
            
            foreach (var(subst, cs) in ints)
            {
                Console.WriteLine(subst + " | " + cs);
            }
        */
    }
}