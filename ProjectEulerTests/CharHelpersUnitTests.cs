﻿using NUnit.Framework;
using ProjectEuler;

namespace ProjectEulerTests
{
    public class CharHelpersUnitTests
    {
        [Test]
        [TestCase(new char[] { 'a', 'b' }, new char[] { 'b', 'a' })]
        public void Swap(char[] value, char[] result)
        {
            CharHelpers.Swap(ref value[0], ref value[1]);
            Assert.AreEqual(result, value);
        }

        [Test]
        [TestCase(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' }, 2, 5, new char[] { 'a', 'b', 'f', 'e', 'd', 'c', 'g' })]
        public void Reverse(char[] value, int startIndex, int endIndex, char[] result)
        {
            CharHelpers.Reverse(value, startIndex, endIndex);
            Assert.AreEqual(result, value);
        }
    }
}
