using NUnit.Framework;
using ProjectEuler;

namespace ProjectEulerTests
{
    public class IntHelpersUnitTests
    {
        [Test]
        [TestCase(425524, true)]
        [TestCase(752623, false)]
        public void IsPalindrome(long value, bool result)
        {
            Assert.AreEqual(result, value.IsPalindrome());
        }

        [Test]
        [TestCase(873472, 274378)]
        [TestCase(1234567, 7654321)]
        public void ReverseDigits(long value, long result)
        {
            Assert.AreEqual(result, value.ReverseDigits());
        }

        [Test]
        [TestCase(29, "twenty nine")]
        [TestCase(116, "one hundred and sixteen")]
        [TestCase(23795, "twenty three thousand seven hundred and ninety five")]
        public void ToWords(long value, string result)
        {
            Assert.AreEqual(result, value.ToWords());
        }
    }
}
