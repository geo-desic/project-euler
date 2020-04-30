using System.Collections.Generic;

namespace ProjectEuler
{
    public static class MathHelpers
    {
        /// <summary>
        /// Constructs a boolean array where each positive entry > 1 will be true of the integer index is a composite number, false otherwise.
        /// </summary>
        /// <param name="n">Upper bound for the sieve.</param>
        public static bool[] IndexCompositeBySieve(long n)
        {
            var composite = new bool[n + 1];
            for (var i = 2L; i * i <= n; ++i)
            {
                if (!composite[i])
                {
                    for (var j = i * i; j <= n; j += i) composite[j] = true;
                }
            }
            return composite;
        }

        /// <summary>
        /// Constructs a list of all positive primes less than or equal to the integer provided.
        /// </summary>
        /// <param name="n">The upper bound for prime list.</param>
        public static List<long> PrimesLessOrEqualTo(long n)
        {
            var composite = IndexCompositeBySieve(n);

            var result = new List<long>();
            for (var i = 2L; i <= n; ++i)
            {
                if (!composite[i]) result.Add(i);
            }
            return result;
        }

        /// <summary>
        /// Constructs a prime factorization of the integer provided.
        /// <example>For example, 60 = 2^2 * 3 * 5.</example>
        /// </summary>
        /// <param name="n">The integer for which a prime factorization will be constructed.</param>
        public static PrimeFactorization PrimeFactorization(long n)
        {
            var result = new PrimeFactorization();
            var power = 0;

            while (n % 2L == 0)
            {
                n /= 2L;
                ++power;
            }
            if (power > 0) result.AddEntry(2L, power);

            for (var i = 3L; i <= System.Math.Sqrt(n); i += 2L)
            {
                power = 0;
                while (n % i == 0)
                {
                    n /= i;
                    ++power;
                }
                if (power > 0) result.AddEntry(i, power);
            }

            if (n > 2)
            {
                result.AddEntry(n, 1);
            }

            return result;
        }

        /// <summary>
        /// Calculates the sum of all positive primes less than or equal to the integer provided.
        /// <example>For example, 8 returns 17 = 2 + 3 + 5 + 7.</example>
        /// </summary>
        /// <param name="n">Upper bound for prime summation.</param>
        public static long SumPrimesLessOrEqualTo(long n)
        {
            var composite = IndexCompositeBySieve(n);
            var result = 0L;

            for (var i = 2L; i <= n; ++i)
            {
                if (!composite[i]) result += i;
            }
            return result;
        }

        /// <summary>
        /// Calcuates the nth triangular number (see https://en.wikipedia.org/wiki/Triangular_number).
        /// <example>For example, 6 returns 21.</example>
        /// </summary>
        /// <param name="n">The index of the triangular number to calculate.</param>
        public static long NthTriangularNumber(int n)
        {
            long i = n;
            return i * (i + 1) / 2;
        }

        /// <summary>
        /// Calculates the number of positive divisors of the integer provided.
        /// <example>For example, 18 returns 6 since it has divisors: 1, 2, 3, 6, 9, and 18.</example>
        /// </summary>
        /// <param name="n">The integer to count divisors for.</param>
        /// <returns>The total number of positive divisors of the integer n.</returns>
        public static int DivisorCount(long n)
        {
            var result = 1;
            var factorization = PrimeFactorization(n);
            foreach (var item in factorization.Entries)
            {
                result *= item.Power + 1;
            }
            return result;
        }

        /// <summary>
        /// Calculates all positive divisors of the integer provided.
        /// <example>For example, 18 returns IEnumerable<1, 2, 3, 6, 9, 18>.</example>
        /// </summary>
        /// <param name="n">The integer to calculate divisors for.</param>
        /// <param name="proper">If true, the integer n will be excluded.</param>
        /// <returns>All positive divisors of the integer n.</returns>
        public static IEnumerable<long> Divisors(long n, bool proper = false)
        {
            var factorization = PrimeFactorization(n);
            var divisorFactorization = new PrimeFactorization();
            foreach (var item in factorization.Entries)
            {
                divisorFactorization.AddEntry(item.Prime, 0);
            }

            var product = 1L;
            while (true)
            {
                if (!proper || product != n) yield return product;

                var incremented = false;
                foreach (var item in divisorFactorization.Entries)
                {
                    if (item.Power < factorization.Entry(item.Prime).Power)
                    {
                        product *= item.Prime;
                        ++item.Power;
                        incremented = true;
                        break;
                    }
                    else
                    {
                        for (var i = 0; i < item.Power; ++i)
                        {
                            product /= item.Prime;
                        }
                        item.Power = 0;
                    }
                }
                if (!incremented) break;
            }
        }

        /// <summary>
        /// Calculates the sum of the two integers provided in string form. Useful when the computation is outside the standard C# numeric data type range/bounds.
        /// </summary>
        /// <returns>The sum of integer1 and integer2.</returns>
        public static string AddIntegerStrings(string integer1, string integer2)
        {
            var result = "";

            //this algorithm assumes integer2's length is greater than or equal to integer1's length, so swap if necessary
            var lengthDiff = integer2.Length - integer1.Length;
            if (lengthDiff < 0)
            {
                var temp = integer1;
                integer1 = integer2;
                integer2 = temp;
                lengthDiff = -lengthDiff;
            }
            var maxLength = System.Math.Max(integer1.Length, integer2.Length);

            var carry = 0;
            for (var i = maxLength - 1; i >= 0; --i)
            {
                var sum = ((int)(integer2[i] - '0')) + carry;
                if (i >= lengthDiff)
                {
                    sum += ((int)(integer1[i - lengthDiff] - '0'));
                }
                result += (char)(sum % 10 + '0');
                carry = sum / 10;
            }
            if (carry > 0) result += (char)(carry + '0');

            return result.Reverse();
        }

        /// <summary>
        /// Calculates the product of the two integers provided in string form. Useful when the computation is outside the standard C# numeric data type range/bounds.
        /// </summary>
        /// <returns>The product of integer1 and integer2.</returns>
        public static string MultiplyIntegerStrings(string integer1, string integer2)
        {
            var negative = false;
            if (integer1[0] == '-')
            {
                negative = !negative;
                integer1 = integer1.Substring(1);
            }
            if (integer2[0] == '-')
            {
                negative = !negative;
                integer2 = integer2.Substring(1);
            }

            var digitsInReverse = new int[integer1.Length + integer2.Length];
            var index1 = 0;
            var index2 = 0;

            for (var i = integer1.Length - 1; i >= 0; --i)
            {
                var carry = 0;
                index2 = 0;
                int digit1 = integer1[i] - '0';

                for (var j = integer2.Length - 1; j >= 0; --j)
                {
                    int digit2 = integer2[j] - '0';
                    var sum = digit1 * digit2 + digitsInReverse[index1 + index2] + carry;
                    carry = sum / 10;
                    digitsInReverse[index1 + index2] = sum % 10;
                    ++index2;
                }

                if (carry > 0) digitsInReverse[index1 + index2] += carry;
                ++index1;
            }

            // find index of first non-zero digit from right to left (i.e. preceeding zeros due to reverse order)
            var index = digitsInReverse.Length - 1;
            while (index >= 0 && digitsInReverse[index] == 0) --index;
            if (index < 0) return "0";
            string result = "";
            if (negative) result += '-';
            while (index >= 0) result += (digitsInReverse[index--]);
            return result;
        }

        /// <summary>
        /// Calculates the Collatz function for the integer provided (see https://en.wikipedia.org/wiki/Collatz_conjecture).
        /// </summary>
        /// <param name="n">The input for the Collatz function.</param>
        public static long CollatzFunction(long n)
        {
            if (n % 2L == 0L) return n / 2L;
            return 3L * n + 1L;
        }

        /// <summary>
        /// Calculates the number of iterations (i.e. length) needed for the Collatz function to result in 1 starting at the provided integer.
        /// </summary>
        /// <param name="n">The initial input to the Collatz function.</param>
        /// <returns>The Collatz length starting at the integer n.</returns>
        public static int CollatzLength(long n)
        {
            var result = 1;
            while (n != 1L)
            {
                n = CollatzFunction(n);
                ++result;
            }
            return result;
        }

        /// <summary>
        /// Calculates the next lexicographic permutation of the array provided.
        /// </summary>
        /// <param name="elements">The array of elements to permute (in-place).</param>
        /// <returns>Returns true if the resulting permutation is the initial one, false otherwise.</returns>
        public static bool LexicographicPermute(char[] elements)
        {
            var lastIndex = elements.Length - 1;
            if (lastIndex < 1) return true;

            var i = lastIndex - 1;
            while (i >= 0 && !(elements[i] < elements[i + 1])) --i;

            var result = false;
            if (i < 0)
            {
                result = true;
                elements.Reverse(0, lastIndex);
            }
            else
            {
                var j = lastIndex;
                while (j > i + 1 && !(elements[j] > elements[i])) --j;
                CharHelpers.Swap(ref elements[i], ref elements[j]);
                elements.Reverse(i + 1, lastIndex);
            }
            return result;
        }

        /// <summary>
        /// Calculates the greatest common divisor of the integers a and b using the Euclidean algorithm.
        /// <example>For example, if a = 15 and b = 24 then their gcd is 3.</example>
        /// </summary>
        /// <returns>The greatest common divisor of a and b.</returns>
        public static long Gcd(long a, long b)
        {
            while (b != 0L)
            {
                var t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        /// <summary>
        /// Calculates the least common multiple of a and b by computing their product and dividing by their greatest common divisor.
        /// <example>For example, if a = 15 and b = 24 then their lcm is 120.</example>
        /// </summary>
        /// <returns>The least common multiple of a and b.</returns>
        public static long Lcm(long a, long b)
        {
            var d = Gcd(a, b);
            return a * b / d;
        }
    }
}
