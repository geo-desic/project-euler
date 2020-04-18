using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    public class Problem021 : Problem<long>
    {
        public Problem021()
        {
            cache = new Dictionary<long, long>();
        }

        protected override long CalculateAnswer()
        {
            var answer = 0L;
            var n = 10000L;

            for (var i = 2L; i < n; ++i)
            {
                var sum1 = SumOfProperDivisors(i);
                var sum2 = SumOfProperDivisors(sum1);
                if (i == sum2 && i != sum1)
                {
                    answer += i;
                    WriteLineDetail("Amicable number: " + i + " (" + sum1 + "); Sum = " + answer);
                }
            }

            return answer;
        }

        private long SumOfProperDivisors(long n)
        {
            if (cache.TryGetValue(n, out long value))
            {
                return value;
            }
            value = MathHelpers.Divisors(n, true).Sum();
            cache[n] = value;
            return value;
        }

        private readonly Dictionary<long, long> cache;
    }
}
