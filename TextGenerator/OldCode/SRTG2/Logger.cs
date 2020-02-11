using System;

namespace TextGenerator.OldCode.SRTG2
{
    public class Logger
    {
        private int _curr;
        private readonly int _finish;
        private int _last;

        public Logger(int current, int finish)
        {
            _curr = current;
            _finish = finish;
        }

        public void Update()
        {
            
            _curr++;
            int t = _curr*100 / _finish;
            if(t != _last) Console.Write("\b\b{0}", t);
            _last = t;
        }
    }
}