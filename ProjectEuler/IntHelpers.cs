namespace ProjectEuler
{
    public static class IntHelpers
    {
        /// <summary>
        /// Returns true if the integer provided is a palindrome (i.e. the sequence of its digits and reversed digits are equivalent), false otherwise.
        /// <example>For example, 14641 returns true and 1342 returns false.</example>
        /// </summary>
        /// <param name="value">The integer to test whether it is a palindrome.</param>
        public static bool IsPalindrome(this int value)
        {
            return value == value.ReverseDigits();
        }

        /// <summary>
        /// Returns true if the integer provided is a palindrome (i.e. the sequence of its digits and reversed digits are equivalent), false otherwise.
        /// <example>For example, 14641 returns true and 1342 returns false.</example>
        /// </summary>
        /// <param name="value">The integer to test whether it is a palindrome.</param>
        public static bool IsPalindrome(this long value)
        {
            return value == value.ReverseDigits();
        }

        /// <summary>
        /// Constructs a prime factorization of the integer provided.
        /// <example>For example, 60 = 2^2 * 3 * 5.</example>
        /// </summary>
        /// <param name="value">The integer for which a prime factorization will be constructed.</param>
        public static PrimeFactorization PrimeFactorization(this int value)
        {
            return MathHelpers.PrimeFactorization(value);
        }

        /// <summary>
        /// Constructs a prime factorization of the integer provided.
        /// <example>For example, 60 = 2^2 * 3 * 5.</example>
        /// </summary>
        /// <param name="value">The integer for which a prime factorization will be constructed.</param>
        public static PrimeFactorization PrimeFactorization(this long value)
        {
            return MathHelpers.PrimeFactorization(value);
        }

        /// <summary>
        /// Reverses the decimal digits for the integer provided.
        /// <example>For example, 13795 returns 59731.</example>
        /// </summary>
        /// <param name="value">The integer to reverse.</param>
        /// <returns>The integer with reversed decimal digits to the one provided.</returns>
        public static int ReverseDigits(this int value)
        {
            return (int)((long)value).ReverseDigits();
        }

        /// <summary>
        /// Reverses the decimal digits for the integer provided.
        /// <example>For example, 13795 returns 59731.</example>
        /// </summary>
        /// <param name="value">The integer to reverse.</param>
        /// <returns>The integer with reversed decimal digits to the one provided.</returns>
        public static long ReverseDigits(this long value)
        {
            bool negative = false;
            if (value < 0)
            {
                negative = true;
                value = -value;
            }

            var result = 0L;
            while (value > 0)
            {
                result = result * 10 + value % 10;
                value /= 10;
            }

            if (negative) return -result;
            return result;
        }

        /// <summary>
        /// Constructs a string representation of the integer in words.
        /// <example>For example, 237 returns "two hundred and thirty seven".</example>
        /// </summary>
        /// <param name="value">The integer for which a string representation will be constructed.</param>
        public static string ToWords(this int value)
        {
            return value.ToString().IntegerStringToWords();
        }

        /// <summary>
        /// Constructs a string representation of the integer in words.
        /// <example>For example, 237 returns "two hundred and thirty seven".</example>
        /// </summary>
        /// <param name="value">The integer for which a string representation will be constructed.</param>
        public static string ToWords(this long value)
        {
            return value.ToString().IntegerStringToWords();
        }
    }
}
