using NUnit.Framework;
using ProjectEuler;

namespace ProjectEulerTests
{
    public class IntHelpersUnitTests
    {
        [Test]
        [TestCase(425524, true)]
        [TestCase(752623, false)]
        public void IsPalindrome(long value, bool expected)
        {
            Assert.AreEqual(expected, value.IsPalindrome());
        }

        [Test]
        [TestCase(2, 0, 1)]
        [TestCase(2, 1, 2)]
        [TestCase(2, 5, 32)]
        [TestCase(5, 3, 125)]
        [TestCase(17, 4, 83521)]
        public void Power(int valueBase, int exponent, int expected)
        {
            Assert.AreEqual(expected, valueBase.Power(exponent));
        }

        [Test]
        [TestCase(873472, 274378)]
        [TestCase(1234567, 7654321)]
        public void ReverseDigits(long value, long expected)
        {
            Assert.AreEqual(expected, value.ReverseDigits());
        }

        [Test]
        [TestCase(0, new int[] { 0 })]
        [TestCase(3, new int[] { 3 })]
        [TestCase(57, new int[] { 7, 5 })]
        [TestCase(-784, new int[] { 4, 8, 7 })]
        [TestCase(9876543210, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public void ToDigits(long value, int[] expected)
        {
            Assert.AreEqual(expected, value.ToDigits().ToArray());
        }

        [Test]
        [TestCase(29, "twenty nine")]
        [TestCase(116, "one hundred and sixteen")]
        [TestCase(23795, "twenty three thousand seven hundred and ninety five")]
        public void ToWords(long value, string expected)
        {
            Assert.AreEqual(expected, value.ToWords());
        }
    }
}
