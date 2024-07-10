using Microsoft.Extensions.Logging;

namespace ProjectEuler.Problems
{
    public class Problem027 : Problem<long>
    {
        public Problem027(ILogger<Problem027> logger) : base(logger) { }

        protected override long CalculateAnswer()
        {
            var upper_bound_n = 100L; // guess
            var upper_bound_function = Function(upper_bound_n, 999L, 1000L);
            var composite_sieve = MathHelpers.IndexCompositeBySieve(upper_bound_function);

            //f(n) = n^2 + an + b ==> f(0) = b ==> b must be a (positive) prime
            var primes_below_1000 = MathHelpers.PrimesLessOrEqualTo(1000);
            var max_length = 0;

            var a = 1L;
            var b = 1L;
            foreach (var b_inc in primes_below_1000)
            {
                //since b is prime ==> b is odd ==> b + 1 is even; f(1) = 1 + a + b = a + (b + 1) which is even if a is even ==> a must be odd
                for (var a_inc = 1; a_inc < 1000; a_inc += 2)
                {
                    //this loop is to try both positive and negative values for a_loop
                    for (var unit = -1L; unit <= 1L; unit += 2L)
                    {
                        var length = 0;
                        var n = 0L;
                        var a_current = unit * a_inc;
                        while (true)
                        {
                            var f = Function(n, a_current, b_inc);
                            if (f < 0L) f = -f;
                            if (!composite_sieve[f]) ++length;
                            else break;
                            ++n;
                        }
                        if (length > max_length)
                        {
                            a = a_current;
                            b = b_inc;
                            max_length = length;
                            Logger.LogDebug("length = {length}; a = {a}; b = {b}", length, a, b);
                        }
                    }
                }
            }

            return a * b;
        }

        private static long Function(long n, long a, long b)
        {
            //f(n) = n^2 + an + b
            return n * n + a * n + b;
        }
    }
}
