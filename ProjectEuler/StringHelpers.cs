using System;
using System.Text;

namespace ProjectEuler
{
    public static class StringHelpers
    {
        private static readonly string[] INT_WORDS_BELOW_20 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static readonly string[] INT_WORDS_TENS_DIGIT = { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private const string INT_WORDS_AND = "and";
        private const string INT_WORDS_HUNDRED_SUFFIX = "hundred";
        private const string INT_WORDS_NEGATIVE = "negative";
        private static readonly string[] INT_WORDS_SUFFIX_POWERS_1000 = { "thousand", "million", "billion", "trillion", "quadrillion", "quintillion", "sextillion", "septillion", "octillion", "nonillion", "decillion" };

        /// <summary>
        /// Returns the index of the string's first character not equal to the character provided.
        /// </summary>
        public static int IndexFirstCharNotEqualTo(this string value, char charValue, int startIndex = 0)
        {
            for (var i = startIndex; i < value.Length; ++i)
            {
                if (value[i] != charValue) return i;
            }
            return -1;
        }

        /// <summary>
        /// Returns true if the string provided is a palindrome (i.e. the sequence of characters and reversed characters are equivalent), false otherwise.
        /// <example>For example, aabaa returns true and abc returns false.</example>
        /// </summary>
        /// <param name="value">The string to test whether it is a palindrome.</param>
        public static bool IsPalindrome(this string value)
        {
            return value == value.Reverse();
        }

        /// <summary>
        /// Returns the string's leftmost characters of the length provided.
        /// </summary>
        public static string Left(this string value, int length)
        {
            if (length < 0) throw new ArgumentOutOfRangeException("length");
            else if (length == 0) return string.Empty;
            if (length > value.Length) length = value.Length;
            return value.Substring(0, length);
        }

        /// <summary>
        /// Constructs a string representation of the integer in words.
        /// <example>For example, 237 returns "two hundred and thirty seven".</example>
        /// </summary>
        public static string IntegerStringToWords(this string integer, bool includeAnd = true)
        {
            if (integer.Length == 0) return null;
            var builder = new StringBuilder();

            if (integer[0] == '-')
            {
                builder.Append(INT_WORDS_NEGATIVE);
                integer = integer.Substring(1);
            }

            var digitsRemaining = integer;

            do
            {
                var i = digitsRemaining.IndexFirstCharNotEqualTo('0');
                if (i < 0) digitsRemaining = string.Empty;
                else if (i > 0) digitsRemaining = digitsRemaining.Substring(i);
                if (digitsRemaining.Length > 0)
                {
                    var power1000 = (digitsRemaining.Length - 1) / 3;
                    var digitsGroup = digitsRemaining.Substring(0, digitsRemaining.Length - 3 * power1000);
                    if (digitsGroup.Length == 3)
                    {
                        var firstDigit = digitsGroup[0] - '0';
                        if (builder.Length > 0) builder.Append(' ');
                        builder.Append(INT_WORDS_BELOW_20[firstDigit] + " " + INT_WORDS_HUNDRED_SUFFIX);
                        if (includeAnd && digitsRemaining.IndexFirstCharNotEqualTo('0', 1) > 0)
                        {
                            if (builder.Length > 0) builder.Append(' ');
                            builder.Append(INT_WORDS_AND);
                        }
                    }
                    var digitsRemainingGroup = digitsGroup.Right(2);
                    if (digitsRemainingGroup == "00") { }
                    else
                    {
                        var onesDigit = digitsRemainingGroup[digitsRemainingGroup.Length - 1] - '0';
                        var tensDigit = 0;
                        if (digitsRemainingGroup.Length > 1)
                        {
                            tensDigit = digitsRemainingGroup[0] - '0';
                        }
                        if (digitsRemainingGroup.Length == 2 && (digitsRemainingGroup[0] == '0' || digitsRemainingGroup[0] == '1') || digitsRemainingGroup.Length == 1)
                        {
                            var value = onesDigit + 10 * tensDigit;
                            if (builder.Length > 0) builder.Append(' ');
                            builder.Append(INT_WORDS_BELOW_20[value]);
                        }
                        else
                        {
                            if (builder.Length > 0) builder.Append(' ');
                            builder.Append(INT_WORDS_TENS_DIGIT[tensDigit - 1]);
                            if (onesDigit > 0)
                            {
                                builder.Append(' ');
                                builder.Append(INT_WORDS_BELOW_20[onesDigit]);
                            }
                        }
                    }
                    if (power1000 > 0)
                    {
                        builder.Append(' ');
                        builder.Append(INT_WORDS_SUFFIX_POWERS_1000[power1000 - 1]);
                    }
                    if (digitsGroup.Length >= digitsRemaining.Length) digitsRemaining = string.Empty;
                    else digitsRemaining = digitsRemaining.Substring(digitsGroup.Length);
                }
            } while (digitsRemaining.Length > 0);

            if (builder.Length == 0) builder.Append(INT_WORDS_BELOW_20[0]);

            return builder.ToString();
        }

        /// <summary>
        /// Returns true if the strings digits are pandigital (i.e. contain all digits from min to max exactly once), false otherwise.
        /// <example>IsPandigital("3142", 1, 4) returns true</example>
        /// <example>IsPandigital("3122", 1, 4) returns false</example>
        /// </summary>
        /// <param name="value">The string of digits where each character is between 0 and 9.</param>
        /// <param name="min">The pandigital digit minimum bound</param>
        /// <param name="max">The pandigital digit maximum bound</param>
        public static bool IsPandigital(this string value, int min = 1, int max = 9)
        {
            if (value == null || value.Length == 0) return false;
            var digits = new int[value.Length];
            for (var i = 0; i < value.Length; ++i)
            {
                digits[i] = (value[i] - '0');
            }
            return digits.IsPandigital(min, max);
        }

        /// <summary>
        /// Reverses the string provided.
        /// <example>For example, "Abcd" returns "dcbA".</example>
        /// </summary>
        public static string Reverse(this string value)
        {
            var charArray = value.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Returns the string's rightmost characters of the length provided.
        /// </summary>
        public static string Right(this string value, int length)
        {
            if (length < 0) throw new ArgumentOutOfRangeException("length");
            else if (length == 0) return string.Empty;
            if (length > value.Length) length = value.Length;
            return value.Substring(value.Length - length);
        }
    }
}
