using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace TextGenerator.OldCode.SRTG2
{
    public class DRV<T>
    {
        private static readonly RandomNumberGenerator _rng = RandomNumberGenerator.Create();
        private readonly Dictionary<T, int> _dic = new Dictionary<T, int>();
        private readonly int _limitValue;
        public DRV(IEnumerable<KeyValuePair<T, int>> dic)
        {
            int acc = 0;
            var t = dic.OrderBy(kv => kv.Value).Select(kv => 
            {
                acc += kv.Value;
                return new KeyValuePair<T,int>(kv.Key, acc);
            });
            _dic = new Dictionary<T,int>(t);
            _limitValue = _dic.Last().Value;
            
        }
        
        public DRV(IEnumerable<T> list)
        {
            var dic = new Dictionary<T, int>();
            foreach (var item in list)
            {
                if(dic.ContainsKey(item)) continue;
                int v = list.Count(c => c.GetHashCode() == item.GetHashCode() && c.Equals(item));
                dic.Add(item,v);
            }
            int acc = 0;
            var temp = dic.OrderBy(kv => kv.Value).Select(kv => 
            {
                acc += kv.Value;
                return new KeyValuePair<T,int>(kv.Key, acc);
            });        
            _dic = new Dictionary<T,int>(temp);
            _limitValue = _dic.Last().Value;
        }
        public T GetRandomValue()
        {   
            int p = RandomNumber();
            foreach (var kv in _dic)
            {
                if(p < kv.Value) return kv.Key;
            }
            throw new Exception("GetRandomValue " + p);
        }

        private int RandomNumber()
        {
            byte[] bytes = new byte[4];
            _rng.GetBytes(bytes);
            
            return Math.Abs(BitConverter.ToInt32(bytes, 0)) % _limitValue;
        }

        public void PrintDRV()
        {
            foreach (var item in _dic)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            Console.WriteLine(_limitValue.ToString());
        }

      
    }
}
