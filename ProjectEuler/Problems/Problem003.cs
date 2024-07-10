using Microsoft.Extensions.Logging;

namespace ProjectEuler.Problems
{
    public class Problem003 : Problem<long>
    {
        public Problem003(ILogger<Problem003> logger) : base(logger) { }

        protected override long CalculateAnswer()
        {
            var answer = 0L;
            var n = 600851475143L;
            var primeFactorization = MathHelpers.PrimeFactorization(n);

            Logger.LogDebug("Prime Factors:");
            foreach (var item in primeFactorization.Entries)
            {
                Logger.LogDebug("{primeFactor}", item.Prime);
                if (item.Prime > answer) answer = item.Prime;
            }

            return answer;
        }
    }
}
