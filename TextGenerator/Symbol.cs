using System;
using System.Collections.Generic;
using System.Linq;

namespace TextGenerator
{
    public static class Symbols
    {
        public const string ValidSymbol = "абвгдёежзийклмнопрстуфхцчшщъыьэюя" +
                                          "АБВГДЕЖЗИКЛМНОПРСТУФХЧШЭЮЯ" + ". ,!?";
        public static readonly List<char> Chars;
        private static readonly Random R = new Random();

        static Symbols()
        {
            var lst = ValidSymbol.ToList();
            lst.Sort();
            Chars = lst;

        }

        public static long Add(this long l, char c) => l | c.ToLong();

        public static long ToLong(this char c) => 1L << Chars.BinarySearch(c);

    

        public static bool BitFlagged(this long l, int bit) => ((1L << bit) & l) != 0;
        public static T RandomElem<T>(this IList<T> lst) => lst[R.Next(0, lst.Count)];

        private static readonly List<char> Cs = new(64);
        public static char RandomElem(this long l)
        {
            Cs.Clear();   
            for(var i = 0; i < 64; i++)
            {
                if(l.BitFlagged(i)) 
                    Cs.Add(Chars[i]);
            }

            return Cs.RandomElem();
        }
    }
}