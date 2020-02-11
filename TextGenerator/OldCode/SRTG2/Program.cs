using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace TextGenerator.OldCode.SRTG2
{
    class Program
    {
        private const string Path = @"res.txt";
        public const string ValidSymbol = "абвгдёежзийклмнопрстуфхцчшщъыьэюя " +
                                            "АБВГДЁЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ.,!?";
        static void Main1(string[] args)
        {

            //SafeAllTextToOneFile();  
            SomeProgramm();
            Console.WriteLine("Done");
        }

        
        static void SomeProgramm()
        {
            string text = File.ReadAllText(Path);
            KgrammsCollection eftCollection = KgrammsReader.GetEftagramms(text);            
            StringBuilder sb = new StringBuilder(eftCollection.RandomStart());
            Console.WriteLine("Начинаем печатать текст ");
            Console.Write(sb.ToString());
            Stopwatch timer = Stopwatch.StartNew();
            GC.Collect();
            for(int i = 0; i < 1000; i++)
            {         
                var last7Symbol = sb.ToString(sb.Length - Kgramm.Length, Kgramm.Length);
                char c = eftCollection.GetRandomCharFrom(last7Symbol);
                sb.Append(c);
                c.Print();
            }
            timer.Stop();
            Console.WriteLine("Y " + timer.Elapsed);
        }
        static void SafeAllTextToOneFile()
        {
            var pathes = Directory.GetFiles(@"/home/galovkirill/Гоголь");
            StringBuilder sb = new StringBuilder();
            foreach (var item in pathes)
            {
                Console.WriteLine(item);
                sb.Append(File.ReadAllText(item));
            }
            var ft = sb.ToString().Replace("\n", " ").Where(ValidSymbol.Contains).ToArray();
            var re = new string(ft).Split(" ",StringSplitOptions.RemoveEmptyEntries);
            sb = new StringBuilder();
            foreach (var item in re)           
                sb.Append(item + " ");            
            File.WriteAllText(@"/home/galovkirill/Гоголь/res.txt", sb.ToString());
        }
        
               
    }
    
    
}
