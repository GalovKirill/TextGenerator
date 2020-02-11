using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TextGenerator.OldCode.SRTG2
{
    public class KgrammsReader
    {   
        public  static KgrammsCollection GetEftagramms(string text)
        {
            Stopwatch timer = Stopwatch.StartNew();
            var dic = new Dictionary<Kgramm, IList<char>>();
            int l = text.Length - Kgramm.Length - 1;
            Logger logger = new Logger(0,l);
            Parallel.For(0, l, i => 
            {
                Kgramm e = new Kgramm(text, i);
                char c = text[i + Kgramm.Length];
                lock (dic) 
                    if (dic.ContainsKey(e)) dic[e].Add(c);                   
                    else dic.Add(e, new List<char>{c});                       
                logger.Update();

            });
            timer.Stop();
            Console.WriteLine("Y " + dic.Count + " " + timer.Elapsed);
            return new KgrammsCollection(dic);    
        }

        
        private static KgrammsCollection GetEftagrammsCollection(IEnumerable<KeyValuePair<Kgramm, ICollection<char>>> dic)
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
            return null;//new KgrammsCollection(result);
        }
      
    }
}
