using System;
using System.Collections.Generic;
using System.Linq;

namespace TextGenerator{
    class Dispertion : IAnalysis
    {
        public void Print(IDictionary<SubString, List<char>> chars)
        {
            Dictionary<int, int> disp = new Dictionary<int, int>();
            
            foreach (var charsValue in chars.Values)
            {
                if (disp.ContainsKey(charsValue.Count))
                {
                    disp[charsValue.Count] += 1;
                }
                else
                {
                    disp.Add(charsValue.Count, 1);
                }
                
            }
            
            double all = disp.Values.Sum();
            foreach ((int size, int count) in disp.OrderBy(p => p.Key))
            {
                Console.WriteLine($"size {size}, count {count}, percent {count / all}");
            }
            
            Console.WriteLine();
        }
    }
}