using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using TextGenerator;

namespace Benchmark
{
    [SimpleJob(RuntimeMoniker.NetCoreApp30)]
    public class StringEqualsVsSubStringEquals
    {
        private readonly string s1 = new string("Hello World");
        private readonly string s2 = new string("Hello World");
        
        private readonly SubString sb1 = new SubString(0, "1ello World");
        private readonly SubString sb2 = new SubString(0, "Hello World");

        public StringEqualsVsSubStringEquals()
        {
            K.Value = "Hello World".Length;
        }

        [Benchmark]
        public bool StringEquals() => s1.Equals(s2);

        [Benchmark]
        public bool SubStringEquals() => sb1.Equals(sb2);


    }
}