using System.Collections.Generic;

namespace TextGenerator
{
    class MultiDicCharGenerator : ICharGenerator
    {
        private readonly Dictionary<SubString, long>[] _chars;

        public MultiDicCharGenerator(Dictionary<SubString, long>[] chars)
        {
            _chars = chars;
        }

        public char Next(SubString subs)
        {
            long cs = 0;

            foreach (var dic in _chars)
            {
                if(dic.TryGetValue(subs, out var l))
                {
                    cs |= l;
                }
            }

            if(cs == 0)
            {
                System.Console.WriteLine(" osibka"+subs);
                return 'а';
            }

            return cs.RandomElem();
        }
    }
}