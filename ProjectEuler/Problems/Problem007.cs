using Microsoft.Extensions.Logging;
using System;

namespace ProjectEuler.Problems
{
    public class Problem007 : Problem<long>
    {
        public Problem007(ILogger<Problem007> logger) : base(logger) { }

        protected override long CalculateAnswer()
        {
            var n = 10001;
            var upperBound = UpperBound(n);
            var compositeSieve = MathHelpers.IndexCompositeBySieve(upperBound);

            Logger.LogDebug("Incremental Results:");
            var index = 0;
            long i;
            for (i = 2L; i <= upperBound; ++i)
            {
                if (!compositeSieve[i])
                {
                    Logger.LogDebug("{i}", i);
                    ++index;
                    if (index >= n) break;
                }
            }
            if (index < n) throw new Exception("Invalid upper bound: " + upperBound);

            return i;
        }

        //see the section "Approximations for the nth prime number" at https://en.wikipedia.org/wiki/Prime_number_theorem
        private static long UpperBound(int n)
        {
            if (n <= 5) return 11L;
            return (long)Math.Floor(n * (Math.Log(n) + Math.Log(Math.Log(n))));
        }
    }
}
