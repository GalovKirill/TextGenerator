using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace TextGenerator.OldCode.SRTG3
{
    class Program
    {
        public const string ValidSymbol = "абвгдёежзийклмнопрстуфхцчшщъыьэюя " + "АБВГДЁЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ.,!?";
        public const string ResourceName = "res";
        
        
        static void Main1(string[] args)
        {
            
            WordsTree wordsTree = new WordsTree(448_377_875);
            

            foreach (var chars in GetChars(15))
            {
                wordsTree.Add(chars);
            }

            Console.WriteLine(GC.GetTotalMemory(false));

            var buffer = wordsTree.GetRandomStr(14).ToArray();
            Console.Write(buffer);
            for (int i = 0; i < 100; i++)
            {
                
                
                var randomChar = wordsTree.GetRandomChar(buffer);
                Console.Write(randomChar);
                for (int j = 0; j < buffer.Length - 1; j++)
                {
                    buffer[j] = buffer[j + 1];
                }

                buffer[13] = randomChar;
            }
            Thread.Sleep(5000);
            GC.Collect();
            Console.Read();
            

        }

        private static IEnumerable<char[]> GetChars(int k)
        {
            var resourceName = Assembly.GetExecutingAssembly().GetManifestResourceNames()
                .First(r => r.Contains(ResourceName));
            using var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            using var readStream = new StreamReader(resourceStream);
            char[] buffer = new char[k];
            var str = readStream.ReadToEnd();
            for (int i = 0; i < str.Length - k; i++)
            {
                str.CopyTo(i, buffer, 0, k);
                yield return buffer;
            }
        }
    }
}