using System;
using System.Runtime.CompilerServices;

namespace TextGenerator
{
    public readonly struct SubString : IEquatable<SubString>
    {
        private readonly int _startIndex;
        private readonly string _source;

        public SubString(int startIndex, string source)
        {
            _startIndex = startIndex;
            _source = source;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private char GetFirstChar() => _source[_startIndex];
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private char GetSecondChar() => _source[_startIndex + 1];
        
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public bool Equals(SubString other)
        {
            if (GetFirstChar() != other.GetFirstChar())
                return false;

            if (GetSecondChar() != other.GetSecondChar())
                return false;

            unsafe
            {
                fixed(char* sm = _source)
                fixed(char* so = other._source)
                {
                    char* m = sm + _startIndex + 2;
                    char* o = so + other._startIndex + 2;
                    var l = K.Value - 2;
                    for (int i = 0; i < l; i++)
                    {
                        if (m[i] != o[i])
                            return false;
                    }
                }
                
                return true;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is SubString other && Equals(other);
        }

        public override string ToString()
        {
            return _source.Substring(_startIndex, K.Value);
        }

        public override int GetHashCode()
        {
            unsafe
            {
                ReadOnlySpan<char> readOnlySpan = _source.AsSpan(_startIndex, K.Value);
                fixed (char* src = readOnlySpan)
                {
                    var hash1 = 5381;
                    var hash2 = hash1;
                    int c;
                    for (var i = 0; i < readOnlySpan.Length - 1; i+=2)
                    {
                        c = src[i];
                        hash1 = ((hash1 << 5) + hash1) ^ c;
                        if(i + 1 == readOnlySpan.Length)
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