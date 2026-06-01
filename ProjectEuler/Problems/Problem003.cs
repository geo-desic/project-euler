using Microsoft.Extensions.Logging;
using System.Linq;

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
            foreach (var prime in primeFactorization.Entries.Select(x => x.Prime))
            {
                Logger.LogDebug("{PrimeFactor}", prime);
                if (prime > answer) answer = prime;
            }

            return answer;
        }
    }
}
