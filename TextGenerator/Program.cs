using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TextGenerator
{
    internal static class Program
    {

        static Program()
        {
            Text = new  string(File.ReadAllText("res.txt").Where(c => Symbols.ValidSymbol.Contains(c)).ToArray());
        }

        public static readonly string Text;
        

        private static void Main(string[] args)
        {
            try
            {
                Work();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.Read();
            }
        }

        private static void Work()
        {
            K.Value = 30;
            ILoadStrategy loadStrategy = new LongCharSetThread();
            loadStrategy.Load();
            var chars = loadStrategy.GetResult();
            
            var startIndex = new Random().Next(1000, Text.Length - 1000);

            var sb = new StringBuilder();
            sb.Append(Text.Substring(startIndex, K.Value));
            for(var i = 0; i < 1000; i++)
            {
                SubstringEqualityComparer.Instance.Right = sb.ToString();

                var c = chars.Next(SubstringEqualityComparer.Instance.Right.Length - K.Value);
                sb.Append(c);
            }

            Console.WriteLine("Начинаем печатать текст:");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("Заканчиваем печатать текст");
        }
    }
}