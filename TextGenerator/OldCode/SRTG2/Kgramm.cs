namespace TextGenerator.OldCode.SRTG2
{
    public class Kgramm
    {
        public const int Length = 18;
        
        public Kgramm(string s, int i = 0)
        {
            _kgramm = s.Substring(i, Length);
        }

        private readonly string _kgramm;


        public override int GetHashCode() => _kgramm.GetHashCode();

        public bool EqStr(string ef) => _kgramm.Equals(ef);
        
        public override bool Equals(object obj)
        {
            if(!(obj is Kgramm)) return false;
            var e = (Kgramm) obj;
            return _kgramm.Equals(e._kgramm);
        }

        public override string ToString() => _kgramm;
    }
}
