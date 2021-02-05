using System;
using System.Collections.Generic;
using System.Linq;

namespace TextGenLib
{
    public class CharGenerator 
    {
        private  readonly Random _r = new();
        private readonly List<char> _validSymbols = new();
        private readonly List<char> _csBuffer = new(64);
        private readonly Dictionary<int, long>[] _charSource;
        
        public CharGenerator(Dictionary<int, long>[] charSource)
        {
            _charSource = charSource;
            _validSymbols.AddRange("абвгдёежзийклмнопрстуфхцчшщъыьэюя".ToCharArray());
            _validSymbols.AddRange("АБВГДЕЖЗИКЛМНОПРСТУФХЧШЭЮЯ".ToCharArray());
            _validSymbols.AddRange(". ,!?".ToCharArray());
            _validSymbols.Sort();
        }

        public char Next(int shift)
        {
            long cs = 0;

            foreach (Dictionary<int, long> dic in _charSource)
            {
                if(dic.TryGetValue(shift, out var l)) 
                    cs |= l;
            }

            _csBuffer.Clear();   
            for(var i = 0; i < 64; i++)
            {
                if(BitFlagged(cs, i)) 
                    _csBuffer.Add(_validSymbols[i]);
            }

            return _csBuffer[_r.Next(0, _csBuffer.Count)];
        }
        
        

        public long Add(long l, char c) => l | ToLong(c);

        private long ToLong(char c) => 1L << _validSymbols.BinarySearch(c);


        private static bool BitFlagged(long l, int bit) => ((1L << bit) & l) != 0;

    }
}