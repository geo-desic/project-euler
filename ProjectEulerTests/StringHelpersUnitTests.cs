using NUnit.Framework;
using ProjectEuler;

namespace ProjectEulerTests
{
    public class StringHelpersUnitTests
    {
        [Test]
        [TestCase("751171125489", '1', 2, 4)]
        public void IndexFirstCharNotEqualTo(string value, char charValue, int startIndex, int expected)
        {
            Assert.That(expected, Is.EqualTo(value.IndexFirstCharNotEqualTo(charValue, startIndex)));
        }

        [Test]
        [TestCase("", 0, 1, false)]
        [TestCase("0", 0, 0, true)]
        [TestCase("a", 0, 0, false)]
        [TestCase("3142", 1, 4, true)]
        [TestCase("3122", 1, 4, false)]
        [TestCase("391867254", 1, 9, true)]
        public void IsPandigital(string value, int min, int max, bool expected)
        {
            Assert.That(expected, Is.EqualTo(value.IsPandigital(min, max)));
        }

        [Test]
        [TestCase("abcDEFg", "gFEDcba")]
        public void Reverse(string value, string expected)
        {
            Assert.That(expected, Is.EqualTo(value.Reverse()));
        }

        [Test]
        [TestCase("k3bl450hm343", 6, "0hm343")]
        [TestCase("abcd", 17, "abcd")]
        [TestCase("abcd", 0, "")]
        public void Right(string value, int length, string expected)
        {
            Assert.That(expected, Is.EqualTo(value.Right(length)));
        }

        [Test]
        [TestCase("k3bl450hm343", 6, "k3bl45")]
        [TestCase("abcd", 17, "abcd")]
        [TestCase("abcd", 0, "")]
        public void Left(string value, int length, string expected)
        {
            Assert.That(expected, Is.EqualTo(value.Left(length)));
        }
    }
}
