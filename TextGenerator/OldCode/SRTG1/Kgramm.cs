namespace TextGenerator.OldCode.SRTG1
{
    public class Kgramm
    {
        public const int Length = 18;
        
        public Kgramm(string s, int i = 0)
        {
            
            _s1 = s[i]; _s2 = s[i+1]; _s3 = s[i+2]; _s4 = s[i+3]; _s5 = s[i+4]; _s6 = s[i+5]; _s7 = s[i+6];
            _s8 = s[i+7]; _s9 = s[i+8]; _s10 = s[i+9];_s11 = s[i+10]; _s12 = s[i+11]; _s13 = s[i+12]; _s14 = s[i+13];
            _s15 = s[i+14]; _s16 = s[i+15]; _s17 = s[i+16]; _s18 = s[i+17];
            
        }

        private readonly char _s1;
        private readonly char _s2;
        private readonly char _s3;
        private readonly char _s4;
        private readonly char _s5;
        private readonly char _s6;
        private readonly char _s7;
        private readonly char _s8;
        private readonly char _s9;
        private readonly char _s10;
        private readonly char _s11;
        private readonly char _s12;
        private readonly char _s13;
        private readonly char _s14;
        private readonly char _s15;
        private readonly char _s16;
        private readonly char _s17;
        private readonly char _s18;
        
        
        public override int GetHashCode()
        {
            return _s1.GetHashCode() ^ _s2 ^ _s4 ^ _s6^_s7 ^
                   _s3.GetHashCode() ^
                   _s5.GetHashCode() ^
                   _s9.GetHashCode();// ^ _s18.GetHashCode() ^ _s15.GetHashCode();
        }

        public bool EqStr(string ef)
        {
            return _s1 == ef[0] && _s2 == ef[1] && _s3 == ef[2] && _s4 == ef[3] && _s5 == ef[4] && _s6 == ef[5] && _s7 == ef[6];
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Kgramm)) return false;
            var e = (Kgramm) obj;
            return _s1 == e._s1 && _s8 == e._s8 && _s14 == e._s14 &&
                   _s2 == e._s2 && _s9 == e._s9 && _s15 == e._s15 &&
                   _s3 == e._s3 && _s10 == e._s10 && _s16 == e._s16 &&
                   _s4 == e._s4 && _s11 == e._s11 && _s17 == e._s17 &&
                   _s5 == e._s5 && _s12 == e._s12 && _s18 == e._s18 &&
                   _s6 == e._s6 && _s13 == e._s13 &&
                   _s7 == e._s7;
        }

        public override string ToString()
        {
            return _s1.ToString()+_s2.ToString()+_s3.ToString()+_s4.ToString()+_s5.ToString()+_s6.ToString()+_s7.ToString()
            + _s8.ToString() + _s9.ToString() + _s10.ToString() + _s11.ToString() + _s12.ToString() + _s13.ToString() + _s14.ToString()
             + _s15.ToString() + _s16.ToString() + _s17.ToString() + _s18.ToString();
        }
    }
}
