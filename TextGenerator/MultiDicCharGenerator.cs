using System.Collections.Generic;

namespace TextGenerator
{
    internal class MultiDicCharGenerator : ICharGenerator
    {
        private readonly Dictionary<int, long>[] _chars;

        public MultiDicCharGenerator(Dictionary<int, long>[] chars)
        {
            _chars = chars;
        }

        public char Next(int shift)
        {
            long cs = 0;

            foreach (Dictionary<int, long> dic in _chars)
            {
                if(dic.TryGetValue(shift, out var l)) 
                    cs |= l;
            }

            return cs.RandomElem();
        }
    }
}