using NUnit.Framework;
using ProjectEuler;

namespace ProjectEulerTests
{
    public class CharHelpersUnitTests
    {
        [Test]
        [TestCase(new char[] { 'a', 'a' }, new char[] { 'a', 'a' })]
        [TestCase(new char[] { 'a', 'b' }, new char[] { 'b', 'a' })]
        public void Swap_SpecifiedInput_ExpectedResult(char[] value, char[] expected)
        {
            CharHelpers.Swap(ref value[0], ref value[1]);
            Assert.That(expected, Is.EqualTo(value));
        }

        [Test]
        [TestCase(new char[] { }, 0, 0, new char[] { })] // empty array => reverse should be itself
        [TestCase(new char[] { 'a' }, 0, 0, new char[] { 'a' })] // single element array => reverse should be itself
        [TestCase(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' }, 0, 0, new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' })] // index range empty => reverse should be itself
        [TestCase(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' }, 0, 6, new char[] { 'g', 'f', 'e', 'd', 'c', 'b', 'a' })] // index range the entire array => reverse the entire array
        [TestCase(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' }, 2, 5, new char[] { 'a', 'b', 'f', 'e', 'd', 'c', 'g' })] // index range smaller than the entire array => reverse only the expected range
        public void Reverse_SpecifiedInput_ExpectedResult(char[] value, int startIndex, int endIndex, char[] expected)
        {
            CharHelpers.Reverse(value, startIndex, endIndex);
            Assert.That(expected, Is.EqualTo(value));
        }
    }
}
