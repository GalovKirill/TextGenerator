using System.Collections.Generic;

namespace TextGenerator
{
    public class SubstringEqualityComparer : IEqualityComparer<int>
    {
        public static readonly SubstringEqualityComparer Instance = new SubstringEqualityComparer();

        private SubstringEqualityComparer()
        {
            
        }
        
        
        public string Right;
        public string Left;
        public bool Equals(int x, int y)
        {
            unsafe
            {
                fixed(char* sm = Left)
                fixed(char* so = Right)
                {
                    char* m = sm + x;
                    char* o = so + y;
                    for (var i = K.Value - 1; i > 0; i--)
                    {
                        if (m[i] != o[i])
                            return false;
                    }
                }
                
                return true;
            }
        }

        public int GetHashCode(int obj)
        {
            unsafe
            {
                // var readOnlySpan = Right.AsSpan(obj, K.Value);
                fixed (char* s = Right)
                {
                    var hash1 = 5381;
                    var hash2 = hash1;
                    int c;
                    char* src = s + obj;
                    for (var i = 0; i < K.Value - 1; i+=2)
                    {
                        c = src[i];
                        hash1 = ((hash1 << 5) + hash1) ^ c;
                        if(i + 1 == K.Value)
                            break;
                        c = src[i + 1];
                        hash2 = ((hash2 << 5) + hash2) ^ c;
                    }
                    return hash1 + hash2 * 1566083941;
                }
            }
        }
    }
}