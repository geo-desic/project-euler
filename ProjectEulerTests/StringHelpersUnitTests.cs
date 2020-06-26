using NUnit.Framework;
using ProjectEuler;

namespace ProjectEulerTests
{
    public class StringHelpersUnitTests
    {
        [Test]
        [TestCase("751171125489", '1', 2, 4)]
        public void IndexFirstCharNotEqualTo(string value, char charValue, int startIndex, int result)
        {
            Assert.AreEqual(result, value.IndexFirstCharNotEqualTo(charValue, startIndex));
        }

        [Test]
        [TestCase("abcDEFg", "gFEDcba")]
        public void Reverse(string value, string result)
        {
            Assert.AreEqual(result, value.Reverse());
        }

        [Test]
        [TestCase("k3bl450hm343", 6, "0hm343")]
        [TestCase("abcd", 17, "abcd")]
        [TestCase("abcd", 0, "")]
        public void Right(string value, int length, string result)
        {
            Assert.AreEqual(result, value.Right(length));
        }

        [Test]
        [TestCase("k3bl450hm343", 6, "k3bl45")]
        [TestCase("abcd", 17, "abcd")]
        [TestCase("abcd", 0, "")]
        public void Left(string value, int length, string result)
        {
            Assert.AreEqual(result, value.Left(length));
        }
    }
}
