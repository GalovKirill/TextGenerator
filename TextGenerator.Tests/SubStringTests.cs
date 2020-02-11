using NUnit.Framework;

namespace TextGenerator.Tests
{
    public class SubStringTests
    {
        

        [TestCase("12345Hello12345", "Hello12345", true)]
        [TestCase("1ello World!!df", "Hello World!!df", false)]
        public void Equal_CallEqualOnSubstr_EqualResult(string str1, string str2, bool result)
        {
            K.Value = 10;
            var substr1 = new SubString(5, str1);
            var substr2 = new SubString(0, str2);
            Assert.AreEqual(substr1.Equals(substr2), result);
        }
        
        [Test]
        public void SameObjectHasEqualHashCode()
        {
            var str1 = "Hello World!!df";
            K.Value = str1.Length;
            var substr1 = new SubString(0, str1);
            var substr2 = new SubString(0, str1);
            Assert.IsTrue(substr1.GetHashCode() == substr2.GetHashCode());
        }


        [Test]
        public void SomeCase()
        {
            K.Value = 2;
            const string str = "амамамамамамамамамамммммммм";
            var subs1 = new SubString(14, str);
            var subs2 = new SubString(18, str);
            Assert.True(subs1.Equals(subs2) && subs2.Equals(subs1));
            var hashCode = subs1.GetHashCode();
            var code = subs2.GetHashCode();
            Assert.True(hashCode == code);
        }
    }
}