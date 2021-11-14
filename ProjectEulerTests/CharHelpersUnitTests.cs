using NUnit.Framework;
using ProjectEuler;

namespace ProjectEulerTests
{
    public class CharHelpersUnitTests
    {
        [Test]
        [TestCase(new char[] { 'a', 'b' }, new char[] { 'b', 'a' })]
        public void Swap(char[] value, char[] expected)
        {
            CharHelpers.Swap(ref value[0], ref value[1]);
            Assert.AreEqual(expected, value);
        }

        [Test]
        [TestCase(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' }, 2, 5, new char[] { 'a', 'b', 'f', 'e', 'd', 'c', 'g' })]
        public void Reverse(char[] value, int startIndex, int endIndex, char[] expected)
        {
            CharHelpers.Reverse(value, startIndex, endIndex);
            Assert.AreEqual(expected, value);
        }
    }
}
