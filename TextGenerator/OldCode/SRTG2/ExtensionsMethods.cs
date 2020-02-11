using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace TextGenerator.OldCode.SRTG2
{
    public static class ExtensionsMethod
    {
        private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();
        private static readonly byte[] Bytes = new byte[4];
        public static void Print(this char c)
        {
            Console.Write(c);
        }
        
        public static int RandomNumber(int max)
        {     
            Rng.GetBytes(Bytes);
            return Math.Abs(BitConverter.ToInt32(Bytes, 0)) % max;
        }

        public static T GetRandomElement<T>(this IList<T> list)
        {
            return list[RandomNumber(list.Count)];
        }
    }
}
