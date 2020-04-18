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

        public static int IndexFirstCharNotEqualTo(this string value, char charValue, int startIndex = 0)
        {
            for (var i = startIndex; i < value.Length; ++i)
            {
                if (value[i] != charValue) return i;
            }
            return -1;
        }

        public static string Reverse(this string value)
        {
            var charArray = value.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string Right(this string value, int length)
        {
            if (length < 0) throw new ArgumentOutOfRangeException("length");
            else if (length == 0) return string.Empty;
            if (length > value.Length) length = value.Length;
            return value.Substring(value.Length - length);
        }

        public static string Left(this string value, int length)
        {
            if (length < 0) throw new ArgumentOutOfRangeException("length");
            else if (length == 0) return string.Empty;
            if (length > value.Length) length = value.Length;
            return value.Substring(0, length);
        }

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
    }
}
