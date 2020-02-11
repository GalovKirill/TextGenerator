using System.Collections.Generic;
using System.Linq;

namespace TextGenerator.OldCode.SRTG2
{
    public class KgrammsCollection
    {
        public KgrammsCollection(Dictionary<Kgramm, IList<char>> dictionary)
        {
            _eftagramms = dictionary;
        }
        private readonly Dictionary<Kgramm, IList<char>> _eftagramms;

        public char GetRandomCharFrom(string s)
        {
            var tempEf = new Kgramm(s);
            var t = _eftagramms[tempEf];
            return t.GetRandomElement();
        }

        public string RandomStart()
        {
            var keyarr = _eftagramms.Keys.ToArray();
            return keyarr[ExtensionsMethod.RandomNumber(keyarr.Length)].ToString();
        }

        //public void PrintDRV(string s)
        //{
        //    _eftagramms.First(kv => kv.Key.EqStr(s)).Value.PrintDRV();
        //}
    }
}