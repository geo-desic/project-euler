using Microsoft.Extensions.Logging;

namespace ProjectEuler.Problems
{
    public class Problem012 : Problem<long>
    {
        public Problem012(ILogger<Problem012> logger) : base(logger) { }

        protected override long CalculateAnswer()
        {
            var answer = 0L;

            Logger.LogDebug("Incremental Results:");
            var i = 1;
            var maxDivisors = 1;
            while (maxDivisors <= 500)
            {
                var triangularNumber = MathHelpers.NthTriangularNumber(i++);
                var divisors = MathHelpers.DivisorCount(triangularNumber);
                if (divisors > maxDivisors)
                {
                    Logger.LogDebug("Triangular #{Index} = {TriangularNumber}; Divisor Count = {DivisorCount}", i, triangularNumber, divisors);
                    maxDivisors = divisors;
                    answer = triangularNumber;
                }
            }

            return answer;
        }
    }
}
