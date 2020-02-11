using System.Collections.Generic;
using System.Linq;

namespace TextGenerator.OldCode.SRTG1
{
    public class EftagrammsCollection
    {
        public EftagrammsCollection(Dictionary<Kgramm, DRV<char>> dictionary)
        {
            _eftagramms = dictionary;
        }
        private readonly Dictionary<Kgramm, DRV<char>> _eftagramms;

        public char GetRandomCharFrom(string s)
        {
            var tempEf = new Kgramm(s);
            return _eftagramms[tempEf].GetRandomValue();
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