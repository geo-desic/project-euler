using Microsoft.Extensions.Logging;

namespace ProjectEuler.Problems
{
    public class Problem030 : Problem<long>
    {
        public Problem030(ILogger<Problem030> logger) : base(logger) { }

        protected override long CalculateAnswer()
        {
            var max = 5L * 9L * 9L * 9L * 9L * 9L; // 9^5 + 9^5 + 9^5 + 9^5 + 9^5 = 295245
            var maxDigits = 9;
            var digits = new int[maxDigits];

            var answer = 0;
            Logger.LogDebug("Incremental Results:");
            for (var i = 2; i <= max; ++i)
            {
                Digits(i, digits);
                if (i == SumOfFifthPowers(digits))
                {
                    answer += i;
                    Logger.LogDebug("{i}", i);
                }
            }
            return answer;
        }

        private static void Digits(int n, int[] digits)
        {
            int d;
            for (var i = 0; i < digits.Length; ++i)
            {
                d = 0;
                if (n > 0)
                {
                    d = n % 10;
                    n /= 10;
                }
                digits[i] = d;
            }
        }

        private static int SumOfFifthPowers(int[] digits)
        {
            var result = 0;
            foreach (var d in digits)
            {
                result += d * d * d * d * d;
            }
            return result;
        }
    }
}
