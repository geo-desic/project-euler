using Microsoft.Extensions.Logging;
using System;

namespace ProjectEuler.Problems
{
    public class Problem037 : Problem<long>
    {
        public Problem037(ILogger<Problem037> logger) : base(logger) { }

        protected override long CalculateAnswer()
        {
            // must be at least 2 digits or more
            // allowable digits
            // left   : 2, 3, 5, 7 (single digit primes)
            // middle : 1, 3, 7, 9 (0, 2, 4, 5, 6, 8 would not work because after right truncation to that digit it would be divisible by 2 or 5)
            // right  : 3, 7       (single digit primes except 2 and 5 since it would not be prime for two or more digits)

            var answer = 0L;
            var countMiddleDigitsBound = 4;
            var isCompositeBySieve = MathHelpers.IndexCompositeBySieve(UpperBoundSieve(countMiddleDigitsBound));

            Logger.LogDebug("Incremental Results:");

            for (var countMiddleDigits = 0; countMiddleDigits <= countMiddleDigitsBound; ++countMiddleDigits)
            {
                var maxIndex = CountDigitsBase4ToMaxIndex10(countMiddleDigits);
                for (var m = 0L; m <= maxIndex; ++m)
                {
                    // enumerate all possibilities by converting m to base 4 and replacing digits
                    var middleDigits = 0L;
                    var factor10Middle = 1L;

                    var mTemp = m;
                    for (var digit = 0; digit < countMiddleDigits; ++digit)
                    {
                        middleDigits += factor10Middle * DigitMappingMiddle(mTemp % 4L);
                        mTemp /= 4L;
                        factor10Middle *= 10L;
                    }

                    for (var l = 0L; l < 4; ++l)
                    {
                        var leftAndMiddleDigits = factor10Middle * DigitMappingLeft(l) + middleDigits;
                        var factor10LeftAndMiddle = factor10Middle * 10L;
                        for (var r = 0L; r < 2; ++r)
                        {
                            var number = 10 * leftAndMiddleDigits + DigitMappingRight(r);
                            var primeTruncatableLeft = true;
                            var primeTruncatableRight = true;

                            var numberTruncatedRight = number;
                            while (numberTruncatedRight > 0)
                            {
                                if (isCompositeBySieve[numberTruncatedRight])
                                {
                                    primeTruncatableRight = false;
                                    break;
                                }
                                numberTruncatedRight /= 10L;
                            }

                            if (primeTruncatableRight)
                            {
                                var numberTruncatedLeft = number;
                                var factorMod = factor10LeftAndMiddle;
                                while (numberTruncatedLeft > 0)
                                {
                                    if (isCompositeBySieve[numberTruncatedLeft])
                                    {
                                        primeTruncatableLeft = false;
                                        break;
                                    }
                                    numberTruncatedLeft %= factorMod;
                                    factorMod /= 10L;
                                }

                                if (primeTruncatableLeft)
                                {
                                    Logger.LogDebug("{number}", number);
                                    answer += number;
                                }
                            }
                        }
                    }
                }
            }

            return answer;
        }

        private static long CountDigitsBase4ToMaxIndex10(long count)
        {
            var result = 0L;
            var factor = 1L;
            for (var i = 0L; i < count; ++i)
            {
                result += factor * 3L;
                factor *= 4L;
            }
            return result;
        }

        private static long DigitMappingLeft(long digit)
        {
            // 0 => 2
            // 1 => 3
            // 2 => 5
            // 3 => 7
            if (digit == 0) return 2;
            if (digit == 1) return 3;
            if (digit == 2) return 5;
            if (digit == 3) return 7;
            throw new ArgumentOutOfRangeException("invalid digit: " + digit);
        }

        private static long DigitMappingMiddle(long digit)
        {
            // 0 => 1
            // 1 => 3
            // 2 => 7
            // 3 => 9
            if (digit == 0) return 1;
            if (digit == 1) return 3;
            if (digit == 2) return 7;
            if (digit == 3) return 9;
            throw new ArgumentOutOfRangeException("invalid digit: " + digit);
        }

        private static long DigitMappingRight(long digit)
        {
            // 0 => 3
            // 1 => 7
            if (digit == 0) return 3;
            if (digit == 1) return 7;
            throw new ArgumentOutOfRangeException("invalid digit: " + digit);
        }

        private static long UpperBoundSieve(int countMiddleDigits)
        {
            var power10 = 10.Power(countMiddleDigits + 1);
            return 10 * (7 * power10 + (power10 - 1)) + 7;
        }
    }
}
