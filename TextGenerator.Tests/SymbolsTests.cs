using NUnit.Framework;
using TextGenerator;

namespace TextGenerator.Tests
{
    class SymbolsTests
    {
        [Test]
        public void ToLong_CharsEqualsLong()
        {
            for(int i = 0; i < Symbols.Chars.Count; i++)
            {
                
                Assert.AreEqual(Symbols.Chars[(int)i].ToLong(), 1L << i);
            }
        }

        [Test]
        public void Add()
        {
            Assert.AreEqual(1L.Add(Symbols.Chars[1]), 0b_11L);
        }
    }
}