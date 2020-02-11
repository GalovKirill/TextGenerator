using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using TextGenerator;

namespace Benchmark
{
    [SimpleJob(RuntimeMoniker.NetCoreApp30)]
    public class StringHashCodeBenchmark
    {
        private readonly string _s1 = "Hello World";
        
        private readonly SubString _s2 = new SubString(0, "Hello World");

        public StringHashCodeBenchmark()
        {
            K.Value = "Hello World".Length;
        }

        [Benchmark]
        public int Default() => _s1.GetHashCode();

        [Benchmark]
        public int Stilled() => _s2.GetHashCode();
    }
}