using NUnit.Framework;
using ProjectEuler;
using System.Linq;

namespace ProjectEulerTests
{
    public class MathHelpersUnitTests
    {
        [Test]
        [TestCase(3960, 4)]
        public void PrimeFactorization_CorrectNumberOfEntries(long value, int expected)
        {
            var factorization = MathHelpers.PrimeFactorization(value);
            Assert.AreEqual(expected, factorization.Entries.Count);
        }

        [Test]
        [TestCase(3960, 2, true)]
        [TestCase(3960, 3, true)]
        [TestCase(3960, 4, false)]
        [TestCase(3960, 5, true)]
        [TestCase(3960, 7, false)]
        [TestCase(3960, 11, true)]
        public void PrimeFactorization_HasEntry(long value, long prime, bool expected)
        {
            var factorization = MathHelpers.PrimeFactorization(value);
            var entry = factorization.Entry(prime);
            var hasEntry = entry != null;
            Assert.AreEqual(expected, hasEntry);
        }

        [Test]
        [TestCase(3960, 2, 3)]
        [TestCase(3960, 3, 2)]
        [TestCase(3960, 5, 1)]
        [TestCase(3960, 7, 0)]
        [TestCase(3960, 11, 1)]
        public void PrimeFactorization_Entry_CorrectPower(long value, long prime, int power)
        {
            var factorization = MathHelpers.PrimeFactorization(value);
            var entry = factorization.Entry(prime);
            if (power == 0)
                Assert.IsNull(entry);
            else
                Assert.AreEqual(power, entry.Power);
        }

        [Test]
        [TestCase(3960)]
        public void PrimeFactorization_CorrectProduct(long value)
        {
            var factorization = MathHelpers.PrimeFactorization(value);
            Assert.AreEqual(value, factorization.ComputeProduct());
        }

        [Test]
        [TestCase(2, false)]
        [TestCase(3, false)]
        [TestCase(4, true)]
        [TestCase(5, false)]
        [TestCase(6, true)]
        [TestCase(7, false)]
        [TestCase(8, true)]
        [TestCase(9, true)]
        [TestCase(10, true)]
        [TestCase(11, false)]
        [TestCase(12, true)]
        [TestCase(13, false)]
        [TestCase(14, true)]
        [TestCase(15, true)]
        [TestCase(16, true)]
        [TestCase(17, false)]
        [TestCase(18, true)]
        [TestCase(19, false)]
        [TestCase(20, true)]
        [TestCase(105, true)]
        [TestCase(447, true)]
        [TestCase(673, false)]
        [TestCase(967, false)]
        public void IndexCompositeBySieve_CorrectEntry(int value, bool expected)
        {
            var sieve = MathHelpers.IndexCompositeBySieve(value);
            Assert.AreEqual(expected, sieve[value]);
        }

        [Test]
        [TestCase(new int[0], 0, 1, false)]
        [TestCase(new[] { 0 }, 0, 0, true)]
        [TestCase(new[] { 3, 1, 4, 2 }, 1, 4, true)]
        [TestCase(new[] { 3, 1, 2, 2 }, 1, 4, false)]
        [TestCase(new[] { 3, 9, 1, 8, 6, 7, 2, 5, 4 }, 1, 9, true)]
        public void IsPandigital(int[] digits, int min, int max, bool expected)
        {
            Assert.AreEqual(expected, digits.IsPandigital(min, max));
        }

        [Test]
        [TestCase(3, 6)]
        [TestCase(35, 630)]
        public void NthTriangularNumber(int value, long expected)
        {
            Assert.AreEqual(expected, MathHelpers.NthTriangularNumber(value));
        }

        [Test]
        [TestCase(18, 6)]
        [TestCase(75600, 120)]
        public void DivisorCount(long value, int expected)
        {
            Assert.AreEqual(expected, MathHelpers.DivisorCount(value));
        }

        [Test]
        [TestCase("29", "564", "593")]
        [TestCase("7639699335248664191492064348354", "9306221839601782079348723649643", "16945921174850446270840787997997")]
        public void AddIntegerStrings(string value1, string value2, string expected)
        {
            Assert.AreEqual(expected, MathHelpers.AddIntegerStrings(value1, value2));
        }

        [Test]
        [TestCase(17, 52)]
        [TestCase(2456876, 1228438)]
        public void CollatzFunction(long value, long expected)
        {
            Assert.AreEqual(expected, MathHelpers.CollatzFunction(value));
        }

        [Test]
        [TestCase(2, 2)]
        [TestCase(3, 8)]
        [TestCase(9663, 185)]
        [TestCase(77671, 232)]
        public void CollatzLength(long value, long expected)
        {
            Assert.AreEqual(expected, MathHelpers.CollatzLength(value));
        }

        [Test]
        [TestCase("29", "564", "16356")]
        [TestCase("76396993349348354", "93063649643", "7109783022842356319014737622")]
        public void MultiplyIntegerStrings(string value1, string value2, string expected)
        {
            Assert.AreEqual(expected, MathHelpers.MultiplyIntegerStrings(value1, value2));
        }

        [Test]
        [TestCase(18, 1)]
        [TestCase(18, 2)]
        [TestCase(18, 3)]
        [TestCase(18, 6)]
        [TestCase(18, 9)]
        [TestCase(18, 18)]
        [TestCase(75600, 5040)]
        public void Divisors_Contains(long value, int expected)
        {
            var divisors = MathHelpers.Divisors(value).ToList();
            Assert.Contains(expected, divisors);
        }

        [Test]
        [TestCase(new char[] { 'a', 'b', 'c', 'd', 'e' }, new char[] { 'a', 'b', 'c', 'e', 'd' }, false)]
        [TestCase(new char[] { 'e', 'd', 'c', 'b', 'a' }, new char[] { 'a', 'b', 'c', 'd', 'e' }, true)]
        public void LexicographicPermute(char[] elements, char[] permutation, bool expected)
        {
            var returnValue = MathHelpers.LexicographicPermute(elements);
            Assert.AreEqual(permutation, elements);
            Assert.AreEqual(expected, returnValue);
        }

        [Test]
        [TestCase(97, new long[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 })]
        public void PrimesLessOrEqualTo(long value, long[] expected)
        {
            var primes = MathHelpers.PrimesLessOrEqualTo(value).ToArray();
            Assert.AreEqual(expected, primes);
        }

        [Test]
        [TestCase(97, 1060)]
        public void SumPrimesLessOrEqualTo(long value, long expected)
        {
            Assert.AreEqual(expected, MathHelpers.SumPrimesLessOrEqualTo(value));
        }

        [Test]
        [TestCase(15, 24, 3)]
        [TestCase(2457, 1783236, 273)]
        public void Gcd(long value1, long value2, long expected)
        {
            Assert.AreEqual(expected, MathHelpers.Gcd(value1, value2));
        }

        [Test]
        [TestCase(15, 24, 120)]
        [TestCase(2457, 1783236, 16049124)]
        public void Lcm(long value1, long value2, long expected)
        {
            Assert.AreEqual(expected, MathHelpers.Lcm(value1, value2));
        }
    }
}