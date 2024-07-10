using Microsoft.Extensions.Logging;

namespace ProjectEuler.Problems
{
    public class Problem006 : Problem<long>
    {
        public Problem006(ILogger<Problem006> logger) : base(logger) { }

        protected override long CalculateAnswer()
        {
            var n = 100;
            var sumOfSquares1ToN = SumOfSquares1ToN(n);
            var sum1ToNSquared = Sum1ToNSquared(n);

            Logger.LogDebug("Sum Of Squares 1 To {n}:", n);
            Logger.LogDebug("{sumOfSquares1ToN}", sumOfSquares1ToN);
            Logger.LogDebug("Sum 1 To {n} Squared:", n);
            Logger.LogDebug("{sum1ToNSquared}", sum1ToNSquared);

            return sum1ToNSquared - sumOfSquares1ToN;
        }

        private static long SumOfSquares1ToN(long n)
        {
            return n * (n + 1L) * (2 * n + 1L) / 6L;
        }

        private static long Sum1ToNSquared(long n)
        {
            var sum = n * (n + 1L) / 2L;
            return sum * sum;
        }
    }
}
