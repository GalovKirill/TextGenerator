using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TextGenerator.OldCode.SRTG1
{
    public class EftagrammsReader
    {   
        public  static EftagrammsCollection GetEftagramms(string text)
        {
            Stopwatch timer = Stopwatch.StartNew();
            var dic = new ConcurrentDictionary<Kgramm, ICollection<char>>();
            int l = text.Length - Kgramm.Length - 1;
            Logger logger = new Logger(0,l);
            Parallel.For(0, l, i => 
            {
                Kgramm e = new Kgramm(text, i);
                char c = text[i + Kgramm.Length];
                List<char> tempQualifier = new List<char> {c};
                dic.AddOrUpdate(e, tempQualifier, (k, v) =>
                {
                    v.Add(c);
                    return v;
                });
                logger.Update();

            });
            timer.Stop();
            Console.WriteLine("Y " + dic.Count + " " + timer.Elapsed);
            return GetEftagrammsCollection(dic);    
        }

        
        private static EftagrammsCollection GetEftagrammsCollection(IEnumerable<KeyValuePair<Kgramm, ICollection<char>>> dic)
        {
            Stopwatch timer = Stopwatch.StartNew();
            var result = new Dictionary<Kgramm, DRV<char>>();
            Logger logger = new Logger(0, dic.Count());
            foreach (var item in dic)
            {
                logger.Update();
                result.Add(item.Key, new DRV<char>(item.Value));
            }
            timer.Stop();
            Console.WriteLine("Y " + timer.Elapsed);
            return new EftagrammsCollection(result);
        }
      
    }
}
