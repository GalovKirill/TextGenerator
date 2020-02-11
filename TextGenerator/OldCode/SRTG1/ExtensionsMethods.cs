using System;
using System.Security.Cryptography;

namespace TextGenerator.OldCode.SRTG1
{
    public static class ExtensionsMethod
    {
        private static readonly RandomNumberGenerator _rng = RandomNumberGenerator.Create();

        public static void Print(this char c)
        {
            Console.Write(c);
        }
        
        public static int RandomNumber(int max)
        {
            byte[] bytes = new byte[4];
            _rng.GetBytes(bytes);
            
            return Math.Abs(BitConverter.ToInt32(bytes, 0)) % max;
        }
    }
}
