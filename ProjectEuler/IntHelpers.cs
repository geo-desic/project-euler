namespace ProjectEuler
{
    public static class IntHelpers
    {
        public static bool IsPalindrome(this int value)
        {
            return value == value.ReverseDigits();
        }

        public static bool IsPalindrome(this long value)
        {
            return value == value.ReverseDigits();
        }

        public static PrimeFactorization PrimeFactorization(this int value)
        {
            return MathHelpers.PrimeFactorization(value);
        }

        public static PrimeFactorization PrimeFactorization(this long value)
        {
            return MathHelpers.PrimeFactorization(value);
        }

        public static int ReverseDigits(this int value)
        {
            return (int)((long)value).ReverseDigits();
        }

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

        public static string ToWords(this int value)
        {
            return value.ToString().IntegerStringToWords();
        }

        public static string ToWords(this long value)
        {
            return value.ToString().IntegerStringToWords();
        }
    }
}
