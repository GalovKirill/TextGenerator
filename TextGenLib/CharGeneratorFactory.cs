using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace TextGenLib
{
    public class CharGeneratorFactory
    {
        public CharGenerator Create(string text, string validSymbols, int k = 2)
        {
            if (validSymbols.Length != 64)
            {
                throw new ArgumentException("Length of validSymbols must be equal 64");
            }

            HashSet<char> validSet = new (validSymbols);
            string processedText = new (text.Where(validSet.Contains).ToArray());

            int readLen = processedText.Length - k - 1;
            
            var sortedValidSym = validSet.ToList();
            sortedValidSym.Sort();
            Dictionary<int, long> subs = new(1000, new SubstringEqualityComparer());
            var cs = text.AsSpan(0, readLen);
            foreach (var c in cs)
            {
            }

            for (int i = 0; i < readLen; i++)
            {
                long newSet = 1L << sortedValidSym.BinarySearch(text[i]);
                if (subs.TryGetValue(i, out long charSet))
                    subs[i] = charSet | newSet;
                else
                    subs.Add(i, newSet);
            }

            return new CharGenerator(new[] {subs});
        }


    }
}